using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using C1.Android.Grid;
using C1.CollectionView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexGrid101
{
    [Activity(Label = "@string/FilterTitle", ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class FilterActivity : AppCompatActivity
    {
        private int FilterFormRequest;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.GettingStarted);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.FilterTitle);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            Grid = FindViewById<FlexGrid>(Resource.Id.Grid);
            Grid.ItemsSource = Customer.GetCustomerList(100);
            CurrentFilters = new ObservableCollection<StringFilter>();
            foreach (var column in Grid.Columns)
            {
                if (column.DataType == typeof(string))
                {
                    var stringFilter = new StringFilter();
                    stringFilter.Field = column.Binding;
                    stringFilter.FieldName = column.ActualHeader;
                    stringFilter.Operation = FilterOperation.Contains;
                    CurrentFilters.Add(stringFilter);
                }
            }
        }

        public FlexGrid Grid { get; set; }
        public IList<StringFilter> CurrentFilters { get; set; }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            var filterMenuItem = menu.Add(0, 0, 0, Resource.String.FilterTitle);
            var removeFilterMenuItem = menu.Add(0, 1, 0, Resource.String.RemoveFilter);
            filterMenuItem.SetShowAsAction(ShowAsAction.Always);
            removeFilterMenuItem.SetShowAsAction(ShowAsAction.Always);
            filterMenuItem.SetIcon(Resource.Drawable.ic_filter);
            removeFilterMenuItem.SetIcon(Resource.Drawable.ic_filter_remove);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == 0)
            {
                FilterFormRequest = new Random().Next(65536);
                var filtersText = GetFilterText(CurrentFilters.ToArray());
                var intent = new Intent(BaseContext, typeof(FilterFormActivity));
                intent.PutExtra("filters", filtersText);
                StartActivityForResult(intent, FilterFormRequest);
            }
            else if (item.ItemId == 1)
            {
                foreach (var filter in CurrentFilters)
                {
                    filter.Value = "";
                }
                var task = Grid.CollectionView.RemoveFilterAsync();
            }
            else if (item.ItemId == global::Android.Resource.Id.Home)
            {
                Finish();
                return true;
            }
            return base.OnOptionsItemSelected(item);
        }
        protected override async void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            if (requestCode == FilterFormRequest)
            {
                if (resultCode == Result.Ok)
                {
                    var filters = new List<FilterExpression>();
                    CurrentFilters = GetFiltersFromText(data.Extras.GetString("filters"));
                    foreach (var filter in CurrentFilters)
                    {
                        if (!string.IsNullOrWhiteSpace(filter.Value))
                        {
                            filters.Add(new FilterOperationExpression(filter.Field, filter.Operation, filter.Value));
                        }
                    }
                    await Grid.CollectionView.FilterAsync(FilterExpression.Combine(FilterCombination.And, filters.ToArray()));
                }
            }
            base.OnActivityResult(requestCode, resultCode, data);
        }

        //private IEnumerable<FilterUnaryExpression> GetCurrentFilters(FilterExpression filterExpression)
        //{
        //    var uf = filterExpression as FilterUnaryExpression;
        //    if (uf != null)
        //        yield return uf;
        //    var bf = filterExpression as FilterBinaryExpression;
        //    if (bf != null)
        //    {
        //        foreach (var lf in GetCurrentFilters(bf.LeftExpression))
        //        {
        //            yield return lf;
        //        }
        //        foreach (var rf in GetCurrentFilters(bf.RightExpression))
        //        {
        //            yield return rf;
        //        }
        //    }
        //    yield break;
        //}

        public static string GetFilterText(StringFilter[] filters)
        {
            var serializer = new DataContractJsonSerializer(typeof(StringFilter[]));
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, filters);
                return Encoding.Default.GetString(ms.ToArray());
            }
        }

        public static StringFilter[] GetFiltersFromText(string text)
        {
            var serializer = new DataContractJsonSerializer(typeof(StringFilter[]));
            using (MemoryStream ms = new MemoryStream(Encoding.Default.GetBytes(text)))
            {
                return serializer.ReadObject(ms) as StringFilter[];
            }
        }
    }
}