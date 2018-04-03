using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DashboardModel;
using DashboardDemo.ViewModels;
using DashboardDemo.Resources;

namespace DashboardDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsPage : ContentPage
    {
        ContentPage productDetail = new ProductDetailPage(null);
        ProductViewModel model;

        public ProductsPage()
        {
            InitializeComponent();
            Title = AppResources.ProductsTitle;
            model = new ProductViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (listView.ItemsSource == null)
            {
                listView.ItemsSource = await model.GetProducts();
                //listView.GroupDisplayBinding = new Binding("Title");
                //listView.GroupShortNameBinding = new Binding("ShortName");
                //listView.IsGroupingEnabled = true;
                listView.ItemTapped += OnItemTapped;
            }
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as ProductItem;
            if (item != null)
            {
                productDetail.BindingContext = item;
                Navigation.PushAsync(productDetail);
            }
        }
    }
}