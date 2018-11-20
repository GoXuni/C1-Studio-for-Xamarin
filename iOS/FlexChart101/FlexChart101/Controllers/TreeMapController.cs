using System;
using System.Collections.Generic;
using UIKit;
using CoreGraphics;
using C1.iOS.Chart;
using CoreText;

namespace FlexChart101
{

    public partial class TreeMapController : UIViewController
	{
        C1TreeMap treeMap;

        public TreeMapController() : base("AnnotationController", null)
		{
		}

        public TreeMapController(IntPtr handle) : base(handle)
		{ 
			
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
            treeMap = new C1TreeMap();
            treeMap.ChartType = C1.iOS.Chart.TreeMapType.Squarified;
            treeMap.Binding = "sales";
            treeMap.BindingName = "type";
            treeMap.MaxDepth = 2;
            treeMap.ChildItemsPath = "items";
            treeMap.ItemsSource = SalesData.CreateHierarchicalData();
            this.Add(treeMap);

            treeMap.DataLabel = new ChartDataLabel() {Content="{}{type}",Position = ChartLabelPosition.Center };
            treeMap.DataLabel.Style.FontSize = 10;
		}


		public override void ViewDidLayoutSubviews()
		{
			base.ViewDidLayoutSubviews();
			treeMap.Frame = new CGRect(this.View.Frame.X, this.View.Frame.Y + 80,
									 this.View.Frame.Width, this.View.Frame.Height - 80);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

