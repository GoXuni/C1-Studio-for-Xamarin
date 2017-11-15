using C1Calendar101.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using C1.Xamarin.Forms.Calendar;

namespace C1Calendar101
{
    public partial class CustomSelection
    {
        public CustomSelection()
        {
            InitializeComponent();
            Title = AppResources.CustomSelectionTitle;
        }

        private void OnSelectionChanging(object sender, CalendarSelectionChangingEventArgs e)
        {
            foreach (var date in e.SelectedDates.ToArray())
            {
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                    e.SelectedDates.Remove(date);
            }
        }

        public string CustomSelectionMessage
        {
            get
            {
                return AppResources.CustomSelectionMessage;
            }
        }
    }
}
