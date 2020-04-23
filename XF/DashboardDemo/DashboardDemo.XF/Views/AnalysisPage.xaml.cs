using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DashboardDemo.ViewModels;
using C1.Xamarin.Forms.Core;
using DashboardDemo.Resources;

namespace DashboardDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnalysisPage : TabbedPage
    {
        AnalysisFilterPage filterPage;
        AnalysisViewModel model;
        List<ProductFilterModel> productFilterList;
        List<RegionFilterModel> regionFilterList;
        bool initialized;
        List<Color> CustomPalette = new List<Color> { Color.FromHex("#0063b1"), Color.FromHex("#e81123"), Color.FromHex("#ff8c00"), Color.FromHex("#2d7d9a"), Color.FromHex("#281123") };
        public AnalysisPage()
        {
            InitializeComponent();
            InitText();
            C1Animation loadAnimation = new C1Animation();
            loadAnimation.Duration = new TimeSpan(1000 * 10000);
            loadAnimation.Easing = Xamarin.Forms.Easing.CubicInOut;
            flexPie.LoadAnimation = loadAnimation;
            flexPie.CustomPalette = CustomPalette;
            flexChart.LoadAnimation = loadAnimation;
            flexChart.CustomPalette = CustomPalette;
            filterPage = new AnalysisFilterPage(this);
            model = new AnalysisViewModel();
            model.PropertyChanged += OnVMPropertyChanged;
            initialized = false;
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    {
                        ToolbarItems.Remove(btnMonthData);
                        ToolbarItems.Remove(btn3MonthsData);
                        ToolbarItems.Remove(btn6MonthsData);
                        ToolbarItems.Remove(btnYearData);
                        ToolbarItems.Remove(btn2YearsData);

                        this.ToolbarItems.Add(new ToolbarItem(AppResources.ToolbarFilterText, "", () => { OnFilterClick(); }, 0, 0));
                    }
                    break;
            }
        }

        private void InitText()
        {
            Title = AppResources.AnalysisTitle;
            btnMonthData.Text = AppResources.FilterMonthText;
            btn3MonthsData.Text = AppResources.Filter3MonthsText;
            btn6MonthsData.Text = AppResources.Filter6MonthsText;
            btnYearData.Text = AppResources.FilterYearText;
            btn2YearsData.Text = AppResources.Filter2YearsText;
            pagePS.Title = AppResources.ProductSalesTitle;
            lblPWQYS.Text = AppResources.LabelPWYSText;
            pageCO.Title = AppResources.CurrentOpportunitiesTitle;
            lblCOLS.Text = AppResources.LabelCOLSText;
        }

        private async void OnFilterClick()
        {
            var action = await DisplayActionSheet(AppResources.FilterOptionsText, AppResources.FilterCancelText, null, AppResources.FilterMonthText,
                AppResources.Filter3MonthsText, AppResources.Filter6MonthsText, AppResources.FilterYearText, AppResources.Filter2YearsText);

            if (action == AppResources.FilterMonthText)
            {
                await model.FilterMonthDataAsync();
                await SetProductAndRegionFilter(productFilterList, regionFilterList);
            }
            else if (action == AppResources.Filter3MonthsText)
            {
                await model.Filter3MonthsDataAsync();
                await SetProductAndRegionFilter(productFilterList, regionFilterList);
            }
            else if (action == AppResources.Filter6MonthsText)
            {
                await model.Filter6MonthsDataAsync();
                await SetProductAndRegionFilter(productFilterList, regionFilterList);
            }
            else if (action == AppResources.FilterYearText)
            {
                await model.FilterYearDataAsync();
                await SetProductAndRegionFilter(productFilterList, regionFilterList);
            }
            else if (action == AppResources.Filter2YearsText)
            {
                await model.Filter2YearsDataAsync();
                await SetProductAndRegionFilter(productFilterList, regionFilterList);
            }
        }

        private void OnVMPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "RegionProductSales")
            {
                flexPie.ItemsSource = model.RegionProductSales;
            }
            else if (e.PropertyName == "Opportunity")
            {
                flexChart.ItemsSource = model.Opportunity;
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (!initialized)
            {
                await model.FilterYearDataAsync();
                flexPie.ItemsSource = model.RegionProductSales;
                flexChart.ItemsSource = model.Opportunity;
                initialized = true;
            }
        }

        private async void OnMonthData(object sender, EventArgs e)
        {
            await model.FilterMonthDataAsync();
            await SetProductAndRegionFilter(productFilterList, regionFilterList);
        }

        private async void On3MonthsData(object sender, EventArgs e)
        {
            await model.Filter3MonthsDataAsync();
            await SetProductAndRegionFilter(productFilterList, regionFilterList);
        }

        private async void On6MonthsData(object sender, EventArgs e)
        {
            await model.Filter6MonthsDataAsync();
            await SetProductAndRegionFilter(productFilterList, regionFilterList);
        }

        private async void OnYearData(object sender, EventArgs e)
        {
            await model.FilterYearDataAsync();
            await SetProductAndRegionFilter(productFilterList, regionFilterList);
        }

        private async void On2YearsData(object sender, EventArgs e)
        {
            await model.Filter2YearsDataAsync();
            await SetProductAndRegionFilter(productFilterList, regionFilterList);
        }

        private async void OnFilterClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(filterPage, true);
        }

        public async Task SetProductAndRegionFilter(List<ProductFilterModel> productFilter, List<RegionFilterModel> regionFilter)
        {
            if (productFilter == null || regionFilter == null)
                return;

            productFilterList = new List<ProductFilterModel>(productFilter);
            regionFilterList = new List<RegionFilterModel>(regionFilter);

            await model.FilterProductAndRegion(productFilter, regionFilter);
        }

    }
}