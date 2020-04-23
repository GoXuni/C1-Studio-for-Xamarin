using C1.iOS.Viewer;
using System;
using System.IO;
using UIKit;

namespace FlexViewer101
{
    public partial class GettingStartedController : UIViewController
    {
        public GettingStartedController (IntPtr handle) : base (handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Viewer.ShowMenu = false;

            string path = "Data/DefaultDocument.pdf";
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