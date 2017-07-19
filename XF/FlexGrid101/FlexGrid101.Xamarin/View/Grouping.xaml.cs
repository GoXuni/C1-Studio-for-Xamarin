using FlexGrid101.Resources;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using C1.CollectionView;
using C1.Xamarin.Forms.Grid;

namespace FlexGrid101
{
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
        }
    } 
}
