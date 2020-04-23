using Sunburst101.Resources;
using System.Collections.Generic;
using System.Linq;
using C1.DataCollection;
using Xamarin.Forms.Xaml;

namespace Sunburst101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Group
    {
        private static C1DataCollection<Item> dataCollection;
        public Group()
        {
            InitializeComponent();
            Title = AppResources.GroupTitle;
            SunburstViewModel model = new SunburstViewModel();
            dataCollection = model.View;
            dataCollection.GroupChanged += View_GroupChanged;

            dataCollection.SortChanged += Cv_SortChanged;
        }

        private void Cv_SortChanged(object sender, System.EventArgs e)
        {
            GroupDescription yearGroupDescription = new GroupDescription("Year");
            GroupDescription quarterGroupDescription = new GroupDescription("Quarter");
            GroupDescription monthGroupDescription = new GroupDescription("MonthName");
            GroupDescription[] groupDescriptions = new GroupDescription[] { yearGroupDescription, quarterGroupDescription , monthGroupDescription };
            dataCollection.GroupAsync(groupDescriptions);
        }

        private void View_GroupChanged(object sender, System.EventArgs e)
        {
            //(cv.ToList()).OrderBy(i => ((GroupItem<object, object>)i).Group);
            this.sunburst.ItemsSource = dataCollection;
            this.sunburst.Invalidate();
        }
        
    }
}
