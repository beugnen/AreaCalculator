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
    internal class CircleAreaCalculator:IAreaCalculator<CircleShape>
    {
        public float CalculateArea(CircleShape circle)
        {
            return (float) (Math.PI * circle.Radius * circle.Radius);
        }
    }
}