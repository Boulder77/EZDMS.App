using System;
using System.Globalization;
using System.Windows;

namespace EZDMS.App
{
    /// <summary>
    /// A converter that takes in a double and converts it to a money field string
    /// </summary>
    public class DoubleToDisplayMoneyConverter : BaseValueConverter<DoubleToDisplayMoneyConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Get the number passed in
            var _double = (double)value;
                        
            // return as string to money field
            
            return ((decimal)_double/100).ToString("#,###.00");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
