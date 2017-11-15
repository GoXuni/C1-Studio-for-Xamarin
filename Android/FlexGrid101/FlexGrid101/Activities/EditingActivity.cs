
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using Java.Util;
using System;
using C1.Android.Grid;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexGrid101
{
    [Activity(Label = "@string/EditingTitle", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class EditingActivity : AppCompatActivity
    {
        private GridCellRange _selectedRange;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GettingStarted);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.EditingTitle);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            Grid = FindViewById<FlexGrid>(Resource.Id.Grid);
            Grid.AutoGeneratingColumn += (s, e) =>
              {
                  if (e.Property.Name != "FirstName" &&
                  e.Property.Name != "LastName" &&
                  e.Property.Name != "LastOrderDate" &&
                  e.Property.Name != "OrderTotal")
                  {
                      e.Cancel = true;
                  }
              };
            Grid.IsReadOnly = true;
            Grid.ItemsSource = Customer.GetCustomerList(100);
            Grid.SelectionChanged += OnSelectionChanged;
            Grid.CellDoubleTapped += OnCellDoubleTapped;
        }

        public FlexGrid Grid { get; set; }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            var editMenuItem = menu.Add(0, 0, 0, Resource.String.EditingTitle);
            editMenuItem.SetShowAsAction(ShowAsAction.Always);
            editMenuItem.SetIcon(Resource.Drawable.ic_edit);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == 0)
            {
                if (_selectedRange != null)
                {
                    OpenEditingDialog();
                }
                else
                {
                    var builder = new Android.App.AlertDialog.Builder(this);
                    builder.SetMessage(Resource.String.EditingSelectRowMessage);
                    builder.SetPositiveButton("OK", new System.EventHandler<Android.Content.DialogClickEventArgs>((s, e) => { }));
                    var alert = builder.Create();
                    alert.Show();
                }

            }
            else if (item.ItemId == global::Android.Resource.Id.Home)
            {
                Finish();
                return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        private void OnCellDoubleTapped(object sender, GridCellRangeEventArgs e)
        {
            if (e.CellType == GridCellType.Cell)
            {
                _selectedRange = e.CellRange;
                OpenEditingDialog();
            }
        }

        private void OnSelectionChanged(object sender, GridCellRangeEventArgs e)
        {
            _selectedRange = e.CellRange;
        }

        private void OpenEditingDialog()
        {
            var customer = Grid.Rows[_selectedRange.Row].DataItem as Customer;
            var builder = new Android.App.AlertDialog.Builder(this);
            builder.SetTitle(Resource.String.EditingTitle);
            var view = LayoutInflater.Inflate(Resource.Layout.EditingForm, null);
            var firstNameTextView = view.FindViewById<EditText>(Resource.Id.FirstName);
            var lastNameTextView = view.FindViewById<EditText>(Resource.Id.LastName);
            var lastOrderTextView = view.FindViewById<EditText>(Resource.Id.LastOrder);
            var orderTotalTextView = view.FindViewById<EditText>(Resource.Id.OrderTotal);
            firstNameTextView.Text = customer.FirstName;
            lastNameTextView.Text = customer.LastName;
            lastOrderTextView.Text = customer.LastOrderDate.ToShortDateString();
            orderTotalTextView.Text = customer.OrderTotal.ToString();
            orderTotalTextView.InputType = Android.Text.InputTypes.NumberFlagDecimal;
            builder.SetView(view);
            builder.SetPositiveButton("OK", new System.EventHandler<Android.Content.DialogClickEventArgs>((s, e) =>
            {
                try
                {
                    customer.FirstName = firstNameTextView.Text;
                    customer.LastName = lastNameTextView.Text;
                    customer.LastOrderDate = DateTime.Parse(lastOrderTextView.Text);
                    customer.OrderTotal = double.Parse(orderTotalTextView.Text);
                }
                catch { }
            }));
            var dialog = builder.Create();
            dialog.Show();
        }
    }
}