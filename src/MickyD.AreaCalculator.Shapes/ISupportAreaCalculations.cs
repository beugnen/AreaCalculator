#region Copyright

// Copyright 2019 - Michael Duncan (MD)
// This document contains unpublished source code of
// MD.  This notice does not indicate any intention to
// publish the source code contained herein.

#endregion

using MickyD.AreaCalculator.Contracts;

namespace MickyD.AreaCalculator.Shapes
{
    public interface ISupportAreaCalculations<T>
        where T : class, IShape
    {
        IAreaCalculator<T> Calculator { get; }
    }
}