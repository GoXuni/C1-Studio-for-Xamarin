using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using C1Input101.Resources;

namespace C1Input101
{
    public partial class ComboBoxSample
    {
        public ComboBoxSample()
        {
            InitializeComponent();
            Title = AppResources.ComboBoxTitle;
            var array = Country.GetCountries();
            cbxEdit.ItemsSource = array;
            cbxNoneEdit.ItemsSource = array;

        }
        public string EditableText
        {
            get
            {
                return AppResources.Editable;
            }
        }
        public string NonEditableText
        {
            get
            {
                return AppResources.NonEditable;
            }
        }
    }


    public class DateTimeStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime)
            {
                return ((DateTime)value).ToString("MM/dd/yyyy");
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

}
