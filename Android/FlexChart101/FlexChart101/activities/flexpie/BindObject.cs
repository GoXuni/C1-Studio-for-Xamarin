using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;


namespace FlexChart101.Pie
{
    class BindObject : Java.Lang.Object
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public BindObject(string name, int value)
        {
            this.Name = name;
            this.Value = value;
        }

    }
}