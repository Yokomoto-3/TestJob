using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace TestJob
{
    public class StringToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string input;
            try
            {
                DataGridCell dgc = (DataGridCell)value;
                System.Data.DataRowView rowView = (System.Data.DataRowView)dgc.DataContext;
                input = ((TestJob.MatrixElement)rowView.Row.ItemArray[dgc.Column.DisplayIndex]).Marker;
            }
            catch (InvalidCastException)
            {
                return DependencyProperty.UnsetValue;
            }
            return input switch
            {
                "Yellow" => Brushes.Yellow,
                "Green" => Brushes.Green,
                "Blue" => Brushes.Blue,
                _ => Brushes.LightGray,
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
