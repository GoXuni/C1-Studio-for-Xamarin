using Sunburst101.Resources;
using System.Collections.Generic;
using System.Linq;
using C1.CollectionView;

namespace Sunburst101
{
    public partial class Group
    {
        private static C1CollectionView<Item> cv;
        public Group()
        {
            InitializeComponent();
            Title = AppResources.GroupTitle;
            SunburstViewModel model = new SunburstViewModel();
            cv = model.View;
            cv.GroupChanged += View_GroupChanged;

            cv.SortChanged += Cv_SortChanged;
        }

        private void Cv_SortChanged(object sender, System.EventArgs e)
        {
            GroupDescription yearGroupDescription = new GroupDescription("Year");
            GroupDescription quarterGroupDescription = new GroupDescription("Quarter");
            GroupDescription monthGroupDescription = new GroupDescription("MonthName");
            GroupDescription[] groupDescriptions = new GroupDescription[] { yearGroupDescription, quarterGroupDescription , monthGroupDescription };
            cv.GroupAsync(groupDescriptions);
        }

        private void View_GroupChanged(object sender, System.EventArgs e)
        {
            //(cv.ToList()).OrderBy(i => ((GroupItem<object, object>)i).Group);
            this.sunburst.ItemsSource = cv;
            this.sunburst.Invalidate();
        }
        
    }
}
