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
    [Activity(Label = "@string/getting_started", MainLauncher = false, Icon = "@drawable/pie")]
    public class GettingStartedActivity : AppCompatActivity
    {
        private FlexPie mFlexPie1;
        private FlexPie mFlexPie2;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.flexpie_activity_getting_started);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.getting_started);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            // initializing widgets
            mFlexPie1 = (FlexPie)FindViewById(Resource.Id.flexPie);
            mFlexPie2 = (FlexPie)FindViewById(Resource.Id.donutPie);

            // creating a list of fruit objects of type BindObject for first FlexPie
            IList<object> flexpieFruits = new List<object>();
            flexpieFruits.Add(new BindObject("Oranges", 11));
            flexpieFruits.Add(new BindObject("Apples", 94));
            flexpieFruits.Add(new BindObject("Pears", 93));
            flexpieFruits.Add(new BindObject("Bananas", 2));
            flexpieFruits.Add(new BindObject("Pineapples", 53));

            // set the binding of FlexPie to variables of BindObject
            mFlexPie1.BindingName = "Name";
            mFlexPie1.Binding = "Value";

            // setting the source of data/items and default values in FlexPie
            mFlexPie1.ItemsSource = flexpieFruits;
           
            // creating a list of fruit objects of type BindObject for second FlexPie
            IList<object> flexdonutFruits = new List<object>();
            flexdonutFruits.Add(new BindObject("Oranges", 11));
            flexdonutFruits.Add(new BindObject("Apples", 94));
            flexdonutFruits.Add(new BindObject("Pears", 93));
            flexdonutFruits.Add(new BindObject("Bananas", 2));
            flexdonutFruits.Add(new BindObject("Pineapples", 53));

            // set the binding of FlexPie to variables of BindObject
            mFlexPie2.BindingName = "Name";
            mFlexPie2.Binding = "Value";

            // setting the source of data/items and defaulty values in FlexPie
            mFlexPie2.ItemsSource = flexdonutFruits;
            mFlexPie2.InnerRadius = 0.6f;

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