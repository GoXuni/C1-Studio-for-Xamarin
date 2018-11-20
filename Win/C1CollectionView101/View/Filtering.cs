using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using C1.CollectionView;
using C1.Win.CollectionView;
using C1CollectionView101.Resources;

namespace C1CollectionView101.View
{
    public partial class Filtering : UserControl
    {
        private C1CollectionView<YouTubeVideo> _collectionView;
        Menu _owner;

        public Filtering()
        {
            InitializeComponent();
            lblTitle.Text = AppResources.FilteringTitle;
        }

        internal async void ShowPage(Menu owner)
        {
            _owner = owner;
            await UpdateVideos();
        }

        private async Task UpdateVideos()
        {
            try
            {
                progressBar1.Visible = true;
                youTubeListView1.Visible = false;
                var _videos = new ObservableCollection<YouTubeVideo>((await YouTubeCollectionView.LoadVideosAsync("WinForms", "relevance", null, 50)).Item2);
                _collectionView = new C1CollectionView<YouTubeVideo>(_videos);
                youTubeListView1.SetItemsSource(_collectionView, "Title");
                youTubeListView1.Visible = true;
            }
            catch
            {
                MessageBox.Show(AppResources.InternetConnectionError, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                progressBar1.Visible = false;
            }
        }

        private async void filterTextBox_TextChanged(object sender, EventArgs e)
        {
            await _collectionView.FilterAsync(filterTextBox.Text);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _owner.SelectedSampleViewType = -1;
        }
    }
}
