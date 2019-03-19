using FlexGrid101.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlexGrid101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FullTextFilter : ContentPage
    {
        public FullTextFilter()
        {
            InitializeComponent();

            Title = AppResources.FullTextFilterTitle;
            filter.Placeholder = AppResources.FilterPlaceholderText;
            filter.Keyboard = Keyboard.Plain;
            filter.Text = "Rich";
            matchCaseLabel.Text = AppResources.MatchCaseLabel;
            matchWholeWordLabel.Text = AppResources.MatchWholeWordLabel;

            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;
            grid.MinColumnWidth = 85;
        }
    }
}
