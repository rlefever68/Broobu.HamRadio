using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;

namespace Iris.Contract.Generation.Converters
{
    public class EmptyListToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var enumerable = value as IEnumerable<object>;
            if (value == null)
            {
                return false;
            }
            else
            {
                return enumerable.Count() > 0;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
