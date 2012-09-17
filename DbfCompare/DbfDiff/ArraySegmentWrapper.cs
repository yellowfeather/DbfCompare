// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ArraySegmentWrapper.cs" company="Yellow Feather Ltd">
//   Copyright 2012 Yellow Feather Ltd.
// </copyright>
// <summary>
//   Wraps an ArraySegment to provide enumarator access.
//   Note: This class is not required in .Net 4.5 as the ArraySegment struct implements IEnumerable.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DbfCompare.DbfDiff
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Wraps an ArraySegment to provide enumerator access.
    /// Note: This class is not required in .Net 4.5 as the ArraySegment struct implements IEnumerable.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the elements in the array segment.
    /// </typeparam>
    public struct ArraySegmentWrapper<T> : IEnumerable<T>
    {
        /// <summary>
        /// The segment.
        /// </summary>
        private readonly ArraySegment<T> segment;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArraySegmentWrapper{T}"/> struct.
        /// </summary>
        /// <param name="segment">
        /// The segment.
        /// </param>
        public ArraySegmentWrapper(ArraySegment<T> segment)
        {
            this.segment = segment;
        }

        /// <summary>
        /// The get enumerator.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerator"/>.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.segment.Offset; i < this.segment.Offset + this.segment.Count; i++)
            {
                yield return this.segment.Array[i];
            }
        }

        /// <summary>
        /// The get enumerator.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerator"/>.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}