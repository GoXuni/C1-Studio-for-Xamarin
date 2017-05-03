using Foundation;
using System;
using System.Linq;
using System.Collections.Generic;
using UIKit;
using C1.iOS.Gauge;
using C1.iOS.Core;

namespace C1Gauge101
{
    public partial class DirectionViewController : UIViewController
    {
        private const string DirectionTitleKey = "Direction";

        private IList<string> directionItems = new List<string>() {
            LinearGaugeDirection.Right.ToString(),
            LinearGaugeDirection.Left.ToString(),
            LinearGaugeDirection.Up.ToString(),
            LinearGaugeDirection.Down.ToString()
        };

        public IList<string> DirectionItems
        {
            get
            {
                return directionItems;
            }
        }

        public DirectionViewController (IntPtr handle) : base (handle)
        {
        }

        public override void UpdateViewConstraints()
        {
            if (StackView.Axis == UILayoutConstraintAxis.Horizontal)
            {
                StackViewHeightContraint.Constant = StackView.Superview.Frame.Size.Height;
            }
            else
            {
                StackViewHeightContraint.Constant = 208;
            }
            base.UpdateViewConstraints();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            NavigationItem.Title = DirectionTitleKey.Localize();

            var localizedItems = new List<string>();
            DirectionItems.ToList().ForEach(x => localizedItems.Add(x.Localize()));
            
            Entry.ToPickerWithValues(localizedItems, 0, (selectedIndex) =>
            {
                var direction = (LinearGaugeDirection)Enum.Parse(typeof(LinearGaugeDirection), DirectionItems[selectedIndex]);
                LinearGauge.Direction = BulletGraph.Direction = direction;
                if (direction == LinearGaugeDirection.Left || direction == LinearGaugeDirection.Right)
                {
                    StackView.Axis = UILayoutConstraintAxis.Vertical;
                    View.SetNeedsUpdateConstraints();
                }
                else
                {
                    StackView.Axis = UILayoutConstraintAxis.Horizontal;
                    View.SetNeedsUpdateConstraints();
                }
            });
        }
    }
}