#region Copyright

// Copyright 2019 - Michael Duncan (MD)
// This document contains unpublished source code of
// MD.  This notice does not indicate any intention to
// publish the source code contained herein.

#endregion

using MickyD.AreaCalculator.Contracts;

namespace MickyD.AreaCalculator.Shapes
{
    public class CircleShape : ShapeBase<CircleShape>, ICircle
    {
        private static readonly CircleAreaCalculator CircleCalculator = new CircleAreaCalculator();
        private float _radius;

        /// <summary>
        /// Initializes a new instance of the <see cref="CircleShape"/> class.
        /// </summary>
        public CircleShape() : base(CircleCalculator, "Circle")
        {

        }

        public float Radius
        {
            get => _radius;
            set => SetCheckNotify(ref _radius, value);
        }

        protected override void OnReset()
        {
            Radius = 0;
        }
    }
}