
using System;
using System.Drawing;
using System.IO;
using Foundation;
using UIKit;

namespace FlexViewer101.Controllers
{
    public partial class CustomizeAppearanceController : UIViewController
    {
        public CustomizeAppearanceController(IntPtr handle) : base(handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Viewer.ShowMenu = false;
            // Customize Appearance
            Viewer.PageBackgroundColor = UIColor.White;
            Viewer.BackgroundColor = UIColor.LightGray;
            Viewer.PageBorderColor = UIColor.Black;
            Viewer.Padding = new UIEdgeInsets(20, 20, 20, 20);
            Viewer.PageSpacing = 5;

            // Load pdf document
            string path = "Data/PdfViewer.pdf";
            MemoryStream ms = new MemoryStream();
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    byte[] bytes = new byte[fs.Length];
                    fs.Read(bytes, 0, (int)fs.Length);
                    ms.Write(bytes, 0, (int)fs.Length);
                    Viewer.LoadDocument(ms);
                }
            }

            NavigationController.InteractivePopGestureRecognizer.Enabled = false;
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            Viewer.RemoveFromSuperview();
            ReleaseDesignerOutlets();
        }
    }
}