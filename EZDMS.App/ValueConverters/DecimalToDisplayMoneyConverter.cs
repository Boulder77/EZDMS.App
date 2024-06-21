using System;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Windows;

namespace EZDMS.App
{
    /// <summary>
    /// A converter that takes in a double and converts it to a money field string
    /// </summary>
    public class DecimalToDisplayMoneyConverter : BaseValueConverter<DecimalToDisplayMoneyConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
                      
            // Get the number passed in
            var _decimal = (decimal)value;
                        
            // return as string to money field            
            return (_decimal/100).ToString("#,###.00");
            
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Get the number passed in
            var _decimal = value;

            // return as string to money field            
            return (_decimal);

        }
    }
}
