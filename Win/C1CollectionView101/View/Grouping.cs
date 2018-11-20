using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C1CollectionView101.Resources;
using System.Collections.ObjectModel;
using C1.CollectionView;
using C1.Win.CollectionView;

namespace C1CollectionView101.View
{
    public partial class Grouping : UserControl
    {
        Menu _owner;
        private ObservableCollection<YouTubeVideo> _videos;
        private C1CollectionView<YouTubeVideo> _collectionView;

        public Grouping()
        {
            InitializeComponent();
            lblTitle.Text = AppResources.GroupingTitle;
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
                listView1.Visible = false;
                progressBar1.Visible = true;
                _videos = new ObservableCollection<YouTubeVideo>((await YouTubeCollectionView.LoadVideosAsync("WinForms", "relevance", null, 50)).Item2);
                _collectionView = new C1CollectionView<YouTubeVideo>(_videos);
                await _collectionView.GroupAsync(v => v.ChannelTitle);
                listView1.SetItemsSource(_collectionView, "Title", "Thumbnail");
                listView1.Visible = true;
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            _owner.SelectedSampleViewType = -1;
        }
    }
}
