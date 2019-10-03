#region Copyright

// Copyright 2019 - Michael Duncan (MD)
// This document contains unpublished source code of
// MD.  This notice does not indicate any intention to
// publish the source code contained herein.

#endregion

using System;
using MickyD.AreaCalculator.Contracts;

namespace MickyD.AreaCalculator.Shapes
{
    internal class TriangleAreaCalculator : IAreaCalculator<TriangleShape>
    {
        #region Interface impls

        public float CalculateArea(TriangleShape triangle)
        {
            return triangle.Base * triangle.Height / 2;
        }

        #endregion
    }
}