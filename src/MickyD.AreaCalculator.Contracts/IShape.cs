﻿#region Copyright

// Copyright 2019 - Michael Duncan (MD)
// This document contains unpublished source code of
// MD.  This notice does not indicate any intention to
// publish the source code contained herein.

#endregion

namespace MickyD.AreaCalculator.Contracts
{
    public interface IShape
    {
        /// <summary>
        /// Gets the area of the shape.
        /// </summary>
        /// <value>
        /// The area.
        /// </value>
        float Area { get; }

        string Name {get;}
        void Reset();
    }
}