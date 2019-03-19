using FlexGrid101.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlexGrid101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StarSizing : ContentPage
    {
        public StarSizing()
        {
            InitializeComponent();

            Title = AppResources.StarSizingTitle;

            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;
        }
    }
}
