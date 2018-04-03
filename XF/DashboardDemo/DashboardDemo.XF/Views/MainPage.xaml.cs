using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DashboardModel;
using DashboardDemo.ViewModels;
using DashboardDemo.Views;

namespace DashboardDemo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            masterPage.ListView.ItemSelected += OnItemSelected;
            IsPresented = true;

            //if (Device.RuntimePlatform == Device.UWP)
            //{
            //    MasterBehavior = MasterBehavior.Popover;
            //}
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                var page = (Page)Activator.CreateInstance(item.TargetType);
                Detail = new NavigationPage(page) { BarBackgroundColor = Color.FromHex("#051839"), BarTextColor = Color.White };

                masterPage.ListView.SelectedItem = null;
                IsPresented = false;
                //masterPage.ListView.SelectedItem = null;
            }
        }
    }
}