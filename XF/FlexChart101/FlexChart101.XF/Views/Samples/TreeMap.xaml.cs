using FlexChart101.Resources;
using C1.Xamarin.Forms.Chart;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlexChart101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
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
