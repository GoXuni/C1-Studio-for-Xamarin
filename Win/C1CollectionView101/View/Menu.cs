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

namespace C1CollectionView101.View
{
    public partial class Menu : UserControl
    {
        int _selectedSampleViewType = -2;

        public Menu()
        {
            InitializeComponent();

            var samples = GetSamples();
            foreach (var sample in samples)
            {
                var item = new ListViewItem()
                {
                    ImageIndex = imageList1.Images.IndexOfKey(sample.Thumbnail),
                    Text = sample.Name,
                    Tag = sample
                };
                listView1.Items.Add(item);
            }
        }

        private List<Sample> GetSamples()
        {
            return new List<Sample>
            {
                new Sample() { Name = AppResources.SortingTitle, Description= AppResources.SortingDescription, SampleViewType = 0, Thumbnail="sort.png" },
                new Sample() { Name = AppResources.FilteringTitle, Description= AppResources.FilteringDescription, SampleViewType = 1, Thumbnail="filter.png" },
                new Sample() { Name = AppResources.GroupingTitle, Description= AppResources.GroupingDescription, SampleViewType = 2, Thumbnail="flexgrid_grouping.png"},
                //new Sample() { Name = AppResources.SimpleOnDemandTitle, Description= AppResources.SimpleOnDemandDescription, SampleViewType = 4, Thumbnail="flexgrid_loading.png" },
                //new Sample() { Name = AppResources.OnDemandTitle, Description= AppResources.OnDemandDescription, SampleViewType = 3, Thumbnail="flexgrid_loading.png" },
            };
        }

        public int SelectedSampleViewType
        {
            get => _selectedSampleViewType;
            set
            {
                if (value != _selectedSampleViewType)
                {
                    _selectedSampleViewType = value;
                    OnSelectionChanged(EventArgs.Empty);
                }
            }
        }

        public event EventHandler<EventArgs> SelectionChanged;

        protected void OnSelectionChanged(EventArgs e) => SelectionChanged?.Invoke(this, e);        

        private void listView1_ItemClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
                SelectedSampleViewType = ((Sample)listView1.SelectedItems[0].Tag).SampleViewType;
            else
                SelectedSampleViewType = -1;            
        }
    }
}
