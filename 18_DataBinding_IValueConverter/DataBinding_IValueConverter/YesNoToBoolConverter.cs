using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DataBinding_IValueConverter
{
    class YesNoToBoolConverter : IValueConverter
    {
        // 소스 값이 타겟에 바인딩 되는 경우 호출
        // TextBox --> TextBlock, TextBox --> CheckBox
        // TextBox의 Text속성의 값 "YES", "NO"에 따라 true, false를 리턴
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch(value.ToString()!.ToUpper())
            {
                case "YES": return true;
                case "NO": return false;
            }
            return false;
        }

        // 타켓값이 역으로 소스에 바인딩 될때 호출
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is not null)
            {
                if ((bool)value!)
                    return "YES";
            }

            return "NO";
        }
    }
}
