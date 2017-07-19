using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using C1Input101.Resources;
using C1.Xamarin.Forms.Calendar;

namespace C1Input101
{
    public partial class DropDownSample
    {
        public DropDownSample()
        {
            InitializeComponent();
            Title = AppResources.DropDownTitle;
            this.calendar.SelectionChanged += CalendarSelectionChanged;
            Action act = () => this.mask.BackgroundColor = Color.Transparent;
            Device.OnPlatform(iOS: act, WinPhone: act);

        }
        private void CalendarSelectionChanged(object sender, CalendarSelectionChangedEventArgs e)
        {
            C1Calendar calendar = (C1Calendar)sender;
            this.mask.Value = ((DateTime)calendar.SelectedDate).ToString("MM/dd/yyyy");
            this.dropdown.IsDropDownOpen = false;
        }
    }
}
