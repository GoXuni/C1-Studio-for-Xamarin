using System;
using Xamarin.Forms;
using C1.Xamarin.Forms.Chart;
using Sunburst101.Resources;
using Sunburst101.Periodic;

namespace Sunburst101
{
    public partial class PeriodicTable
    {
        private static float fontSizeRate = 0.5f;
        private Rectangle innerRect;
        
        public PeriodicTable()
        {
            InitializeComponent();
            Title = AppResources.PeriodicTableTitle;
            
            this.sunburst.ItemsSource = Data.Groups;
            this.sunburst.Tapped += Sunburst_Tapped;
            this.sunburst.Rendering += Sunburst_Rendering;
        }

        private void Sunburst_Rendering(object sender, RenderEventArgs e)
        {
            double centerX = this.sunburst.X + this.sunburst.Width / 2;
            double centerY = this.sunburst.Y + this.sunburst.Height / 2;
            double length = sunburst.Width < sunburst.Height ? sunburst.Width : sunburst.Height;
            fontSizeRate = (float)(length / 700); // To regulate the font size to adjust the size of control.
            this.sunburst.DataLabel.Style.FontSize = 12 * fontSizeRate;

            length = length * sunburst.InnerRadius / 1.414; // 1.414 ~= Math.Sqrt(2);
            innerRect = new Rectangle(centerX - length / 2, centerY - length / 2, length, length);
        }

        private void Sunburst_Tapped(object sender, C1.Xamarin.Forms.Core.C1TappedEventArgs e)
        {
            Point p = e.GetPosition(sunburst);
            ChartHitTestInfo hitTestInfo = this.sunburst.HitTest(p);
            if (hitTestInfo == null || hitTestInfo.Item == null)
                return;
            
            if (Periodic.Group.layout != null) {
                 this.sunburst.Children.Remove(Periodic.Group.layout);
            }
            if (Periodic.SubGroup.layout != null)
            {
                this.sunburst.Children.Remove(Periodic.SubGroup.layout);
            }
            if (Periodic.Element.layout != null)
            {
                this.sunburst.Children.Remove(Periodic.Element.layout);
            }
            
            if (hitTestInfo.Item is IChartModel)
            {
                View view = ((IChartModel)hitTestInfo.Item).GetUserView(fontSizeRate);
                view.BackgroundColor = Color.Transparent;
                this.sunburst.Children.Add(view);
                this.sunburst.RaiseChild(view);
                
                view.Layout(innerRect);
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
