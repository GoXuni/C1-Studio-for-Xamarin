using System;
using Xamarin.Forms;
using C1.Xamarin.Forms.Chart;
using Sunburst101.Resources;
using Sunburst101.Periodic;
using C1.Xamarin.Forms.Chart.Interaction;
using System.Collections.Generic;

namespace Sunburst101
{
    public partial class PeriodicTable
    {
        private static float fontSizeRate = 0.5f;
        private Rectangle innerRect;
        View _view;
        double _width, _height,_x,_y = 0;
        double _scale = 1;
        IChartModel _item;

        public PeriodicTable()
        {
            InitializeComponent();
            Title = AppResources.PeriodicTableTitle;
            
            this.sunburst.ItemsSource = Data.Groups;
            List<Color> CustomPalette = new List<Color> { Color.FromHex("#f44336"), Color.FromHex("#9c27b0"), Color.FromHex("#3f51b5"), Color.FromHex("#03A9F4"), Color.FromHex("#009688"), Color.FromHex("#8BC34A") };
            sunburst.Palette = Palette.Custom;
            sunburst.CustomPalette = CustomPalette;
            this.sunburst.Tapped += Sunburst_Tapped;
            this.sunburst.Rendering += Sunburst_Rendering;
            TranslateBehavior t = new TranslateBehavior();
            sunburst.Behaviors.Add(t);
            ZoomBehavior z = new ZoomBehavior();
            sunburst.Behaviors.Add(z);

            sunburst.TranslateCustomViews += Sunburst_TranslateCustomViews;
        }

        private void Sunburst_TranslateCustomViews(object sender, EventArgs e)
        {
            if (_view != null)
            {
                C1Sunburst sun = (C1Sunburst)sender;
                if (_scale != sun.Scale)
                {
                    if (_item is Periodic.Group)
                    {
                        ((Periodic.Group)_item).SetFontSize(fontSizeRate * (float)sunburst.Scale);
                    }
                    if (_item is Periodic.SubGroup)
                    {
                        ((Periodic.SubGroup)_item).SetFontSize(fontSizeRate * (float)sunburst.Scale);
                    }
                    if (_item is Periodic.Element)
                    {
                        ((Periodic.Element)_item).SetFontSize(fontSizeRate * (float)sunburst.Scale);
                    }
                    _scale = sun.Scale;
                }
                
                _view.Layout(new Rectangle(_x- _width * sun.Scale/2, _y - _height * sun.Scale/2, _width *sun.Scale, _height * sun.Scale));
                _view.TranslationX = sun.TranslationX;
                _view.TranslationY = sun.TranslationY;
            }
        }

        private void Sunburst_Rendering(object sender, RenderEventArgs e)
        {
            double centerX = this.sunburst.X + this.sunburst.Width / 2;
            double centerY = this.sunburst.Y + this.sunburst.Height / 2;
            double length = sunburst.Width < sunburst.Height ? sunburst.Width : sunburst.Height;
            fontSizeRate = (float)(length / 700); // To regulate the font size to adjust the size of control.
            this.sunburst.DataLabel.Style.FontSize = 12 * fontSizeRate;

            length = length * sunburst.InnerRadius / 1.414; // 1.414 ~= Math.Sqrt(2);
            _width = length;
            _height = length;
            _x = centerX;
            _y = centerY;
        }

        private void Sunburst_Tapped(object sender, C1.Xamarin.Forms.Core.C1TappedEventArgs e)
        {
            Point p = e.GetPosition(sunburst);
            ChartHitTestInfo hitTestInfo = this.sunburst.HitTest(p);
            if (hitTestInfo == null || hitTestInfo.Item == null)
                return;
            _item = ((IChartModel)hitTestInfo.Item);

            if (_view != null && _view.Parent != null)
            {
                sunburst.Children.Remove(_view);
            }

            if (hitTestInfo.Item is IChartModel)
            {
                _view = ((IChartModel)hitTestInfo.Item).GetUserView(fontSizeRate);
                _view.BackgroundColor = Color.Transparent;
                this.sunburst.Children.Add(_view);
                this.sunburst.RaiseChild(_view);

                _view.Layout(new Rectangle(_x - _width * sunburst.Scale / 2, _y - _height * sunburst.Scale / 2, _width * sunburst.Scale, _height * sunburst.Scale));

                if (_item is Periodic.Group && Periodic.Group.layout != null)
                {
                    ((Periodic.Group)_item).SetFontSize(fontSizeRate * (float)sunburst.Scale);
                }
                if (_item is Periodic.SubGroup && Periodic.SubGroup.layout != null)
                {
                    ((Periodic.SubGroup)_item).SetFontSize(fontSizeRate * (float)sunburst.Scale);
                }
                if (_item is Periodic.Element && Periodic.Element.layout != null)
                {
                    ((Periodic.Element)_item).SetFontSize(fontSizeRate * (float)sunburst.Scale);
                }
                if (_view != null)
                {
                    C1Sunburst sun = (C1Sunburst)sender;
                    _view.TranslationX = sun.TranslationX;
                    _view.TranslationY = sun.TranslationY;
                }
            }
        }

        public Sunburst101.Periodic.DataSource Data
        {
            get
            {
                return new Sunburst101.Periodic.DataSource();
            }
        }

    }
}
