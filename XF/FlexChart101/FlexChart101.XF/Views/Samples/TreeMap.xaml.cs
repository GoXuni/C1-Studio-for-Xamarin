using FlexChart101.Resources;
using C1.Xamarin.Forms.Chart;
using Xamarin.Forms;

namespace FlexChart101
{
    public partial class TreeMapSample
    {
        public TreeMapSample()
        {
            InitializeComponent();

            Title = AppResources.TreeMapTitle;
            treeMap.ItemsSource = ChartSampleFactory.CreateHierarchicalData();
            treeMap.ChartType = TreeMapType.Squarified;
        }
    }
}
