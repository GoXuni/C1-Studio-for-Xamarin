using Android.App;
using Android.OS;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Android.Views;
using System.Linq;
using Android.Content.PM;
using C1.Android.Grid;
using C1.CollectionView;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexGrid101
{
    [Activity(Label = "@string/FilterTitle", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class FilterFormActivity : AppCompatActivity
    {
        public FlexGrid Grid { get; set; }
        public ObservableCollection<StringFilter> Filters { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var filtersText = Intent.Extras.GetString("filters");
            Filters = new ObservableCollection<StringFilter>(FilterActivity.GetFiltersFromText(filtersText));

            SetContentView(Resource.Layout.GettingStarted);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.FilterTitle);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            Grid = FindViewById<FlexGrid>(Resource.Id.Grid);
            var operators = new List<FilterOperation>();
            operators.Add(FilterOperation.Contains);
            operators.Add(FilterOperation.StartsWith);
            operators.Add(FilterOperation.EndsWith);
            operators.Add(FilterOperation.EqualText);
            Grid.AutoGeneratingColumn += (s, e) =>
            {
                if (e.Property.Name == "Field")
                {
                    e.Cancel = true;
                }
                if (e.Property.Name == "FieldName")
                {
                    e.Column.IsReadOnly = true;
                    e.Column.Width = GridLength.Auto;
                    e.Column.Header = "Field";
                }
                if (e.Property.Name == "Operation")
                {
                    e.Column.Width = GridLength.Auto;
                    e.Column.DataMap = new GridDataMap() { ItemsSource = operators };
                }
                if (e.Property.Name == "Value")
                {
                    e.Column.Width = GridLength.Star;
                }
            };
            Grid.ItemsSource = Filters;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            var filterMenuItem = menu.Add(0, 0, 0, Resource.String.FilterTitle);
            filterMenuItem.SetShowAsAction(ShowAsAction.Always);
            filterMenuItem.SetIcon(Resource.Drawable.ic_action_save);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == 0)
            {
                Grid.FinishEditing();
                Intent.PutExtra("filters", FilterActivity.GetFilterText(Filters.ToArray()));
                SetResult(Result.Ok, Intent);
                Finish();
            }
            if (item.ItemId == global::Android.Resource.Id.Home)
            {
                Finish();
                return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }

    [DataContract]
    public class StringFilter
    {
        [DataMember(Name = "field")]
        public string Field { get; set; }
        [DataMember(Name = "fieldName")]
        public string FieldName { get; set; }
        [DataMember(Name = "operation")]
        public FilterOperation Operation { get; set; }
        [DataMember(Name = "value")]
        public string Value { get; set; }
    }
}