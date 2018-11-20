using C1.Xamarin.Forms.Core;
using C1.Xamarin.Forms.Grid;
using FlexGrid101.Resources;
using Xamarin.Forms;

namespace FlexGrid101
{
    public partial class RowDetails : ContentPage
    {
        private ImageSource _hide;
        private ImageSource _show;

        public RowDetails()
        {
            InitializeComponent();
            _hide = ImageSource.FromResource("FlexGrid101.Images.hide.png", typeof(App));
            _show = ImageSource.FromResource("FlexGrid101.Images.show.png", typeof(App));

            Title = AppResources.RowDetailsTitle;
            lblMode.Text = AppResources.DetailsVisibiltyMode;

            showItemsPicker.Items.Add(GridDetailVisibilityMode.ExpandSingle.ToString());
            showItemsPicker.Items.Add(GridDetailVisibilityMode.ExpandMultiple.ToString());
            showItemsPicker.Items.Add(GridDetailVisibilityMode.Selection.ToString());
            showItemsPicker.SelectedIndex = 1;
            showItemsPicker.SelectedIndexChanged += (s, e) =>
              {
                  switch (showItemsPicker.SelectedIndex)
                  {
                      case 0:
                          details.DetailVisibilityMode = GridDetailVisibilityMode.ExpandSingle;
                          break;
                      case 1:
                          details.DetailVisibilityMode = GridDetailVisibilityMode.ExpandMultiple;
                          break;
                      case 2:
                          details.DetailVisibilityMode = GridDetailVisibilityMode.Selection;
                          break;
                  }
              };

            var data = Customer.GetCustomerList(1000);
            grid.ItemsSource = data;
            grid.MinColumnWidth = 85;

            //details.DetailCollapsedIconTemplate = new C1IconTemplate(() => new C1BitmapIcon() { Source = ImageSource.FromFile("arrow_up.png") });
        }
    }
}
