using FlexGrid101.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlexGrid101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomCells : ContentPage
    {
        public CustomCells()
        {
            InitializeComponent();

            this.Title = AppResources.CustomCellsTitle;
            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;
            grid.MinColumnWidth = 85;
        }
    }
}
