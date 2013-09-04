// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Operation.cs" company="Yellow Feather Ltd">
//   Copyright (c) 2012 Yellow Feather Ltd
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace DbfCompare.Core.DbfDiff
{
    /// <summary>
    /// The operation.
    /// </summary>
    public enum Operation
    {
        /// <summary>
        /// The inserted.
        /// </summary>
        Inserted, 

        /// <summary>
        /// The unmodified.
        /// </summary>
        Unmodified, 

        /// <summary>
        /// The modified.
        /// </summary>
        Modified, 

        /// <summary>
        /// The deleted.
        /// </summary>
        Deleted
    }
}