using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C1.CollectionView;
using C1CollectionView101.Resources;
using C1.Win.CollectionView;

namespace C1CollectionView101.View
{
    public partial class Sorting : UserControl
    {
        C1CollectionView<Customer> _collectionView;
        Menu _owner;

        public Sorting()
        {
            InitializeComponent();
            lblTitle.Text = AppResources.SortingTitle;
            //btnSort.Text = AppResources.Sort;            
        }

        public void ShowPage(Menu owner)
        {
            _owner = owner;
            UpdateVideos();
        }

        private void UpdateVideos()
        {
            try
            {
                lblMessage.Visible = false;
                grid.Visible = false;
                //activityIndicator.IsRunning = true;
                _collectionView = new C1CollectionView<Customer>(Customer.GetCustomerList(100));
                grid.DataSource = new C1CollectionViewBindingList(_collectionView);

                _collectionView.SortChanged += OnSortChanged;
                UpdateSortButton();
                grid.Visible = true;
            }
            catch
            {
                lblMessage.Text = AppResources.InternetConnectionError;
                lblMessage.Visible = true;
            }
            //finally
            //{
            //    activityIndicator.IsRunning = false;
            //}
        }

        async void OnSortClicked(object sender, EventArgs e)
        {
            if (_collectionView != null)
            {
                var direction = GetCurrentSortDirection();
                await _collectionView.SortAsync(x => x.FirstName, direction == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending);
            }
        }

        private void UpdateSortButton()
        {
            var direction = GetCurrentSortDirection();
            if (direction == SortDirection.Ascending)
            {
                btnSort.ImageKey = "sort-descending.png";                
            }
            else
            {
                btnSort.ImageKey = "sort-ascending.png";
            }
        }

        private SortDirection GetCurrentSortDirection()
        {
            var sort = _collectionView.SortDescriptions.FirstOrDefault(sd => sd.SortPath == "FirstName");
            return sort != null ? sort.Direction : SortDirection.Descending;
        }


        void OnSortChanged(object sender, EventArgs e)
        {
            UpdateSortButton();
        }        

        private void btnBack_Click(object sender, EventArgs e)
        {
            _owner.SelectedSampleViewType = -1;
        }
    }
}
