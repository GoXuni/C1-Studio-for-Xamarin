using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DashboardModel;
using DashboardDemo.ViewModels;

namespace DashboardDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailPage : ContentPage
    {
        public ProductDetailPage()
        {
            InitializeComponent();
        }

        public ProductDetailPage(ProductItem item)
        {
            InitializeComponent();
            BindingContext = item;
        }
    }
}