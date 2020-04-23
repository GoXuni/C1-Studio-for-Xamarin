using C1.DataCollection;
using FlexGrid101.Resources;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlexGrid101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Grouping : ContentPage
    {
        C1DataCollection<Customer> _dataCollection;
        public Grouping()
        {
            InitializeComponent();

            this.Title = AppResources.GroupingTitle;
 
            var task = UpdateVideos();
        }

        private async Task UpdateVideos()
        {
            var data = Customer.GetCustomerList(100);
            _dataCollection = new C1DataCollection<Customer>(data);
            await _dataCollection.GroupAsync(c => c.Country);          
            grid.ItemsSource = _dataCollection;
            grid.MinColumnWidth = 85;
        }
    } 
}
