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
    ///     Interaction logic for TriangleView.xaml
    /// </summary>
    public partial class TriangleControl : UserControl
    {
        #region Static fields

        public static readonly DependencyProperty TriangleProperty =
            DependencyProperty.Register("Triangle",
                                        typeof(ITriangle),
                                        typeof(TriangleControl),
                                        new PropertyMetadata(default(ITriangle), TrianglePropertyChangedCallback));

        public static readonly DependencyProperty AreaProperty =
            DependencyProperty.Register("Area",
                                        typeof(float),
                                        typeof(TriangleControl),
                                        new PropertyMetadata(default(float)));

        public static readonly DependencyProperty BaseProperty =
            DependencyProperty.Register("Base",
                                        typeof(float),
                                        typeof(TriangleControl),
                                        new PropertyMetadata(default(float), OnBaseChanged));

        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.Register("Height",
                                        typeof(float),
                                        typeof(TriangleControl),
                                        new PropertyMetadata(default(float), OnHeightChanged));

        #endregion

        #region Constructors

        public TriangleControl()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public float Area
        {
            get { return (float) GetValue(AreaProperty); }
            set { SetValue(AreaProperty, value); }
        }

        public ITriangle Triangle
        {
            get { return (ITriangle) GetValue(TriangleProperty); }
            set { SetValue(TriangleProperty, value); }
        }

        public float TriangleBase
        {
            get { return (float) GetValue(BaseProperty); }
            set { SetValue(BaseProperty, value); }
        }

        public float TriangleHeight
        {
            get { return (float) GetValue(HeightProperty); }
            set { SetValue(HeightProperty, value); }
        }

        #endregion

        #region Methods

        private void CalculateArea()
        {
            if (Triangle == null)
                return;

            Triangle.Base = TriangleBase;
            Triangle.Height = TriangleHeight;
            Area = Triangle?.Area ?? 0;
        }

        private void OnTriangleChanged(ITriangle newValue)
        {
            newValue?.Reset();
            TriangleBase = TriangleHeight = Area = 0;
        }

        #endregion

        #region Statics

        private static void OnBaseChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((TriangleControl) d).CalculateArea();
        }

        private static void OnHeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((TriangleControl) d).CalculateArea();
        }

        private static void TrianglePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var view = d as TriangleControl;
            view.OnTriangleChanged(e.NewValue as ITriangle);
        }

        #endregion
    }
}