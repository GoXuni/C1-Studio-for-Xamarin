using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using C1.Android.Input;
using C1.Android.Core;
using Java.Lang;
using Android.Graphics;


namespace C1Input101
{
    [Activity(Label = "@string/basic_mask", Icon = "@drawable/icon")]
    public class MaskActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_basic_mask);
        }
    }
}

