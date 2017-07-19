using Foundation;
using System;
using UIKit;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using C1.iOS.Core;

namespace C1Input101
{
    public class Sample
    {
        public string Title;
        public string Description;
        public string Image;
        public string StoryboardID;
    }

    partial class MainSampleMenuTableViewController : UITableViewController
    {
        List<Sample> list = null;

        public MainSampleMenuTableViewController(IntPtr handle) : base(handle)
        {
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //XuniLicenseManager.Key = License.Key;
            XmlSerializer readfile = new XmlSerializer(typeof(System.Collections.Generic.List<Sample>));
            using (StringReader reader = new System.IO.StringReader(File.ReadAllText("XuniSampleDescriptor.xml")))
            {
                list = (List<Sample>)readfile.Deserialize(reader);
            }

        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            Sample s = list[indexPath.Row];
            UIKit.UITableViewCell cell = this.TableView.DequeueReusableCell("Cell");
            var localizedString1 = NSBundle.MainBundle.LocalizedString(s.Title, "optional");
            cell.TextLabel.Text = localizedString1;
            cell.TextLabel.TextColor = UIColor.DarkGray;
            var localizedString = NSBundle.MainBundle.LocalizedString(s.Description, "optional");
            cell.DetailTextLabel.Text = localizedString;
            cell.DetailTextLabel.TextColor = UIColor.DarkGray;
            cell.ImageView.Image = new UIImage(s.Image);
            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            string next = list[indexPath.Row].StoryboardID;

            UIStoryboard storyboard = UIStoryboard.FromName("Main", null);
            UIViewController controller = storyboard.InstantiateViewController(next);

            this.NavigationController.PushViewController(controller, true);
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        public override nint RowsInSection(UITableView tableView, nint section)
        {
            return list.Count;
        }
    }
}