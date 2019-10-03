using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using MickyD.AreaCalculator.Contracts;

namespace MickyD.AreaCalculator.Views.Converters
{
    public class ShapeToVisibilityConverter:IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values?.Length < 2 || !(values[0] is IShape) || !(values[1] is string))
                return Visibility.Collapsed;

            var shape = values[0] as IShape;
            var requested = values[1] as string;
            return Equals(shape.Name, requested) ? Visibility.Visible : Visibility.Collapsed;

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
