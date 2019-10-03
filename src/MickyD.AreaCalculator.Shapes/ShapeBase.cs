#region Copyright

// Copyright 2019 - Michael Duncan (MD)
// This document contains unpublished source code of
// MD.  This notice does not indicate any intention to
// publish the source code contained herein.

#endregion

#region Usings

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MickyD.AreaCalculator.Contracts;
using MickyD.AreaCalculator.Shapes.Annotations;

#endregion

namespace MickyD.AreaCalculator.Shapes
{
    public abstract class ShapeBase<T> : IShape, ISupportAreaCalculations<T>, INotifyPropertyChanged
        where T : class, IShape
    {
        private float _area;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeBase{T}" /> class.
        /// </summary>
        /// <param name="areaCalculator">The area calculator.</param>
        /// <param name="name">The name.</param>
        /// <exception cref="System.ArgumentNullException">areaCalculator</exception>
        protected ShapeBase(IAreaCalculator<T> areaCalculator, string name)
        {
            Calculator = areaCalculator ?? throw new ArgumentNullException(nameof(areaCalculator));
            Name = name;
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Get the instance reference in terms of the concrete type
        /// </summary>
        /// <value>
        ///     The actual.
        /// </value>
        private T Actual => this as T;

        /// <summary>
        ///     Gets the area of the shape.
        /// </summary>
        /// <value>
        ///     The area.
        /// </value>
        public float Area
        {
            get => _area;
            set => SetCheckNotify(ref _area, value);
        }

        public string Name { get; }

        public void Reset()
        {
            OnReset();
        }

        protected abstract void OnReset();

        public IAreaCalculator<T> Calculator { get; }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Sets the check notify.
        /// </summary>
        /// <typeparam name="T">the field type</typeparam>
        /// <param name="field">The field.</param>
        /// <param name="newValue">The new value.</param>
        /// <param name="callerMemberName">Name of the caller member.</param>
        /// <returns></returns>
        protected bool SetCheckNotify<T>(ref T field, T newValue, [CallerMemberName] string callerMemberName = null)
        {
            if (Equals(field, newValue))
                return false;

            field = newValue;
            OnPropertyChanged(callerMemberName);
            if (callerMemberName != "Area") 
                CalculateArea();

            return true;
        }

        private void CalculateArea()
        {
            Area = Calculator.CalculateArea(Actual);
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}