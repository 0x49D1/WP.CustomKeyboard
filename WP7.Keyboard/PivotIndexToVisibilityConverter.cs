using System;
using System.Windows;
using System.Windows.Data;

namespace WP7.Keyboard
{
    public class PivotIndexToVisibilityConverter : IValueConverter
    {
        public object Convert( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
        {
            int index = (int)value;
            return index == 0 ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture )
        {
            Visibility visibility = ( Visibility )value;
            return visibility == Visibility.Visible ? 0 : 1;
        }
    }
}
