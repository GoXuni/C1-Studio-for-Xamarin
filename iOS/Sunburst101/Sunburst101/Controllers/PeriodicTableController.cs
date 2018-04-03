using System;

using UIKit;
using CoreGraphics;
using C1.iOS.Chart;
using C1.iOS.Core;
using Sunburst101.Periodic;
using C1.iOS.Chart.Interaction;
namespace Sunburst101
{
    public partial class PeriodicTableController : UIViewController
    {
        C1Sunburst sunburst;
        UIView popup = new UIView();

        public PeriodicTableController() : base("PeriodicTableController", null)
        {
        }
		public PeriodicTableController(IntPtr handle) : base(handle)
        {
		}
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            sunburst = new C1Sunburst();
			sunburst.ShowTooltip = false;
			sunburst.LegendPosition = ChartPositionType.None;
			sunburst.InnerRadius = 0.4;
			sunburst.SelectionMode = ChartSelectionModeType.Point;
			sunburst.Binding = "Value";
			sunburst.BindingName = "GroupName,SubGroupName,Symbol";
			sunburst.ChildItemsPath = "SubGroups,Elements";
			sunburst.ItemsSource = Data.Groups;
			sunburst.DataLabel.Position = PieLabelPosition.Center;
			sunburst.DataLabel.Content = "{}{name}";
			sunburst.DataLabel.Style.FontSize = 6;

			sunburst.Tapped += Sunburst_Tapped;
            this.View.Add(sunburst);
            this.View.Add(popup);
            this.View.BringSubviewToFront(popup);

            ZoomBehavior z = new ZoomBehavior();
            sunburst.Behaviors.Add(z);

            TranslateBehavior t = new TranslateBehavior();
            sunburst.Behaviors.Add(t);

            sunburst.TranslateCustomViews += (object sender, EventArgs e) => 
            {
                if(popup != null)
                {
                    CGAffineTransform scale = CGAffineTransform.MakeScale((nfloat)sunburst.Scale,(nfloat)sunburst.Scale);
                    CGAffineTransform transform = CGAffineTransform.MakeTranslation((nfloat)sunburst.TranslationX, (nfloat)sunburst.TranslationY);
                    popup.Transform = CGAffineTransform.Multiply(scale,transform);
                }
            };
            sunburst.ClipsToBounds = true;
        }

		private void Sunburst_Tapped(object sender, C1TappedEventArgs e)
		{
            CGPoint p = e.GetPosition(sunburst);
			ChartHitTestInfo hitTestInfo = this.sunburst.HitTest(p);
			if (hitTestInfo == null || hitTestInfo.Item == null)
            {
                popup.Hidden = true;
                return;
            }

			if (hitTestInfo.Item is IChartModel)
			{
                UIView view = ((IChartModel)hitTestInfo.Item).GetUserView(popup.Frame);
                view.Frame = new CGRect(0,0,popup.Frame.Width,popup.Frame.Height);
                popup.BackgroundColor = UIColor.Clear;
                foreach (UIView v in popup)
                    v.RemoveFromSuperview();
                popup.AddSubview(view);
				popup.Hidden = false;
			}
		}

		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();

			CGRect rect = new CGRect(this.View.Frame.X, this.View.Frame.Y + 80,
									 this.View.Frame.Width, this.View.Frame.Height - 80);

			sunburst.Frame = new CGRect(rect.X, rect.Y, rect.Width, rect.Height - 10);
            CGRect myViewRect = sunburst.Frame;
            double length = myViewRect.Width < myViewRect.Height ? myViewRect.Width : myViewRect.Height;
            length = length * sunburst.InnerRadius / 1.2; // 1.2 is proper size between 1 and 1.414(Math.Sqrt(2));
            double centerX = myViewRect.X + myViewRect.Width / 2;
            double centerY = myViewRect.Y + myViewRect.Height / 2;
            popup.Frame = new CGRect(centerX - length / 2, centerY - length / 2, length, length);
		}

		public DataSource Data
		{
			get
			{
				return new DataSource();
			}
		}

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }


}

