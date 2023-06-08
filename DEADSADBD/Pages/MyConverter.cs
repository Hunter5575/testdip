using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DEADSADBD.Pages
{
    public class MyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(value is string))
                return false;

            bool isChecked = false;
            string status = value.ToString().ToLower();
            if (status == "присутствует")
                isChecked = true;
            

            return isChecked;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
       
            if (value == null || !(value is bool))
                return "Отсутствует";

            return ((bool)value) ? "Присутствует" : "Отсутствует";
        }
    }
}
