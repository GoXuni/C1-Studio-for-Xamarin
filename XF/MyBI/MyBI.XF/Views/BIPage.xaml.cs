using C1.Xamarin.Forms.Chart;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyBI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BIPage : TabbedPage
    {
        private Color _upSymbol;
        private Color _downSymbol;

        public BIPage()
        {
            InitializeComponent();

            this.CurrentPageChanged += OnCurrentPageChanged;
            SetPageTexts();
            _upSymbol = new Color(153.0 / 255.0, 191.0 / 255.0, 128 / 255.0);
            _downSymbol = new Color(230.0 / 255.0, 128.0 / 255.0, 128.0 / 255.0);
            Appearing += OnAppearing;
            Model.Instance.DataUpdated += OnDataUpdated;
            if (Device.RuntimePlatform == Device.Android)
            {
                UnitSalesGauge.WidthRequest = 50;
                UnitSalesGauge.HeightRequest = 50;
                RevenueGauge.WidthRequest = 50;
                RevenueGauge.HeightRequest = 50;
            }
            SizeChanged += (sender, args) =>
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                    case Device.Android:
                        if (Width > Height)
                        {
                            GaugeStack.Orientation = StackOrientation.Horizontal;

                        }
                        else
                        {
                            GaugeStack.Orientation = StackOrientation.Vertical;

                        }
                        break;
                }
            };

        }
        private void Info_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MyBI.Views.InfoPage());
        }
        private void OnAppearing(object sender, EventArgs e)
        {
            Update();
        }

        private void OnCurrentPageChanged(object sender, EventArgs e)
        {
            int currentIndex = Children.IndexOf(CurrentPage);
            switch (currentIndex)
            {
                case 0:
                    this.Title = MyBI.Resources.AppResources.CurrentPeriodTitle;
                    break;
                case 1:
                    this.Title = MyBI.Resources.AppResources.TrendsTitle;
                    break;
                case 2:
                    this.Title = MyBI.Resources.AppResources.DetailsTitle;
                    break;
            }
        }

        private void RevenueChartAxisYLabelLoading(object sender, AxisLabelLoadingEventArgs e)
        {
            Label label = new Label();
            label.VerticalOptions = LayoutOptions.Center;
            label.Text = (e.Value / 1000).ToString();
            e.Label = label;
        }

        private void OnDataUpdated(object sender, EventArgs e)
        {
            Update();
        }

        public void ChangeCurrentPage(int index)
        {
            ContentPage targetPage = (ContentPage)Children[index];
            CurrentPage = targetPage;
        }

        private void Update()
        {
            UnitSalesGauge.Max = MathHelper.Instance.GetMaxValue();
            RevenueGauge.Max = MathHelper.Instance.GetMaxValue(false);
            Point unitRange = GaugeHelper.Instance.GetGoalRange();
            Point revenueRange = GaugeHelper.Instance.GetGoalRange(false);
            UnitSalesGoal.Min = unitRange.X;
            UnitSalesGoal.Max = unitRange.Y;
            RevenueGoal.Min = revenueRange.X;
            RevenueGoal.Max = revenueRange.Y;
            UnitSalesGauge.Value = Model.Instance.CurrentUnitSales;
            RevenueGauge.Value = Model.Instance.CurrentRevenue;

            UnitSalesY.MajorUnit = FlexChartHelper.Instance.GetFavourableAxisYValue(2);
            RevenueY.MajorUnit = FlexChartHelper.Instance.GetFavourableAxisYValue(3, false);
            UnitSalesChart.ItemsSource = Model.Instance.DetailItemList;
            RevenueChart.ItemsSource = Model.Instance.DetailItemList;

            UpdateTrendSymbol();
            detailsView.ItemsSource = Model.Instance.DetailItemList;
        }
        private void UpdateTrendSymbol()
        {
            bool unitUp = FlexChartHelper.Instance.IsUnitTrendUp;
            bool revenueUp = FlexChartHelper.Instance.IsRevenueTrendUp;
            UnitTrendSymbol.Text = unitUp ? "\xEB11" : "\xEB0F";
            RevenueTrendSymbol.Text = revenueUp ? "\xEB11" : "\xEB0F";
            UnitTrendSymbol.TextColor = unitUp ? _upSymbol : _downSymbol;
            RevenueTrendSymbol.TextColor = revenueUp ? _upSymbol : _downSymbol;
        }

        private void SetPageTexts()
        {
            Title = MyBI.Resources.AppResources.CurrentPeriodTitle;
            UnitSalesLabel.Text = MyBI.Resources.AppResources.UnitSalesText;
            RevenueLabel.Text = MyBI.Resources.AppResources.RevenueText;
            periodColumn.Header = MyBI.Resources.AppResources.PeriodColumnHeader;
            unitColumn.Header = MyBI.Resources.AppResources.UnitSalesText;
            revenueColumn.Header = MyBI.Resources.AppResources.RevenueTextWithSymbol;
            TrendUnitSalesLabel.Text = MyBI.Resources.AppResources.UnitSalesText;
            TrendRevenueLabel.Text = MyBI.Resources.AppResources.RevenueTextWithSymbol;
            string fontFamily;
            switch (Device.RuntimePlatform)
            {
                case "Android":
                    fontFamily = "segmdl2.ttf#Segoe MDL2 Assets";
                    break;
                case "iOS":
                    fontFamily = "Segoe MDL2 Assets";
                    break;
                case "Windows":
                    fontFamily = "/Assets/segmdl2.ttf#Segoe MDL2 Assets";
                    break;
                case "WinPhone":
                    fontFamily = "/Assets/segmdl2.ttf#Segoe MDL2 Assets";
                    break;
                default:
                    fontFamily = "segmdl2.ttf#Segoe MDL2 Assets";
                    break;
            }
            UnitTrendSymbol.FontFamily = fontFamily;
            RevenueTrendSymbol.FontFamily = fontFamily;
            CurrentPage.Title = MyBI.Resources.AppResources.CurrentTitle;
            TrendPage.Title = MyBI.Resources.AppResources.TrendsTitle;
            DetailsPage.Title = MyBI.Resources.AppResources.DetailsTitle;
        }
    }
}