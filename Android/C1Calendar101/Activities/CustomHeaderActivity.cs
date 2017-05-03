using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;
using C1.Android.Calendar;

namespace C1Calendar101
{
    [Activity(Label = "CustomHeader", Icon = "@drawable/icon", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class CustomHeaderActivity : Activity
    {
        private TextView monthLabel;
        private Spinner viewModeSpinner;
        private Button todayButton;
        private C1Calendar calendar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            ActionBar.SetDisplayHomeAsUpEnabled(true);

            SetContentView(Resource.Layout.CustomHeader);
            viewModeSpinner = FindViewById<Spinner>(Resource.Id.ViewModeSpinner);
            todayButton = FindViewById<Button>(Resource.Id.TodayButton);
            calendar = FindViewById<C1Calendar>(Resource.Id.Calendar);
            monthLabel = FindViewById<TextView>(Resource.Id.MonthLabel);

            todayButton.Click += OnTodayClicked;
            var items = new CalendarViewMode[] { CalendarViewMode.Month, CalendarViewMode.Year, CalendarViewMode.Decade };
            viewModeSpinner.Adapter = new ArrayAdapter(BaseContext, global::Android.Resource.Layout.SimpleListItem1, items);
            viewModeSpinner.ItemSelected += OnModeChanged;
            calendar.ViewModeChanged += OnViewModeChanged;
            calendar.DisplayDateChanged += OnDisplayDateChanged;

            UpdateMonthLabel();
        }

        private void OnModeChanged(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            switch (viewModeSpinner.SelectedItemPosition)
            {
                case 0:
                    calendar.ChangeViewModeAsync(CalendarViewMode.Month);
                    break;
                case 1:
                    calendar.ChangeViewModeAsync(CalendarViewMode.Year);
                    break;
                case 2:
                    calendar.ChangeViewModeAsync(CalendarViewMode.Decade);
                    break;
            }
        }

        private void OnTodayClicked(object sender, System.EventArgs e)
        {
            calendar.ChangeViewModeAsync(CalendarViewMode.Month, DateTime.Today);
        }

        private void OnViewModeChanged(object sender, EventArgs e)
        {
            switch (calendar.ViewMode)
            {
                case CalendarViewMode.Month:
                    viewModeSpinner.SetSelection(0);
                    break;
                case CalendarViewMode.Year:
                    viewModeSpinner.SetSelection(1);
                    break;
                case CalendarViewMode.Decade:
                    viewModeSpinner.SetSelection(2);
                    break;
            }
        }

        private void OnDisplayDateChanged(object sender, EventArgs e)
        {
            UpdateMonthLabel();
        }

        private void UpdateMonthLabel()
        {
            monthLabel.Text = calendar.DisplayDate.ToString("Y");
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == global::Android.Resource.Id.Home)
            {
                Finish();
                return true;
            }
            else
            {
                return base.OnOptionsItemSelected(item);
            }
        }
    }
}