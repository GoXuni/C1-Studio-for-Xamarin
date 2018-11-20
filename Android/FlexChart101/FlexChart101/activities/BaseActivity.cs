using Android.OS;
using Android.Support.V7.App;
using System.Collections.Generic;

namespace FlexChart101
{
    public class BaseActivity : AppCompatActivity
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
