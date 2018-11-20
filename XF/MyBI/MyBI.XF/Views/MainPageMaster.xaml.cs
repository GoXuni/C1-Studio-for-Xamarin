using C1.Xamarin.Forms.Input;
using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyBI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageMaster : ContentPage
    {
        public MainPageMaster()
        {
            InitializeComponent();
            this.Title = MyBI.Resources.AppResources.SelectionText;
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    this.Padding = new Thickness(0, 25, 0, 0);
                    break;
            }
            C1Image.Source = ImageSource.FromResource("MyBI.Icons.white_icon.png", Assembly.GetExecutingAssembly());
            MyBILabel.Text = MyBI.Resources.AppResources.MyBITitle;
            RegionLabel.Text = MyBI.Resources.AppResources.RegionText;
            ProductLabel.Text = MyBI.Resources.AppResources.ProductText;
            Appearing += MainPageMaster_Appearing;
        }

        private void MainPageMaster_Appearing(object sender, EventArgs e)
        {
            RegionSelector.ItemsSource = Model.Instance.RegionList;
            ProductSelector.ItemsSource = Model.Instance.ProductList;
        }

        private void RegionSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            C1ComboBox comboBox = sender as C1ComboBox;
            Model.Instance.FilterByRegion((Region)comboBox.SelectedItem);
        }

        private void ProductSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            C1ComboBox comboBox = sender as C1ComboBox;
            Model.Instance.FilterByProdcut((Product)comboBox.SelectedItem);
        }
    }
}