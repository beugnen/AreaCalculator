#region Copyright

// Copyright 2019 - Michael Duncan (MD)
// This document contains unpublished source code of
// MD.  This notice does not indicate any intention to
// publish the source code contained herein.

#endregion

#region Usings

using System;
using System.Collections.ObjectModel;
using MickyD.AreaCalculator.Contracts;
using MickyD.AreaCalculator.Shapes;

#endregion

namespace MickyD.AreaCalculator.ViewModels
{
    [Obsolete("This was replaced by dependency properties in code-behind")]
    public class ShapesPickerViewModel : ViewModelBase
    {
        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ShapesPickerViewModel" /> class.
        /// </summary>
        public ShapesPickerViewModel()
        {
            Shapes = new ObservableCollection<IShape> {new TriangleShape(), new CircleShape()};
        }

        #endregion

        #region Properties

        /// <summary>
        ///     The list of shapes available to the user
        /// </summary>
        public ObservableCollection<IShape> Shapes { get; } 


        #endregion
    }
}