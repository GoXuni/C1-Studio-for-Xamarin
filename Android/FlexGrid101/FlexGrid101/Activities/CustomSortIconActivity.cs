using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using C1.Android.Core;
using C1.Android.Grid;
using C1.DataCollection;
using System;
using System.Collections.Generic;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexGrid101
{
    [Activity(Label = "@string/CustomSortIcon", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class CustomSortIconActivity : AppCompatActivity
    {
        private FlexGrid grid;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CustomSortIcon);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.CustomSortIcon);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            var positionModes = FindViewById<Spinner>(Resource.Id.SortIconPosition);
            var iconModes = FindViewById<Spinner>(Resource.Id.SortIconTemplate);

            var positionItems = new GridSortIconPosition[] { GridSortIconPosition.Left, GridSortIconPosition.Inline, GridSortIconPosition.Right };
            var positonAdapteritems = new List<string>();
            foreach (var value in Enum.GetValues(typeof(GridSortIconPosition)))
            {
                positonAdapteritems.Add(value.ToString());
            }
            positionModes.Adapter = new ArrayAdapter(BaseContext, global::Android.Resource.Layout.SimpleSpinnerItem, positonAdapteritems);
            positionModes.ItemSelected += (s, e) =>
            {
                grid.SortIconPosition = positionItems[positionModes.SelectedItemPosition];
            };
            positionModes.SetSelection(0, false);
            var iconItems = new C1IconTemplate[] { C1IconTemplate.TriangleNorth, C1IconTemplate.ChevronUp, C1IconTemplate.ArrowUp };
            var iconAdapterItems = new List<string>();
            foreach (var value in new string[] { nameof(C1IconTemplate.TriangleNorth), nameof(C1IconTemplate.ChevronUp), nameof(C1IconTemplate.ArrowUp) })
            {
                iconAdapterItems.Add(value);
            }
            iconModes.Adapter = new ArrayAdapter(BaseContext, global::Android.Resource.Layout.SimpleSpinnerItem, iconAdapterItems);
            iconModes.ItemSelected += (s, e) =>
            {
                grid.SortAscendingIconTemplate = iconItems[iconModes.SelectedItemPosition];
            };
            iconModes.SetSelection(0, false);
            grid = FindViewById<FlexGrid>(Resource.Id.Grid);
            LoadData();
        }
        private async void LoadData()
        {
            var cv = new C1DataCollection<Customer>(Customer.GetCustomerList(100));
            await cv.SortAsync(new SortDescription("FirstName", SortDirection.Ascending), new SortDescription("LastName", SortDirection.Descending));
            grid.ItemsSource = cv;
            grid.SortAscendingIconTemplate = new C1IconTemplate(() => new C1BitmapIcon(this.ApplicationContext) { Source = BitmapFactory.DecodeResource(this.Resources, Resource.Drawable.arrow_up)
        });
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