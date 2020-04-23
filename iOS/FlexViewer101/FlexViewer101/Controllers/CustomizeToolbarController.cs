using System;
using System.Drawing;
using System.IO;
using C1.iOS.Core;
using Foundation;
using Plugin.FilePicker;
using Plugin.FilePicker.Abstractions;
using UIKit;

namespace FlexViewer101.Controllers
{
    public partial class CustomizeToolbarController : UIViewController
    {
        NSLayoutConstraint showSearchBar;
        UITextField SearchTextBox;
        C1.iOS.Core.C1ToggleButton btnNext, btnPrevious;
        public CustomizeToolbarController(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Viewer.ShowToolbar = false;
            Viewer.ShowMenu = false;

            SearchTextBox = new UITextField();
            btnNext = new C1.iOS.Core.C1ToggleButton();
            btnPrevious = new C1.iOS.Core.C1ToggleButton();

            var nextIcon = C1IconTemplate.ChevronRight.CreateIcon();
            var previousIcon = C1IconTemplate.ChevronLeft.CreateIcon();

            nextIcon.RenderWidth = 20;
            nextIcon.RenderHeight = 20;

            previousIcon.RenderWidth = 20;
            previousIcon.RenderHeight = 20;

            btnPrevious.BackgroundColor = UIColor.Clear;
            btnPrevious.Color = C1ThemeInfo.ApplicationTheme.TextColor;
            btnPrevious.Padding = new UIEdgeInsets(5,5,5,5);
            btnPrevious.CheckedContent = previousIcon;
            btnPrevious.UncheckedContent = previousIcon;
            btnPrevious.Checked += BtnPrevious_Checked;

            btnNext.BackgroundColor = UIColor.Clear;
            btnNext.Color = C1ThemeInfo.ApplicationTheme.TextColor;
            btnNext.Padding = new UIEdgeInsets(5, 5, 5, 5);
            btnNext.CheckedContent = nextIcon;
            btnNext.UncheckedContent = nextIcon;
            btnNext.Checked += BtnNext_Checked;

            showSearchBar = Viewer.TopAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.TopAnchor);
            showSearchBar.Active = true;
            StackLayout.Hidden = true;

            SearchTextBox.ShouldReturn += (textField) =>
            {
                var result = Viewer.SearchText(SearchTextBox.Text, false, false, false);
                if (result.Count > 0)
                {
                    btnNext.Hidden = false;
                    btnPrevious.Hidden = false;
                }
                else
                {
                    btnNext.Hidden = true;
                    btnPrevious.Hidden = true;
                }
                return true;
            };
            SearchTextBox.ShouldClear += (textField) =>
            {
                Viewer.ResetSearch();
                return true;
            };

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

            StackLayout.AddArrangedSubview(SearchTextBox);
            StackLayout.AddArrangedSubview(btnPrevious);
            StackLayout.AddArrangedSubview(btnNext);
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            Viewer.RemoveFromSuperview();
            ReleaseDesignerOutlets();
        }
        private void BtnPrevious_Checked(object sender, EventArgs e)
        {
            Viewer.Previous();
        }

        private void BtnNext_Checked(object sender, EventArgs e)
        {
            Viewer.Next();
        }
        async partial void UIBarButtonItem_OpenFile()
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
        partial void UIBarButtonItem_Search()
        {
            StackLayout.Hidden = !StackLayout.Hidden;
            if (StackLayout.Hidden == true)
            {
                showSearchBar.Active = true;
            }
            else
            {
                showSearchBar.Active = false;
            }
        }
    }
}