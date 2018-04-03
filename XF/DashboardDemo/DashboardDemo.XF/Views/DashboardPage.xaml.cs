using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DashboardDemo.ViewModels;
using C1.Xamarin.Forms.Chart;
using C1.Xamarin.Forms.Core;
using DashboardDemo.Resources;

namespace DashboardDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : CarouselPage
    {
        DashboardViewModel model;
        List<Color> CustomPalette = new List<Color> { Color.FromHex("#0063b1"), Color.FromHex("#e81123"), Color.FromHex("#ff8c00"), Color.FromHex("#2d7d9a"), Color.FromHex("#281123") };
        public DashboardPage()
        {
            InitializeComponent();
            InitText();
            model = new DashboardViewModel();
            switch(Device.RuntimePlatform){
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

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            C1Animation loadAnimation = new C1Animation();
            loadAnimation.Duration = new TimeSpan(1000 * 10000);
            loadAnimation.Easing = Xamarin.Forms.Easing.CubicInOut; ;
            flexChartSTP.CustomPalette = CustomPalette;
            flexChartSTP.LoadAnimation = loadAnimation;
            flexChartSP.CustomPalette = CustomPalette;
            flexChartSP.LoadAnimation = loadAnimation;
            flexChartPCY.CustomPalette = CustomPalette;
            flexChartPCY.LoadAnimation = loadAnimation;
            await model.Init();
            await model.FilterYearDataAsync();
            UpdateItemsSource();
        }

        private void InitText()
        {
            Title = AppResources.DashboardTitle;
            btnMonthData.Text = AppResources.FilterMonthText;
            btn3MonthsData.Text = AppResources.Filter3MonthsText;
            btn6MonthsData.Text = AppResources.Filter6MonthsText;
            btnYearData.Text = AppResources.FilterYearText;
            btn2YearsData.Text = AppResources.Filter2YearsText;
            lblSTP.Text = AppResources.LabelSTPText;
            lblSTC.Text = AppResources.LabelSTCText;
            lblCSGD.Text = AppResources.LabelCSGDText;
            lblSales.Text = AppResources.LabelSalesText;
            lblRSGD.Text = AppResources.LabelRSGDText;
            lblSales2.Text = AppResources.LabelSalesText;
            lblCYPPYP.Text = AppResources.LabelCYPPYPText;
            lblSP.Text = AppResources.LabelSPText;
        }

        private async void OnFilterClick()
        {
            var action = await DisplayActionSheet(AppResources.FilterOptionsText, AppResources.FilterCancelText, null, AppResources.FilterMonthText, 
                AppResources.Filter3MonthsText, AppResources.Filter6MonthsText, AppResources.FilterYearText, AppResources.Filter2YearsText);

            if (action == AppResources.FilterMonthText)
            {
                await model.FilterMonthDataAsync();
                UpdateItemsSource();
            }
            else if (action == AppResources.Filter3MonthsText)
            {
                await model.Filter3MonthsDataAsync();
                UpdateItemsSource();
            }
            else if (action == AppResources.Filter6MonthsText)
            {
                await model.Filter6MonthsDataAsync();
                UpdateItemsSource();
            }
            else if (action == AppResources.FilterYearText)
            {
                await model.FilterYearDataAsync();
                UpdateItemsSource();
            }
            else if (action == AppResources.Filter2YearsText)
            {
                await model.Filter2YearsDataAsync();
                UpdateItemsSource();
            }
        }

        private async void OnMonthData(object sender, EventArgs e)
        {
            await model.FilterMonthDataAsync();
            UpdateItemsSource();
        }

        private async void On3MonthsData(object sender, EventArgs e)
        {
            await model.Filter3MonthsDataAsync();
            UpdateItemsSource();
        }

        private async void On6MonthsData(object sender, EventArgs e)
        {
            await model.Filter6MonthsDataAsync();
            UpdateItemsSource();
        }

        private async void OnYearData(object sender, EventArgs e)
        {
            await model.FilterYearDataAsync();
            UpdateItemsSource();
        }

        private async void On2YearsData(object sender, EventArgs e)
        {
            await model.Filter2YearsDataAsync();
            UpdateItemsSource();
        }

        private void UpdateItemsSource()
        {
            flexChartSTP.ItemsSource = model.TopSaleProducts;
            flexGridSTC.ItemsSource = model.TopSaleCustomers;
            listViewCSGD.ItemsSource = model.CategorySalesVsGoal;
            listViewRSGD.ItemsSource = model.RegionSalesVsGoal;
            flexChartPCY.ItemsSource = model.BudgetItems;
            flexChartSP.ItemsSource = model.BudgetItems;
        }
    }
}