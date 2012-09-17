// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Engine.cs" company="Yellow Feather Ltd">
//   Copyright 2012 Yellow Feather Ltd.
// </copyright>
// <summary>
//   The DBF comparison engine.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DbfCompare.DbfDiff
{
    using System.Collections.Generic;
    using System.Linq;

    using SocialExplorer.IO.FastDBF;

    /// <summary>
    /// The engine.
    /// </summary>
    public class Engine
    {
        /// <summary>
        /// Compares two DBF files.
        /// Note: the algorithm relies on the fact that it is only possible to 
        /// append records to a DBF file (i.e. no inserts in the middle of the 
        /// file) and it is requires the older file is passed as the first 
        /// argument.
        /// </summary>
        /// <param name="oldFilepath">
        /// The path to the older DBF file to compare.
        /// </param>
        /// <param name="newFilepath">
        /// The path to the newer DBF file to compare.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/> of the differences between the two files.
        /// </returns>
        public static IEnumerable<Diff> Compare(string oldFilepath, string newFilepath)
        {
            using (var reader1 = new DbfReader(oldFilepath))
            using (var reader2 = new DbfReader(newFilepath))
            {
                //// todo: check compatible schema

                var hasMore1 = reader1.Read();
                var hasMore2 = reader2.Read();

                while (hasMore1 && hasMore2)
                {
                    var record1 = reader1.DbfRecord;
                    var record2 = reader2.DbfRecord;

                    var diff = Compare(record1, record2);
                    switch (diff.Operation)
                    {
                        case Operation.Unmodified:
                            hasMore1 = reader1.Read();
                            hasMore2 = reader2.Read();
                            break;
                        case Operation.Modified:
                            hasMore1 = reader1.Read();
                            hasMore2 = reader2.Read();
                            break;
                        case Operation.Deleted:
                            hasMore1 = reader1.Read();
                            break;
                    }

                    if (diff.Operation != Operation.Unmodified)
                    {
                        yield return diff;
                    }

                    if (hasMore1 || !hasMore2)
                    {
                        continue;
                    }

                    var index = record1.RecordIndex;
                    while (reader2.Read())
                    {
                        record2 = reader2.DbfRecord;

                        var columnDiffs = new List<ColumnDiff>();
                        for (int columnIndex = 0; columnIndex < record1.ColumnCount; ++columnIndex)
                        {
                            var columnDiff = new ColumnDiff(columnIndex, record1[columnIndex], record2[columnIndex]);
                            columnDiffs.Add(columnDiff);
                        }

                        yield return new Diff(Operation.Inserted, ++index, columnDiffs);
                    }

                    hasMore2 = false;
                }
            }
        }

        /// <summary>
        /// Compares two DbfRecords.
        /// </summary>
        /// <param name="record1">
        /// The first record to compare.
        /// </param>
        /// <param name="record2">
        /// The second record to compare.
        /// </param>
        /// <returns>
        /// The <see cref="Diff"/> between the two records.
        /// </returns>
        public static Diff Compare(DbfRecord record1, DbfRecord record2)
        {
            var data1 = record1.Data;
            var data2 = record2.Data;

            if (data1.SequenceEqual(data2))
            {
                return new Diff(Operation.Unmodified, record1.RecordIndex);
            }

            if (record2.IsDeleted)
            {
                return new Diff(Operation.Deleted, record1.RecordIndex);
            }

            var columnDiffs = new List<ColumnDiff>();
            var equalCount = 0;
            for (var columnIndex = 0; columnIndex < record1.ColumnCount; ++columnIndex)
            {
                var columnData1 = new ArraySegmentWrapper<byte>(record1.ColumnData(columnIndex));
                var columnData2 = new ArraySegmentWrapper<byte>(record2.ColumnData(columnIndex));

                if (columnData1.SequenceEqual(columnData2))
                {
                    ++equalCount;
                }
                else
                {
                    var columnDiff = new ColumnDiff(columnIndex, record1[columnIndex], record2[columnIndex]);
                    columnDiffs.Add(columnDiff);
                }
            }

            if (equalCount == 0)
            {
                return new Diff(Operation.Deleted, record1.RecordIndex);
            }

            if (equalCount == record1.ColumnCount)
            {
                return new Diff(Operation.Unmodified, record1.RecordIndex);
            }

            return new Diff(Operation.Modified, record1.RecordIndex, columnDiffs);
        }
    }
}