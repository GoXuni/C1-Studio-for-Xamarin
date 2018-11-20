using Foundation;
using System;
using UIKit;
using C1.iOS.Calendar;

namespace C1Calendar101
{
    public partial class CustomDayController : UIViewController
    {
        public CustomDayController(IntPtr handle) : base(handle)
        {
        }

        public override void LoadView()
        {
            base.LoadView();
            Calendar.DaySlotLoading += OnDaySlotLoading;
            Calendar.Refresh();
        }

        public override void WillAnimateRotation(UIInterfaceOrientation toInterfaceOrientation, double duration)
        {
            base.WillAnimateRotation(toInterfaceOrientation, duration);
            Calendar.Refresh();
        }

        private void OnDaySlotLoading(object sender, CalendarDaySlotLoadingEventArgs e)
        {
            // add weather image for certain days in the current month
            var today = DateTime.Today;
            if (e.Date.Year == today.Year &&
                e.Date.Month == today.Month &&
                e.Date.Day >= 14 && e.Date.Day <= 23)
            {
                var iv = new UIImageView();
                var tv = new UILabel();
                var slot = new UIStackView(new UIView[] { tv, iv });
                slot.Axis = InterfaceOrientation == UIInterfaceOrientation.Portrait || InterfaceOrientation == UIInterfaceOrientation.PortraitUpsideDown ? UILayoutConstraintAxis.Vertical : UILayoutConstraintAxis.Horizontal;

                tv.Text = e.Date.Day.ToString();

                UIImage image;
                switch (e.Date.Day % 5)
                {
                    default:
                    case 0:
                        image = UIImage.FromFile(@"Images/Cloudy.png");
                        break;
                    case 1:
                        image = UIImage.FromFile(@"Images/PartlyCloudy.png");
                        break;
                    case 2:
                        image = UIImage.FromFile(@"Images/Rain.png");
                        break;
                    case 3:
                        image = UIImage.FromFile(@"Images/Storm.png");
                        break;
                    case 4:
                        image = UIImage.FromFile(@"Images/Sun.png");
                        break;

                }
                image = image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                iv.UserInteractionEnabled = true;
                iv.TintColor = UIColor.Black;
                iv.ContentMode = UIViewContentMode.ScaleAspectFit;
                iv.Image = image;
                e.DaySlot = slot;
            }
        }
        public override void DidReceiveMemoryWarning()
        {
            Calendar.RemoveFromSuperview();
            ReleaseDesignerOutlets();
            base.DidReceiveMemoryWarning();
        }
    }
}