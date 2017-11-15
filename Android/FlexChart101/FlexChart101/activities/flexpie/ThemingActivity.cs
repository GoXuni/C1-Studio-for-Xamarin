using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using C1.Android.Chart;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexChart101.Pie
{
    [Activity(Label = "@string/theming", MainLauncher = false, Icon = "@drawable/themes")]

    public class ThemingActivity : AppCompatActivity
    {
        private Spinner mThemeSpinner;
        private FlexPie mFlexPie;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.flexpie_activity_theming);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.theming);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);


            // initializing widgets
            mFlexPie = (FlexPie)FindViewById(Resource.Id.flexPie);
            mThemeSpinner = (Spinner)FindViewById(Resource.Id.themeSpinner);

            // creating a list of fruit objects of type BindObject
            IList<Object> flexpieFruits = new List<Object>();
            flexpieFruits.Add(new BindObject("Oranges", 11));
            flexpieFruits.Add(new BindObject("Apples", 94));
            flexpieFruits.Add(new BindObject("Pears", 93));
            flexpieFruits.Add(new BindObject("Bananas", 2));
            flexpieFruits.Add(new BindObject("Pineapples", 53));

            // set the binding of FlexPie to variables of BindObject
            mFlexPie.BindingName = "Name";
            mFlexPie.Binding = "Value";

            // setting the source of data/items in FlexPie
            mFlexPie.ItemsSource = flexpieFruits;

            // initializing adapter to string array
            ArrayAdapter adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.theme_spinner_values, Android.Resource.Layout.SimpleSpinnerItem);
            // Specify the layout to use when the list of choices appears
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            // Apply the adapter to the spinner
            mThemeSpinner.Adapter = adapter;
            mThemeSpinner.ItemSelected += mThemeSpinner_ItemSelected;
            
        }

        void mThemeSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            // setting palette based on user selection
            switch (e.Position)
            {
                case 0:
                    mFlexPie.Palette = Palette.Standard;
                    break;
                case 1:
                    mFlexPie.Palette = Palette.Cocoa;
                    break;
                case 2:
                    mFlexPie.Palette = Palette.Coral;
                    break;
                case 3:
                    mFlexPie.Palette = Palette.Dark;
                    break;
                case 4:
                    mFlexPie.Palette = Palette.Highcontrast;
                    break;
                case 5:
                    mFlexPie.Palette = Palette.Light;
                    break;
                case 6:
                    mFlexPie.Palette = Palette.Midnight;
                    break;
                case 7:
                    mFlexPie.Palette = Palette.Minimal;
                    break;
                case 8:
                    mFlexPie.Palette = Palette.Modern;
                    break;
                case 9:
                    mFlexPie.Palette = Palette.Organic;
                    break;
                case 10:
                    mFlexPie.Palette = Palette.Slate;
                    break;
                case 11:
                    mFlexPie.Palette = Palette.Zen;
                    break;
                case 12:
                    mFlexPie.Palette = Palette.Cyborg;
                    break;
                case 13:
                    mFlexPie.Palette = Palette.Superhero;
                    break;
                case 14:
                    mFlexPie.Palette = Palette.Flatly;
                    break;
                case 15:
                    mFlexPie.Palette = Palette.Darkly;
                    break;
                case 16:
                    mFlexPie.Palette = Palette.Cerulean;
                    break;
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
}