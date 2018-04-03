using FlexGrid101.iOS;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ContentPage), typeof(ContentPageRenderer))]
namespace FlexGrid101.iOS
{
    class ContentPageRenderer : PageRenderer
    {
        public override void ViewWillAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            this.ViewController.NavigationController.InteractivePopGestureRecognizer.Enabled = false;
        }
    }
}
