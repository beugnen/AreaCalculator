#region Copyright

// Copyright 2019 - Michael Duncan (MD)
// This document contains unpublished source code of
// MD.  This notice does not indicate any intention to
// publish the source code contained herein.

#endregion

using System.Collections.ObjectModel;
using System.Diagnostics;
using MickyD.AreaCalculator.Contracts;
using MickyD.AreaCalculator.Shapes;

namespace MickyD.AreaCalculator.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private IShape _selectedShape;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {

        }

        public IShape SelectedShape
        {
            get => _selectedShape;
            set
            {
                Trace.TraceInformation($"MainViewModel.SelectedShape {value?.GetType()}");
                SetCheckNotify(ref _selectedShape, value);
                _selectedShape?.Reset();
            }
        }
    }

    public class MainDesignTimeViewModel : MainViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainDesignTimeViewModel"/> class.
        /// </summary>
        public MainDesignTimeViewModel()
        {
        }
    }
}