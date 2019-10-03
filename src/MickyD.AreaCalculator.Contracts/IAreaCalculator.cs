#region Copyright

// Copyright 2019 - Michael Duncan (MD)
// This document contains unpublished source code of
// MD.  This notice does not indicate any intention to
// publish the source code contained herein.

#endregion

namespace MickyD.AreaCalculator.Contracts
{
    public interface IAreaCalculator<T>
        where T : class, IShape
    {
        float CalculateArea(T shapeBase);
    }
}