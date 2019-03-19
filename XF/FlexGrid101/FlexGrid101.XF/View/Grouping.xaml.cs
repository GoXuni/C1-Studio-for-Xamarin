using C1.CollectionView;
using FlexGrid101.Resources;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlexGrid101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Grouping : ContentPage
    {
        C1CollectionView<Customer> _collectionView;
        public Grouping()
        {
            InitializeComponent();

            this.Title = AppResources.GroupingTitle;
 
            var task = UpdateVideos();
        }

        private async Task UpdateVideos()
        {
            var data = Customer.GetCustomerList(100);
            _collectionView = new C1CollectionView<Customer>(data);
            await _collectionView.GroupAsync(c => c.Country);          
            grid.ItemsSource = _collectionView;
            grid.MinColumnWidth = 85;
        }
    } 
}
