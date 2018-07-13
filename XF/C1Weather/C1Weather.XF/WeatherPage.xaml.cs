using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using C1.CollectionView;
using C1.Xamarin.Forms.Grid;
using Xamarin.Forms.Xaml;
using C1Weather.Resources;
using System.Collections.Generic;
using C1.Xamarin.Forms.Chart;
using C1.Xamarin.Forms.Chart.Interaction;
using Plugin.Geolocator;
using C1.Xamarin.Forms.Core;
using Plugin.Permissions.Abstractions;

namespace C1Weather
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        WeatherData data;
        ObservableCollection<WeatherModel> list;
        public WeatherPage()
        {
            InitializeComponent();
            //localization
            ZipEntry.Placeholder = AppResources.EntryPlaceholder;
            HumidityAxis.Title = AppResources.HumidityAxisLabel;
            TempAxis.Title = AppResources.TempAxisLabel;
            HumiditySeries.SeriesName = AppResources.HumidityAxisLabel;
            TemperatureSeries.SeriesName = AppResources.TempAxisLabel;
            DateColumn.Header = AppResources.DateHeader;
            IconColumn.Header = AppResources.IconHeader;
            DescriptionColumn.Header = AppResources.DescriptionHeader;
            HighColumn.Header = AppResources.HighHeader;
            LowColumn.Header = AppResources.LowHeader;
            HumidityColumn.Header = AppResources.HumidityHeader;
            PressureColumn.Header = AppResources.PressureHeader;
            data = new WeatherData();
            list = new ObservableCollection<WeatherModel> { };
            var task = GeoWeatherTask();
            //
            chart.AnimationMode = AnimationMode.Point;
            C1Animation updateAnimation = new C1Animation();
            updateAnimation.Duration = new TimeSpan(1000 * 10000);
            updateAnimation.Easing = Xamarin.Forms.Easing.CubicInOut;
            chart.UpdateAnimation = updateAnimation;

            chart.AnimationMode = C1.Xamarin.Forms.Chart.AnimationMode.Point;
            C1Animation loadAnimation = new C1Animation();
            loadAnimation.Duration = new TimeSpan(1000 * 10000);
            loadAnimation.Easing = Xamarin.Forms.Easing.CubicInOut;
            chart.LoadAnimation = loadAnimation;

            //line marker configuration and initialization
            lineMarker.DragLines = true;
            lineMarker.DragContent = true;
            lineMarker.Interaction = LineMarkerInteraction.Move;
            initMarker();
        }
        //fetch Weather with geolocation 
        private async Task GeoWeatherTask()
        {
            
            string geoposition = "";
            try
            {
                var hasPermission = await Util.CheckPermissions(Permission.Location);
                if (!hasPermission)
                    return;
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;
                var position = await locator.GetPositionAsync(new TimeSpan(100000000));
                geoposition = "lat=" + position.Latitude + "&lon=" + position.Longitude;
                Tuple<ObservableCollection<WeatherModel>, String> s = await data.GetResultGeo(geoposition);
                list = s.Item1;
                chart.Header = s.Item2;
                chart.ItemsSource = list;
                grid.ItemsSource = list;

            }
            catch (Exception e)
            {

                await DisplayAlert(AppResources.AlertTitle, AppResources.AlertMessage + "\n" + e.Message, AppResources.Cancel);
            }
        }


        //fetch Weather with zip
        private async Task WeatherTask(string zip)
        {
            try
            {
                Tuple<ObservableCollection<WeatherModel>, String> s = await data.GetResultZip(zip);
                list = s.Item1;
                chart.Header = s.Item2;
                chart.ItemsSource = list;
                grid.ItemsSource = list;
                
            }
            catch(Exception e)
            {
                
                await DisplayAlert(AppResources.AlertTitle, AppResources.AlertMessage + "\n" + e.Message, AppResources.Cancel);
            }
        }
        //Allows selected rows to modify data displayed in chart 
        private void grid_SelectionChanged(object sender, C1.Xamarin.Forms.Grid.GridCellRangeEventArgs e)
        {
            WeatherModel selectedData;
            ObservableCollection<WeatherModel> selectedDataCollection = new ObservableCollection<WeatherModel>();
            int upperRow = e.CellRange.Row;
            int lowerRow = e.CellRange.Row2;
            if (e.CellRange.Row2 < e.CellRange.Row)
            {
                upperRow = e.CellRange.Row2;
                lowerRow = e.CellRange.Row;
            }

            for (int i = upperRow; i <= lowerRow; i++)
            {
                selectedData = new WeatherModel();
                selectedData.date = (DateTime)grid.GetCellValue(new C1.Xamarin.Forms.Grid.GridCellRange(i, grid.Columns["date"].Index));
                selectedData.description = (string)grid.GetCellValue(new C1.Xamarin.Forms.Grid.GridCellRange(i, grid.Columns["description"].Index));
                selectedData.hightemp = (double)grid.GetCellValue(new C1.Xamarin.Forms.Grid.GridCellRange(i, grid.Columns["hightemp"].Index));
                selectedData.lowtemp = (double)grid.GetCellValue(new C1.Xamarin.Forms.Grid.GridCellRange(i, grid.Columns["lowtemp"].Index));
                selectedData.humidity = (int)grid.GetCellValue(new C1.Xamarin.Forms.Grid.GridCellRange(i, grid.Columns["humidity"].Index));
                selectedData.pressure = (double)grid.GetCellValue(new C1.Xamarin.Forms.Grid.GridCellRange(i, grid.Columns["pressure"].Index));

                selectedDataCollection.Add(selectedData);
            }
            chart.ItemsSource = selectedDataCollection;
            if((lowerRow - upperRow) == 0)
            {
                TemperatureSeries.ChartType = ChartType.Scatter;
                HumiditySeries.ChartType = ChartType.Scatter;
            }
            else
            {
                TemperatureSeries.ChartType = ChartType.Spline;
                HumiditySeries.ChartType = ChartType.SplineArea;
            }
        }
        //present info page
        private void Info_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InfoPage());
        }
        //new zip entered
        private void ZipEntry_Completed(object sender, EventArgs e)
        {
            data = new WeatherData();
            list = new ObservableCollection<WeatherModel> { };
            var task = WeatherTask(((Entry)sender).Text);
        }
        //handles line marker for chart
        StackLayout layout = new StackLayout();
        Label xLabel = new Label();
        IList<Label> yLabels = new List<Label>();
        private void initMarker()
        {
            xLabel.VerticalOptions = LayoutOptions.FillAndExpand;
            xLabel.HorizontalOptions = LayoutOptions.FillAndExpand;
            List<Color> CustomPalette = new List<Color> {  Color.FromHex("#2196F3"), Color.FromHex("#f44336") };
            layout.Children.Add(xLabel);
            layout.Padding = new Thickness(5, 5, 5, 5);
            for (int index = 0; index < chart.Series.Count; index++)
            {
                var series = chart.Series[index];
                Label yLabel = new Label();
                
                yLabel.VerticalOptions = LayoutOptions.FillAndExpand;
                yLabel.HorizontalOptions = LayoutOptions.FillAndExpand;
                yLabel.TextColor = CustomPalette[index];
                yLabels.Add(yLabel);
                layout.Children.Add(yLabel);
            }

            layout.BackgroundColor = Color.FromRgba(.88, .88, .88, .80);
            lineMarker.Content = layout;
        }

        private void OnLineMarkerPositionChanged(object sender, PositionChangedArgs e)
        {
            if (chart != null)
            {
                var info = chart.HitTest(new Point(e.Position.X, double.NaN));
                if (info == null)
                {
                    return;
                }
                int pointIndex = info.PointIndex;
                if (pointIndex < 0)
                {
                    return;
                }
                xLabel.Text = string.Format("{0:dd MMM h tt}", info.X);
                xLabel.FontSize = 11;
                for (int index = 0; index < chart.Series.Count; index++)
                {
                    var series = chart.Series[index];
                    var value = series.GetValues(0)[pointIndex];

                    //var fill = (int)((IChart)chart).GetColor(index);
                    string content = string.Format("{0} {1}", series.SeriesName, string.Format("{0:f0}", value));
                    Label yLabel = yLabels[index];
                    yLabel.Text = content;
                    yLabel.FontSize = 11;
                }
            }
        }
    }
}