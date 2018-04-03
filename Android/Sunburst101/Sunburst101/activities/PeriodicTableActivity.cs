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
using C1.Android.Chart.Interaction;
using Android.Content.Res;
using Android.Util;

namespace Sunburst101
{
    [Activity(Label = "@string/periodictable", MainLauncher = false, Icon = "@drawable/Selection")]
    public class PeriodicTableActivity : AppCompatActivity
    {
        private C1Sunburst sunburst;
        double _x, _y, _width, _height = 0;
        View _view;

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

            TranslateBehavior t = new TranslateBehavior();
            sunburst.Behaviors.Add(t);
            ZoomBehavior z = new ZoomBehavior();
            sunburst.Behaviors.Add(z);
            Resources resources = BaseContext.Resources;
            DisplayMetrics metrics = resources.DisplayMetrics;

            sunburst.TranslateCustomViews += (object sender, EventArgs e) =>
            {
                if (_view != null)
                {
                    _view.Visibility = ViewStates.Invisible;
                    _view.SetX((int)(_x + sunburst.TranslationX));
                    _view.SetY((int)(_y + sunburst.TranslationY));

                    if (sunburst.Scale != 1)
                    {
                        if (_view.Parent != null)
                        {
                            _view.ScaleX = (float)sunburst.Scale;
                            _view.ScaleY = (float)sunburst.Scale;
                        }
                    }
                    _view.Visibility = ViewStates.Visible;
                }
            };

        }


        private void Sunburst_Tapped(object sender, C1.Android.Core.C1TappedEventArgs e)
        {
            C1Point p = e.GetPosition(sunburst);
            ChartHitTestInfo hitTestInfo = this.sunburst.HitTest(p);
            if (_view != null)
                _view.Visibility = ViewStates.Invisible;
            if (hitTestInfo == null || hitTestInfo.Item == null)
                return;

            if (hitTestInfo.Item is IChartModel)
            {
                View view = ((IChartModel)hitTestInfo.Item).GetUserView(this);

                _view = view;

                Rect myViewRect = new Rect();
                sunburst.GetGlobalVisibleRect(myViewRect);
                double length = myViewRect.Width() < myViewRect.Height() ? myViewRect.Width() : myViewRect.Height();
                length = length * sunburst.InnerRadius / 1.2; // 1.2 is proper size between 1 and 1.414(Math.Sqrt(2));

                int x = (int)(myViewRect.CenterX() - length / 2);
                int y = (int)(myViewRect.CenterY() - length);

                if (view.Parent != null)
                {
                    ((ViewGroup)view.Parent).RemoveView(view);
                }
                if (view.Parent == null)
                {
                    ViewGroup.LayoutParams para = new ViewGroup.LayoutParams((int)length, (int)length);
                    sunburst.AddView(view, para);
                }
                _view.SetX((int)(x + sunburst.TranslationX));
                _view.SetY((int)(y + sunburst.TranslationY));
                _view.ScaleX = (float)sunburst.Scale;
                _view.ScaleY = (float)sunburst.Scale;

                _view.Visibility = ViewStates.Visible;
                _x = x;
                _y = y;
                _width = _height = length;
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