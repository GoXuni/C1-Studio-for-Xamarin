using FlexChart101.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using C1.Xamarin.Forms.Chart;
using C1.Xamarin.Forms.Core;
using C1.Xamarin.Forms.Chart.Interaction;

namespace FlexChart101
{
    public partial class ZoomingAndScrolling 
    {
        Random rnd = new Random();
        public ZoomingAndScrolling()
        {
            InitializeComponent();

			Title = AppResources.ZoomingScrollingTitle;
			this.lblZoomMode.Text = AppResources.ZoomMode;
			this.pickerZoomMode.Title = AppResources.ZoomMode;
			this.flexChart.ItemsSource = GenerateRandNormal(500);
            this.flexChart.Palette = C1.Xamarin.Forms.Chart.Palette.Superhero; 
            this.flexChart.Header = AppResources.ScrollZoomInstructions;
			this.flexChart.AxisY.Format = "n2";
            this.flexChart.LegendPosition = ChartPositionType.Bottom;

			//disable tooltip on android
			//Device.OnPlatform(Android: () => this.flexChart.ToolTip = null);
            ZoomBehavior z = new ZoomBehavior();
            z.ZoomMode = GestureMode.X;
            flexChart.Behaviors.Add(z);

            TranslateBehavior t = new TranslateBehavior();
			flexChart.Behaviors.Add(t);

			foreach (var item in Enum.GetNames(typeof(GestureMode)))
			{
				this.pickerZoomMode.Items.Add(item);
			}
			this.pickerZoomMode.SelectedIndex = 2;
		}

		// generates normally distributed random numbers
		List<Point> GenerateRandNormal(int n)
		{
			if (n % 2 == 1)
				n++;

			List<Point> points = new List<Point>(n);

			for (int i = 0; i < n / 2; i++)
			{
				do
				{
					double u = 2 * rnd.NextDouble() - 1;
					double v = 2 * rnd.NextDouble() - 1;

					double s = u * u + v * v;

					if (s < 1)
					{
						s = Math.Sqrt(-2 * Math.Log(s) / s);
						points.Add(new Point(i, u * s));
						points.Add(new Point(i + 1, v * s));
						break;
					}
				} while (true);
			}

			return points;
		}


		void pickerZoomMode_SelectedIndexChanged(object sender, EventArgs e)
		{
            ZoomBehavior z = (ZoomBehavior)flexChart.Behaviors[0];
            z.ZoomMode = (GestureMode)Enum.Parse(typeof(GestureMode), this.pickerZoomMode.Items[this.pickerZoomMode.SelectedIndex]);
		}
    }
}
