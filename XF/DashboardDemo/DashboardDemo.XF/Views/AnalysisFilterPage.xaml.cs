using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DashboardDemo.ViewModels;
using C1.CollectionView;
using C1.Xamarin.Forms.Grid;

namespace DashboardDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnalysisFilterPage : ContentPage
    {
        List<RegionFilterModel> regionFilterBackup;
        List<ProductFilterModel> productFilterBackup;
        AnalysisPage analysisPage;
        AnalysisViewModel model;

        public List<RegionFilterModel> RegionFilter { get; private set; }
        public List<ProductFilterModel> ProductFilter { get; private set; }

        public AnalysisFilterPage(AnalysisPage page)
        {
            InitializeComponent();

            analysisPage = page;
            model = new AnalysisViewModel();
            RegionFilter = model.Regions;
            ProductFilter = model.Products;
            regionFilterBackup = CloneRegionFilter(RegionFilter);
            productFilterBackup = CloneProductFilter(ProductFilter);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            gridProduct.ItemsSource = ProductFilter;
            gridRegion.ItemsSource = RegionFilter;
        }

        private List<RegionFilterModel> CloneRegionFilter(List<RegionFilterModel> list)
        {
            var regionFilter = new List<RegionFilterModel>();

            foreach (var region in list)
            {
                regionFilter.Add(region.Clone());
            }

            return regionFilter;
        }

        private List<ProductFilterModel> CloneProductFilter(List<ProductFilterModel> list)
        {
            var productFilter = new List<ProductFilterModel>();

            foreach (var product in list)
            {
                productFilter.Add(product.Clone());
            }

            return productFilter;
        }

        private async void OnOKClicked(object sender, EventArgs e)
        {
            if (analysisPage != null)
            {
                gridProduct.FinishEditing();
                gridRegion.FinishEditing();
                await analysisPage.SetProductAndRegionFilter(ProductFilter, RegionFilter);

                if (!regionFilterBackup.Equals(RegionFilter))
                    regionFilterBackup = CloneRegionFilter(RegionFilter);
                if (!productFilterBackup.Equals(ProductFilter))
                    productFilterBackup = CloneProductFilter(ProductFilter);

                await Navigation.PopModalAsync(true);
            }
        }

        private async void OnCancelClicked(object sender, EventArgs e)
        {
            if (!RegionFilter.Equals(regionFilterBackup))
                RegionFilter = CloneRegionFilter(regionFilterBackup);
            if (!ProductFilter.Equals(productFilterBackup))
                ProductFilter = CloneProductFilter(productFilterBackup);

            await Navigation.PopModalAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            if (!RegionFilter.Equals(regionFilterBackup))
                RegionFilter = CloneRegionFilter(regionFilterBackup);
            if (!ProductFilter.Equals(productFilterBackup))
                ProductFilter = CloneProductFilter(productFilterBackup);

            return base.OnBackButtonPressed();
        }

    }
}