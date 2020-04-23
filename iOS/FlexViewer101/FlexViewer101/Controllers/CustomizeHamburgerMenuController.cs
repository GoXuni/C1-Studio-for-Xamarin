using C1.iOS.Core;
using C1.iOS.Viewer;
using Foundation;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using UIKit;

namespace FlexViewer101
{
    public partial class CustomizeHamburgerMenuController : UIViewController
    {
        public CustomizeHamburgerMenuController(IntPtr handle) : base(handle)
        {
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

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

            Viewer.MenuItems.Add(new MenuItem(NSBundle.MainBundle.GetLocalizedString("ExportToBitmap", ""), new C1PathIcon() { Data = @"M12,1L8,5H11V14H13V5H16M18,23H6C4.89,23 4,22.1 4,21V9A2,2 0 0,1 6,7H9V9H6V21H18V9H15V7H18A2,2 0 0,1 20,9V21A2,2 0 0,1 18,23Z" }, new ExportToBmpCommand(Viewer)));
            Viewer.MenuItems.Add(new MenuItem("New Menu", new C1PathIcon() { Data = @"M6.1,10L4,18V8H21A2,2 0 0,0 19,6H12L10,4H4A2,2 0 0,0 2,6V18A2,2 0 0,0 4,20H19C19.9,20 20.7,19.4 20.9,18.5L23.2,10H6.1M19,18H6L7.6,12H20.6L19,18Z" }, new MyCommand(Viewer)));
            Viewer.MenuItemClicked += FlexViewer_MenuItemClicked;
            Viewer.MenuItems[Viewer.MenuItems.Count - 1].Header = NSBundle.MainBundle.GetLocalizedString("ChangeBackground", "");
            Viewer.DocumentOpening += Viewer_DocumentOpening;
            Viewer.DocumentSaving += Viewer_DocumentSaving;

            NavigationController.InteractivePopGestureRecognizer.Enabled = false;
        }

        private void Viewer_DocumentSaving(object sender, SaveDocumentStreamEventArgs e)
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

        private void FlexViewer_MenuItemClicked(object sender, MenuItemClickedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.ClickedItem.Header);
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            Viewer.RemoveFromSuperview();
            ReleaseDesignerOutlets();
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
    public class MyCommand : ICommand
    {
        private FlexViewer _flexViewer;
        public MyCommand(FlexViewer flexViewer)
        {
            _flexViewer = flexViewer;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _flexViewer.PageBackgroundColor = UIColor.White;
            _flexViewer.BackgroundColor = UIColor.LightGray;
            _flexViewer.PageBorderColor = UIColor.Black;
            _flexViewer.Padding = new UIEdgeInsets(20, 20, 20, 20);
            _flexViewer.PageSpacing = 5;
            _flexViewer.Refresh();
        }
    }

    public class ExportToBmpCommand : ICommand
    {
        private FlexViewer _flexViewer;
        public ExportToBmpCommand(FlexViewer flexViewer)
        {
            _flexViewer = flexViewer;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "export.bmp");
            _flexViewer.SaveAsBmp(filePath);
        }
    }
}