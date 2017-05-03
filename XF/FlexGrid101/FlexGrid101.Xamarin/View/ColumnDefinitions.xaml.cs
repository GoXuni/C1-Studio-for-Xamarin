using C1.Xamarin.Forms.Grid;
using FlexGrid101.Resources;
using Xamarin.Forms;

namespace FlexGrid101
{
    public partial class ColumnDefinitions : ContentPage
    {
        public ColumnDefinitions()
        {
            InitializeComponent();

            this.Title = AppResources.ColumnDefinitionTitle;
            var data = Customer.GetCustomerList(1000);
            grid.ItemsSource = data;
            grid.Columns.RemoveAt(1);
            grid.Columns["CountryID"].DataMap = new GridDataMap() { ItemsSource = Customer.GetCountries(), DisplayMemberPath = "Value", SelectedValuePath = "Key" };
            grid.BeginningEdit += OnBeginningEdit;
        }

        public void OnBeginningEdit(object sender, GridCellRangeEventArgs e)
        {

        }
    }
}
