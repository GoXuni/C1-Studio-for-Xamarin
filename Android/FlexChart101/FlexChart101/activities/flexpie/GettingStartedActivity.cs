using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using C1.Android.Chart;

namespace FlexChart101.Pie
{
    [Activity(Label = "@string/getting_started", MainLauncher = false, Icon = "@drawable/pie")]
    public class GettingStartedActivity : Activity
    {
        private FlexPie mFlexPie1;
        private FlexPie mFlexPie2;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            // setting the dark theme
            // FlexPie automatically adjusts to the current theme
            SetTheme(Android.Resource.Style.ThemeHolo);

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.flexpie_activity_getting_started);

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
    }
}