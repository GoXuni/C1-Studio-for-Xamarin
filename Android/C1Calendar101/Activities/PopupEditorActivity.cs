using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using C1.Android.Calendar;
using System;
using System.Linq;
using System.Threading.Tasks;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace C1Calendar101
{
    [Activity(Label = "@string/popup_editor", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class PopupEditorActivity : AppCompatActivity
    {

        private TextView _message;
        private Button _pickDateButton;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.PopupEditor);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.popup_editor);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

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
                string txt = Resources.GetText(Resource.String.showSelectedDate);
                _message.Text = string.Format(txt, date);
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
        public override void OnResume()
        {
            Window window = Dialog.Window;
            Point size = new Point();
            // Store dimensions of the screen in `size`
            Display display = window.WindowManager.DefaultDisplay;
            display.GetSize(size);
            // Set the width of the dialog proportional to 80% of the screen width
            window.SetLayout((int)(size.X * 0.8), (int)(size.Y * 0.8));
            window.SetGravity(GravityFlags.Center);

            base.OnResume();
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
            
            SetTitle(Resource.String.selectDate);
        }
        private void OnSelectionChanged(object sender, CalendarSelectionChangedEventArgs e)
        {
            SelectedDate = e.SelectedDates.FirstOrDefault();
            Dismiss();
        }
    }
}