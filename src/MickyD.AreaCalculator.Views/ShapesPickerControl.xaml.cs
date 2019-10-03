using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MickyD.AreaCalculator.Contracts;
using MickyD.AreaCalculator.Shapes;

namespace MickyD.AreaCalculator.Views
{
    /// <summary>
    /// Interaction logic for ShapesPickerControl.xaml
    /// </summary>
    public partial class ShapesPickerControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapesPickerControl"/> class.
        /// </summary>
        public ShapesPickerControl()
        {
            InitializeComponent();

            Shapes = new ObservableCollection<IShape> {new TriangleShape(), new CircleShape()};
          //  SelectedShape = Shapes.First();
        }

        public ObservableCollection<IShape> Shapes { get; } 


        public static readonly DependencyProperty SelectedShapeProperty =
            DependencyProperty.Register("SelectedShape",
                                        typeof(IShape),
                                        typeof(ShapesPickerControl),
                                        new PropertyMetadata(default(IShape), OnShapePropertyChanged));

        /// <summary>
        /// Called when shape property changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnShapePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var picker = d as ShapesPickerControl;
            picker?.OnShapeChanged(e.NewValue as IShape);
        }

        private void OnShapeChanged(IShape newValue)
        {
            Trace.TraceInformation($"ShapesPickerControl.OnShapeChanged ({newValue?.GetType()})");
            ShapesCombo.SelectedItem = newValue;
        }


        /// <summary>
        /// Gets or sets the selected shape.
        /// </summary>
        /// <value>
        /// The selected shape.
        /// </value>
        public IShape SelectedShape
        {
            get { return (IShape) GetValue(SelectedShapeProperty); }
            set { SetValue(SelectedShapeProperty, value); }
        }
    }
}
