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
            grid.SelectionChanging += OnSelectionChanging;
 
            var task = UpdateVideos();
        }

        private async Task UpdateVideos()
        {
            var data = Customer.GetCustomerList(100);
            _collectionView = new C1CollectionView<Customer>(data);
            await _collectionView.GroupAsync(c => c.Country);          
            grid.ItemsSource = _collectionView;
        }

        public void OnSelectionChanging(object sender, GridCellRangeEventArgs e)
        {
            if (e.CellType == GridCellType.Cell || e.CellType == GridCellType.RowHeader)
            {
                var row = grid.Rows[e.CellRange.Row] as GridGroupRow;
                if (row != null)
                     e.Cancel = true;   
            }   
        } 
    } 
}
