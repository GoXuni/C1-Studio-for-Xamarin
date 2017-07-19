using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;
using C1.Android.Calendar;

namespace C1Calendar101
{
    [Activity(Label = "@string/custom_header", Icon = "@drawable/icon", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
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
            var adapterItems = Resources.GetStringArray(Resource.Array.viewModeSpinnerValues);
            viewModeSpinner.Adapter = new ArrayAdapter(BaseContext, global::Android.Resource.Layout.SimpleListItem1, adapterItems);
            viewModeSpinner.ItemSelected += OnModeChanged;
            calendar.ViewModeChanged += OnViewModeChanged;
            calendar.DisplayDateChanged += OnDisplayDateChanged;

            UpdateMonthLabel();
        }

        private async void OnModeChanged(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            switch (viewModeSpinner.SelectedItemPosition)
            {
                case 0:
                    await calendar.ChangeViewModeAsync(CalendarViewMode.Month);
                    break;
                case 1:
                    await calendar.ChangeViewModeAsync(CalendarViewMode.Year);
                    break;
                case 2:
                    await calendar.ChangeViewModeAsync(CalendarViewMode.Decade);
                    break;
            }
        }

        private async void OnTodayClicked(object sender, System.EventArgs e)
        {
            await calendar.ChangeViewModeAsync(CalendarViewMode.Month, DateTime.Today);
            calendar.SelectedDate = DateTime.Today;
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