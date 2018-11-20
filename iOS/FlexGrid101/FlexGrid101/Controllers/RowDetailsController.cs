using CoreGraphics;
using System;
using UIKit;
using C1.iOS.Grid;

namespace FlexGrid101
{
    public partial class RowDetailsController : UIViewController
    {
        public RowDetailsController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var data = Customer.GetCustomerList(1000);

            Grid.HeadersVisibility = GridHeadersVisibility.All;
            Grid.AutoGenerateColumns = false;
            Grid.Columns.Add(new GridColumn() { Binding = "Id", Width = GridLength.Auto });
            Grid.Columns.Add(new GridColumn() { Binding = "FirstName", Width = GridLength.Star });
            Grid.Columns.Add(new GridColumn() { Binding = "LastName", Width = GridLength.Star });
            var details = new FlexGridDetailProvider();
            details.Attach(Grid);
            details.DetailCellCreating += OnDetailCellCreating;
            details.Height = GridLength.Auto;
            Grid.ItemsSource = data;

        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            Grid.RemoveFromSuperview();
            ReleaseDesignerOutlets();
        }
        private void OnDetailCellCreating(object sender, GridDetailCellCreatingEventArgs e)
        {
            var customer = e.Row.DataItem as Customer;
            e.Content = new DetailView(customer);
        }
    }

    public class DetailView : UIView
    {
        double _spacing = 8;
        UILabel _countryLabel;
        UILabel _cityLabel;
        UILabel _addressLabel;
        UILabel _postalCodeLabel;

        public DetailView(Customer customer)
        {
            _countryLabel = new UILabel { Text = string.Format("Country: {0}", customer.Country) };
            _cityLabel = new UILabel { Text = string.Format("City: {0}", customer.City) };
            _addressLabel = new UILabel { Text = string.Format("Address: {0}", customer.Address) };
            _postalCodeLabel = new UILabel { Text = string.Format("Postal Code: {0}", customer.PostalCode) };
            AddSubviews(_countryLabel, _cityLabel, _addressLabel, _postalCodeLabel);
        }

        public override CGSize IntrinsicContentSize
        {
            get
            {
                var countryLabelSize = _countryLabel.IntrinsicContentSize;
                var cityLabelSize = _cityLabel.IntrinsicContentSize;
                var addressLabelSize = _addressLabel.IntrinsicContentSize;
                var postalCodeLabelSize = _postalCodeLabel.IntrinsicContentSize;

                return new CGSize(_spacing * 2 + Math.Max(countryLabelSize.Width, Math.Max(cityLabelSize.Width, Math.Max(addressLabelSize.Width, postalCodeLabelSize.Width))), _spacing * 5 + countryLabelSize.Height + cityLabelSize.Height + addressLabelSize.Height + postalCodeLabelSize.Height);
            }
        }

        public override CGSize SizeThatFits(CGSize size)
        {
            var widthOffset = _spacing * 2;
            var heightOffset = _spacing * 5;
            var availableSize = new CGSize((size.Width - widthOffset) / Subviews.Length, (size.Height - heightOffset) / Subviews.Length);
            var countrySize = _countryLabel.SizeThatFits(availableSize);
            var citySize = _cityLabel.SizeThatFits(availableSize);
            var addressSize = _addressLabel.SizeThatFits(availableSize);
            var postalCodeSize = _postalCodeLabel.SizeThatFits(availableSize);

            return new CGSize(widthOffset + Math.Max(countrySize.Width, Math.Max(citySize.Width, Math.Max(addressSize.Width, postalCodeSize.Width))), 
                              heightOffset + countrySize.Height + citySize.Height + addressSize.Height + postalCodeSize.Height);
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            var countryLabelSize = _countryLabel.IntrinsicContentSize;
            var cityLabelSize = _cityLabel.IntrinsicContentSize;
            var addressLabelSize = _addressLabel.IntrinsicContentSize;
            var postalCodeLabelSize = _postalCodeLabel.IntrinsicContentSize;

            _countryLabel.Frame = new CGRect(_spacing, _spacing, countryLabelSize.Width, countryLabelSize.Height);
            _cityLabel.Frame = new CGRect(_spacing, _spacing + countryLabelSize.Height + _spacing, cityLabelSize.Width, cityLabelSize.Height);
            _addressLabel.Frame = new CGRect(_spacing, _spacing + countryLabelSize.Height + _spacing + cityLabelSize.Height + _spacing, addressLabelSize.Width, addressLabelSize.Height);
            _postalCodeLabel.Frame = new CGRect(_spacing, _spacing + countryLabelSize.Height + _spacing + cityLabelSize.Height + _spacing + addressLabelSize.Height + _spacing, postalCodeLabelSize.Width, postalCodeLabelSize.Height);
        }
    }
}