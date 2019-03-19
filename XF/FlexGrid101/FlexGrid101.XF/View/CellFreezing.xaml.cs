using FlexGrid101.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlexGrid101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CellFreezing : ContentPage
    {
        public CellFreezing()
        {
            InitializeComponent();

            Title = AppResources.CellFreezingTitle;

            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;
            grid.Columns["Country"].AllowMerging = true;
            grid.MinColumnWidth = 85;
        }
    }
}
