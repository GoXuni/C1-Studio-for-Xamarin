using System.Threading.Tasks;
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
            Viewer.DocumentOpening += Viewer_DocumentOpening;
            Viewer.DocumentSaving += Viewer_DocumentSaving;

            NavigationController.InteractivePopGestureRecognizer.Enabled = false;
        }

        private void Viewer_DocumentSaving(object sender, C1.iOS.Viewer.SaveDocumentStreamEventArgs e)
        {
            var deferral = e.GetDeferral();
            try
            {
                e.FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "export.png");
                e.PageRange = new GrapeCity.Documents.Common.OutputRange(1, 2);
            }
            finally
            {
                deferral.Complete();
            }
        }

        private async void Viewer_DocumentOpening(object sender, C1.iOS.Viewer.DocumentStreamEventArgs e)
        {
            var deferral = e.GetDeferral();
            try
            {
                e.Stream = await PickFile(e.AllowedTypes);
            }
            finally
            {
                deferral.Complete();
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            Viewer.RemoveFromSuperview();
            ReleaseDesignerOutlets();
        }
        async partial void UIBarButtonItem3137_Activated()
        {
            var stream = await PickFile(new string[] { "com.adobe.pdf" });
            if (stream != null)
            {
                Viewer.LoadDocument(stream);
            }
        }

        private async Task<Stream> PickFile(string[] allowedTypes)
        {
            Stream stream = null;
            try
            {
                FileData fileData = await CrossFilePicker.Current.PickFile(allowedTypes);
                if (fileData == null)
                    return null; // user canceled file picking

                stream = fileData.GetStream();
                return stream;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception choosing file: " + ex.ToString());
                return null;
            }
        }

    }
}