// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using AppKit;
using C1.Mac.CollectionView;

namespace C1CollectionView101
{
	public partial class GettingStartedViewController : NSViewController
	{
		public GettingStartedViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TableView.SetItemsSource(Customer.GetCustomerList(1000));
        }
	}
}