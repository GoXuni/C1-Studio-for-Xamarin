using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;
using System.Linq;
using System.Threading.Tasks;
using C1.Android.Calendar;

namespace C1Calendar101
{
    [Activity(Label = "PopupEditor", Icon = "@drawable/icon", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class PopupEditorActivity : Activity
    {
        private TextView _message;
        private Button _pickDateButton;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            ActionBar.SetDisplayHomeAsUpEnabled(true);

            SetContentView(Resource.Layout.PopupEditor);
            _message = FindViewById<TextView>(Resource.Id.Message);
            _pickDateButton = FindViewById<Button>(Resource.Id.PickDateButton);
            _pickDateButton.Click += OnPickDateClicked;
        }

        private async void OnPickDateClicked(object sender, EventArgs e)
        {
            try
            {
                var fragment = new CalendarDialogFragment();
                var date = await fragment.ShowAsync(FragmentManager);
                _message.Text = string.Format("The date {0:d} was selected.", date);
            }
            catch (System.OperationCanceledException)
            {
                _message.Text = "";
            }
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

    public class CalendarDialogFragment : DialogFragment
    {
        private TaskCompletionSource<DateTime> _tcs = new TaskCompletionSource<DateTime>();
        private CalendarDialog _dialog;

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            _dialog = new CalendarDialog(Activity);
            return _dialog;
        }

        public async Task<DateTime> ShowAsync(FragmentManager fragmentManager)
        {
            _tcs = new TaskCompletionSource<DateTime>();
            Show(fragmentManager, "calendar");
            return await _tcs.Task;
        }

        public override void OnDismiss(IDialogInterface dialog)
        {
            if (_dialog.SelectedDate.HasValue)
                _tcs.TrySetResult(_dialog.SelectedDate.Value);
            else
                _tcs.TrySetCanceled();
        }

        public override void OnCancel(IDialogInterface dialog)
        {
            _tcs.TrySetCanceled();
        }
    }

    public class CalendarDialog : Dialog
    {
        public CalendarDialog(Context context)
            : base(context)
        {

        }

        public DateTime? SelectedDate { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            var calendar = new C1Calendar(Context);
            calendar.SelectionChanged += OnSelectionChanged;
            SetContentView(calendar);
            SetTitle("Pick a date");
        }

        private void OnSelectionChanged(object sender, CalendarSelectionChangedEventArgs e)
        {
            SelectedDate = e.SelectedDates.FirstOrDefault();
            Dismiss();
        }
    }
}