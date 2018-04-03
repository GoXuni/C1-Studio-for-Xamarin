using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace DashboardDemo.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            C1.Xamarin.Forms.Chart.Platform.UWP.FlexChartRenderer.Init();
            C1.Xamarin.Forms.Grid.Platform.UWP.FlexGridRenderer.Init();
            C1.Xamarin.Forms.Gauge.Platform.UWP.C1GaugeRenderer.Init();

            this.InitializeComponent();

            LoadApplication(new DashboardDemo.App());
        }
    }
}
