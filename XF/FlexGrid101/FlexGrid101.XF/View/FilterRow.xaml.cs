using C1.Xamarin.Forms.Grid;
using FlexGrid101.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlexGrid101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilterRow : ContentPage
    {
        public FilterRow()
        {
            InitializeComponent();

            this.Title = AppResources.FilterRowTitle;

            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;
            grid.Rows.Insert(0, new GridFilterRow { Placeholder = AppResources.FilterPlaceholderText, AutoComplete = true });
        }

    }
}
