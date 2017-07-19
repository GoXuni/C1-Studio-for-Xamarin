using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FlexChart101.DataModel;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FlexChart101
{
    public class BaseActivity : Activity
    {
        protected IList<object> dataSource;
        protected const string DATA_SOURCE = "DATA_SOURCE";
        protected override void OnSaveInstanceState(Bundle outState)
        {
            //outState.PutSerializable(DATA_SOURCE, dataSource);
            base.OnSaveInstanceState(outState);
        }
    }
}
