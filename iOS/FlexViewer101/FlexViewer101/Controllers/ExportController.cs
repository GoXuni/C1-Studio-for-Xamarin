using Foundation;
using System;
using System.IO;
using UIKit;

namespace FlexViewer101
{
    public partial class ExportController : UIViewController
    {
        private string FILENAME = "ExportedPdf";
        public ExportController(IntPtr handle) : base(handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Viewer.ShowMenu = false;

            string path = "Data/AlternatingBackground.pdf";
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
        async partial void UIBarButtonItem3137_Activated()
        {
            UIActionSheet actionSheet = new UIActionSheet(NSBundle.MainBundle.GetLocalizedString("SaveAs", ""));
            actionSheet.AddButton("PDF");
            actionSheet.AddButton("PNG");
            actionSheet.CancelButtonIndex = 3;
            actionSheet.Clicked += delegate (object a, UIButtonEventArgs b)
            {
                string type = null;
                string fullPath = null;
                switch (b.ButtonIndex)
                {
                    case 0:
                        type = "PDF";
                        fullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), FILENAME) + "." + type;
                        Viewer.Save(fullPath);
                        break;
                    case 1:
                        type = "PNG";
                        fullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), FILENAME + "{0}") + "." + type;
                        Viewer.SaveAsPng(fullPath);
                        break;
                }
                if (type != null)
                {
                    var alertController = UIAlertController.Create(NSBundle.MainBundle.GetLocalizedString("Saved", ""), NSBundle.MainBundle.GetLocalizedString("FileSavedTo", "") + fullPath, UIAlertControllerStyle.Alert);
                    alertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

                    if (this.PresentedViewController == null)
                    {
                        this.PresentViewController(alertController, true, null);
                    }
                    else
                    {
                        this.DismissViewController(false, null);
                        this.PresentViewController(alertController, true, null);
                    }
                }
            };
            actionSheet.ShowInView(View);
        }
    }
}