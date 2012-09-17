// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Diff.cs" company="Yellow Feather Ltd">
//   Copyright (c) 2012 Yellow Feather Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace DbfCompare.DbfDiff
{
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The diff.
    /// </summary>
    public class Diff
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="Diff"/> class.
        /// </summary>
        /// <param name="operation">
        /// The operation.
        /// </param>
        /// <param name="index">
        /// The index.
        /// </param>
        public Diff(Operation operation, int index)
        {
            this.Operation = operation;
            this.Index = index;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="Diff"/> class.
        /// </summary>
        /// <param name="operation">
        /// The operation.
        /// </param>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="columnDiffs">
        /// The list of column differences.
        /// </param>
        public Diff(Operation operation, int index, IList<ColumnDiff> columnDiffs)
        {
            this.Operation = operation;
            this.Index = index;
            this.ColumnDiffs = columnDiffs;
        }

        /// <summary>
        /// Gets the column differencess.
        /// </summary>
        public IList<ColumnDiff> ColumnDiffs { get; private set; }

        /// <summary>
        /// Gets the index.
        /// </summary>
        public int Index { get; private set; }

        /// <summary>
        /// Gets the operation.
        /// </summary>
        public Operation Operation { get; private set; }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("Index: {0}, Operation: {1}", this.Index, this.Operation);

            if ((this.Operation == Operation.Modified) || (this.Operation == Operation.Inserted))
            {
                sb.AppendLine();
                sb.AppendLine("  {");
                foreach (ColumnDiff columnDiff in this.ColumnDiffs)
                {
                    sb.Append("    { ");
                    sb.Append(columnDiff.Index);

                    if (this.Operation == Operation.Modified)
                    {
                        sb.Append(", '");
                        sb.Append(columnDiff.OldValue);
                        sb.Append("'");
                    }

                    sb.Append(", '");
                    sb.Append(columnDiff.NewValue);
                    sb.Append("'");
                    sb.AppendLine("    }, ");
                }

                sb.AppendLine("  }");
            }

            return sb.ToString();
        }
    }
}