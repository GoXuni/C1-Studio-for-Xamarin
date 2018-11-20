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

namespace MyBI.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            C1.Xamarin.Forms.Chart.Platform.UWP.FlexChartRenderer.Init();
            C1.Xamarin.Forms.Input.Platform.UWP.C1InputRenderer.Init();
            C1.Xamarin.Forms.Gauge.Platform.UWP.C1GaugeRenderer.Init();
            C1.Xamarin.Forms.Grid.Platform.UWP.FlexGridRenderer.Init();
            this.InitializeComponent();
            LoadApplication(new MyBI.App());
        }
    }
}
