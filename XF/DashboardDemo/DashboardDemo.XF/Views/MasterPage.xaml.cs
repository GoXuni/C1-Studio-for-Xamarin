using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DashboardDemo.ViewModels;
using DashboardDemo.Resources;

namespace DashboardDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView; } }

        public MasterPage()
        {
            InitializeComponent();

             var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = AppResources.DashboardTitle,
                IconSource = "Dashboard.png",
                TargetType = typeof(DashboardPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = AppResources.AnalysisTitle,
                IconSource = "Analysis.png",
                TargetType = typeof(AnalysisPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = AppResources.TasksTitle,
                IconSource = "Tasks.png",
                TargetType = typeof(TasksPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = AppResources.ProductsTitle,
                IconSource = "Products.png",
                TargetType = typeof(ProductsPage)
            });

            listView.ItemsSource = masterPageItems;
        }
    }
}