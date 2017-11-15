using System;
using Android.App;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using C1.Android.Chart;
using C1.Android.Core;
using Sunburst101.Periodic;
using Android.Graphics;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace Sunburst101
{
    [Activity(Label = "@string/periodictable", MainLauncher = false, Icon = "@drawable/Selection")]
    public class PeriodicTableActivity : AppCompatActivity
    {
        private C1Sunburst sunburst;
        PopupWindow popup = new PopupWindow();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_periodictable);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.periodictable);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            // initializing widgets
            sunburst = (C1Sunburst)FindViewById(Resource.Id.sunburst);
            sunburst.ShowTooltip = false;
            sunburst.LegendPosition = ChartPositionType.None;
            sunburst.InnerRadius = 0.3;
            sunburst.SelectionMode = ChartSelectionModeType.Point;
            sunburst.Binding = "Value";
            sunburst.BindingName = "GroupName,SubGroupName,Symbol";
            sunburst.ChildItemsPath = "SubGroups,Elements";
            sunburst.ItemsSource = Data.Groups;
            sunburst.DataLabel.Position = PieLabelPosition.Center;
            sunburst.DataLabel.Content = "{}{name}";
            sunburst.DataLabel.Style.FontSize = 6;
            
            sunburst.Tapped += Sunburst_Tapped;
            
        }
        

        private void Sunburst_Tapped(object sender, C1.Android.Core.C1TappedEventArgs e)
        {
            C1Point p = e.GetPosition(sunburst);
            ChartHitTestInfo hitTestInfo = this.sunburst.HitTest(p);
            if (hitTestInfo == null || hitTestInfo.Item == null)
                return;
            
            popup.Dismiss();
            
            if (hitTestInfo.Item is IChartModel)
            {
                View view = ((IChartModel)hitTestInfo.Item).GetUserView(this);
               // view.SetBackgroundColor(ColorEx.FromARGB(255, 255, 0, 0));
                popup.ContentView = view;
                
                Rect myViewRect = new Rect();
                sunburst.GetGlobalVisibleRect(myViewRect);
                double length = myViewRect.Width() < myViewRect.Height() ? myViewRect.Width() : myViewRect.Height();
                length = length * sunburst.InnerRadius / 1.2; // 1.2 is proper size between 1 and 1.414(Math.Sqrt(2));
                popup.Width = (int)length;
                popup.Height = (int)length;
                int x = (int)(myViewRect.CenterX() - length / 2);
                int y = (int)(myViewRect.CenterY() - length / 2);
                popup.ShowAtLocation(sunburst, GravityFlags.NoGravity, x, y);
            }
        }
        public DataSource Data
        {
            get
            {
                return new DataSource();
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