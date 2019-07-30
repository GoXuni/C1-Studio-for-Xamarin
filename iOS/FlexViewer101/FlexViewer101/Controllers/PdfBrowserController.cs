
using System;
using System.Drawing;
using System.IO;
using Foundation;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using UIKit;

namespace FlexViewer101.Controllers
{
    public partial class PdfBrowserController : UIViewController
    {
        public PdfBrowserController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            string path = "Data/Simple List.pdf";
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
        async partial void  UIBarButtonItem3137_Activated()
        {
            Stream stream = null;
            try
            {
                FileData fileData = await CrossFilePicker.Current.PickFile();
                if (fileData == null)
                    return; // user canceled file picking

                stream = fileData.GetStream();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception choosing file: " + ex.ToString());
                return;
            }
            Viewer.LoadDocument(stream);
        }
    }
}