#region Copyright

// Copyright 2019 - Michael Duncan (MD)
// This document contains unpublished source code of
// MD.  This notice does not indicate any intention to
// publish the source code contained herein.

#endregion

#region Usings

using System.Windows;
using System.Windows.Controls;
using MickyD.AreaCalculator.Contracts;

#endregion

namespace MickyD.AreaCalculator.Views
{
    /// <summary>
    ///     Interaction logic for CircleControl.xaml
    /// </summary>
    public partial class CircleControl : UserControl
    {
        #region Static fields

        public static readonly DependencyProperty RadiusProperty =
            DependencyProperty.Register("Radius",
                                        typeof(float),
                                        typeof(CircleControl),
                                        new PropertyMetadata(default(float), OnRadiusPropertyChanged));

        private static void OnRadiusPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CircleControl) d).CalculateArea();
        }

        private void CalculateArea()
        {
            if (Circle == null)
                return;

            Circle.Radius   = Radius;
        }

        public static readonly DependencyProperty CircleProperty =
            DependencyProperty.Register("Circle",
                                        typeof(ICircle),
                                        typeof(CircleControl),
                                        new PropertyMetadata(default(ICircle), OnCirclePropertyChanged));

        private static void OnCirclePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CircleControl) d).OnCircleChanged(e.NewValue as ICircle);
        }

        private void OnCircleChanged(ICircle newValue)
        {
            newValue?.Reset();
            Radius = 0;
        }

        #endregion

        #region Constructors

        public CircleControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public ICircle Circle
        {
            get { return (ICircle) GetValue(CircleProperty); }
            set { SetValue(CircleProperty, value); }
        }

        public float Radius
        {
            get { return (float) GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }

        #endregion
    }
}