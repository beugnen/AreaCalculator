#region Copyright

// Copyright 2019 - Michael Duncan (MD)
// This document contains unpublished source code of
// MD.  This notice does not indicate any intention to
// publish the source code contained herein.

#endregion

#region Usings

using MickyD.AreaCalculator.Contracts;

#endregion

namespace MickyD.AreaCalculator.Shapes
{
    public class TriangleShape : ShapeBase<TriangleShape>, ITriangle
    {
        #region Static fields

        private static readonly TriangleAreaCalculator TriangleCalculator = new TriangleAreaCalculator();
        private float _base;
        private float _height;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="TriangleShape" /> class.
        /// </summary>
        public TriangleShape() : base(TriangleCalculator, "Triangle")
        {
        }

        #endregion

        #region Properties

        public float Base
        {
            get => _base;
            set => SetCheckNotify(ref _base, value);
        }

        public float Height
        {
            get => _height;
            set => SetCheckNotify(ref _height, value);
        }

        #endregion

        protected override void OnReset()
        {
            Base = Height = 0;
        }
    }
}