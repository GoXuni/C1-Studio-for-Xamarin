using C1.iOS.Grid;
using Foundation;
using System;
using System.IO;
using UIKit;

namespace FlexGrid101
{
    public partial class ExportController : UIViewController
    {
        private string FILENAME = "ExportedGrid";

        public ExportController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var data = Customer.GetCustomerList(100);
            Grid.ItemsSource = data;
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            Grid.RemoveFromSuperview();
            ReleaseDesignerOutlets();
        }

        partial void UIBarButtonItem34635_Activated(UIBarButtonItem sender)
        {
            UIActionSheet actionSheet = new UIActionSheet("Save As");
            actionSheet.AddButton("CSV");
            actionSheet.AddButton("TXT");
            actionSheet.AddButton("HTML");
            actionSheet.AddButton("Cancel");
            actionSheet.CancelButtonIndex = 3;
            actionSheet.Clicked += delegate (object a, UIButtonEventArgs b)
            {
                string type = null;
                string fullPath = null;
                switch (b.ButtonIndex)
                {
                    case 0:
                        type = "CSV";
                        fullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), FILENAME) + "." + type;
                        Grid.Save(fullPath, GridFileFormat.Csv, System.Text.Encoding.UTF8, GridSaveOptions.SaveColumnHeaders);
                        break;
                    case 1:
                        type = "TXT";
                        fullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), FILENAME) + "." + type;
                        Grid.Save(fullPath, GridFileFormat.Text, System.Text.Encoding.UTF8, GridSaveOptions.SaveColumnHeaders);
                        break;
                    case 2:
                        type = "HTML";
                        fullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), FILENAME) + "." + type;
                        Grid.Save(fullPath, GridFileFormat.Html, System.Text.Encoding.UTF8, GridSaveOptions.SaveColumnHeaders);
                        break;
                }
                if (type != null)
                {
                    var alertController = UIAlertController.Create("Saved", "File has been saved to: " + fullPath, UIAlertControllerStyle.Alert);
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