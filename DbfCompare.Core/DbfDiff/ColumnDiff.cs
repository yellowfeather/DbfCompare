// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColumnDiff.cs" company="Yellow Feather Ltd">
//   Copyright (c) 2012 Yellow Feather Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace DbfCompare.Core.DbfDiff
{
    /// <summary>
    /// The column diff.
    /// </summary>
    public struct ColumnDiff
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnDiff"/> struct.
        /// </summary>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="oldValue">
        /// The old value.
        /// </param>
        /// <param name="newValue">
        /// The new value.
        /// </param>
        public ColumnDiff(int index, string oldValue, string newValue)
            : this()
        {
            this.Index = index;
            this.OldValue = oldValue;
            this.NewValue = newValue;
        }

        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Gets or sets the new value.
        /// </summary>
        public string NewValue { get; set; }

        /// <summary>
        /// Gets or sets the old value.
        /// </summary>
        public string OldValue { get; set; }
    }
}