using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FlexChart101.DataModel;
using C1.Android.Chart;

namespace FlexChart101
{
    [Activity(Label = "@string/financialChart", Icon = "@drawable/icon")]
    public class FinancialChartTypesActivity : Activity
    {

        private Spinner mFinancialTypeSpinner;
        private FlexChart mChart;

        private IList<object> dataSource;
        private const String DATA_SOURCE = "DATA_SOURCE";

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_financial_chart);

            // initializing widgets
            mChart = (FlexChart)FindViewById(Resource.Id.flexchart);
            mFinancialTypeSpinner = (Spinner)FindViewById(Resource.Id.financialTypeSpinner);

            // set the binding for X-axis of FlexChart
            mChart.BindingX="Date";

            // initialize series elements and set the binding to variables of
            // ChartPoint
            ChartSeries series = new ChartSeries();
            series.Chart = mChart;
            series.SeriesName = "Series1";
            series.Binding = "High,Low,Open,Close";

            // add series to list
            mChart.Series.Add(series);

            //if (dataSource == null && savedInstanceState != null)
            //{
            //    dataSource = (IList<object>)savedInstanceState.GetSerializable(DATA_SOURCE);
            //}
            //else
            //{
                dataSource = this.GetList();
            //}
            mChart.ItemsSource=dataSource;
            mChart.AxisY.MajorGridStyle.Fill = Android.Graphics.Color.Argb(20, 50, 50, 50);
            mChart.AxisX.LabelAngle = 90;
            

            // create custom adapter for spinner and initialize with string array
            ArrayAdapter adapter1 = ArrayAdapter.CreateFromResource(this, Resource.Array.financialTypeSpinnerValues, Android.Resource.Layout.SimpleSpinnerItem);
            // Specify the Layout to use when the list of choices appears
            adapter1.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            // Apply the adapter to the spinner
            mFinancialTypeSpinner.Adapter=adapter1;
            mFinancialTypeSpinner.ItemSelected += MFinancialTypeSpinner_ItemSelected;
        }

        private void MFinancialTypeSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            switch (e.Position)
            {
                case 0:
                    mChart.ChartType = ChartType.Candlestick;
                    break;
                case 1:
                    mChart.ChartType = ChartType.HighLowOpenClose;
                    break;
            }
        }

        // a method to create a list of random objects
        private IList<object> GetList()
        {
            IList<object> listdata = new List<object>();

            int n = 16; // number of series elements
                       //Calendar date = Calendar.getInstance();
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                ChartPoint data = new ChartPoint();
                DateTime date = DateTime.Today.AddDays(i);
                data.Date = date;
                if (i > 0)
                    data.Open = ((listdata[i - 1]) as ChartPoint).Close;
                else
                    data.Open = 1000;

                data.High = data.Open + rnd.Next(20);
                data.Low = data.Open - rnd.Next(20);
                data.Close = rnd.Next((int)data.Low, (int)data.High);
                listdata.Add(data);
            }

            return listdata;
        }

    protected override void OnSaveInstanceState(Bundle outState)
    {
        //outState.PutSerializable(DATA_SOURCE, dataSource);
        base.OnSaveInstanceState(outState);
    }
}
}