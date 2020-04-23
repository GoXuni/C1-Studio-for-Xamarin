using C1.DataCollection;
using C1.iOS.Grid;
using Foundation;
using System;
using System.Collections;
using System.Threading.Tasks;
using UIKit;

namespace FlexGrid101
{
    public partial class NewRowController : UIViewController
    {
        public NewRowController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var data = Customer.GetCustomerList(100);
            Grid.AutoGeneratingColumn += (s, e) => { e.Column.MinWidth = 110; e.Column.Width = GridLength.Star; };
            Grid.ItemsSource = new CustomDataCollection<Customer>(data);
            Grid.NewRowPosition = GridNewRowPosition.Top;
            Grid.NewRowPlaceholder = NSBundle.MainBundle.GetLocalizedString("Click here to add a new row", "");
            Grid.AllowDragging = GridAllowDragging.Both;
            Grid.HeadersVisibility = GridHeadersVisibility.All;
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            Grid.RemoveFromSuperview();
            ReleaseDesignerOutlets();
        }
    }

    public class CustomDataCollection<T> : C1DataCollection<T>
        where T : class
    {
        public CustomDataCollection(IEnumerable source)
            : base(source)
        {
        }

        public override async Task<int> InsertAsync(int index, object item)
        {
            await Task.Delay(1000); //simulates a network operation
            return await base.InsertAsync(index, item);
        }

        public override async Task RemoveAsync(int index)
        {
            await Task.Delay(1000); //simulates a network operation
            await base.RemoveAsync(index);
        }

        public override async Task ReplaceAsync(int index, object item)
        {
            await Task.Delay(1000); //simulates a network operation
            await base.ReplaceAsync(index, item);
        }

        public override async Task MoveAsync(int fromIndex, int toIndex)
        {
            await Task.Delay(1000); //simulates a network operation
            await base.MoveAsync(fromIndex, toIndex);
        }
    }
}