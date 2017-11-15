using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C1.Xamarin.Forms.Chart;
using C1.Xamarin.Forms.Chart.Annotation;
using FlexChart101.Resources;
using Xamarin.Forms;

namespace FlexChart101
{
    public partial class AnnotationSample : ContentPage
    {
        public AnnotationSample()
        {
            InitializeComponent();

            Title = AppResources.GettingStartedTitle;
            flexChart.ItemsSource = new AnnotationViewModel().Data;
            flexChart.ChartType = ChartType.Line;
			flexChart.BindingX = "X";
			flexChart.LegendPosition = ChartPositionType.Bottom;
			var pngImage = ImageSource.FromResource("FlexChart101.Images.butterfly.png");
            imageAnno.Source = pngImage;
            polygonAnno.Points = CreatePoints();

        }

        private System.Collections.ObjectModel.ObservableCollection<Point> CreatePoints()
        {
            System.Collections.ObjectModel.ObservableCollection<Point> points = new System.Collections.ObjectModel.ObservableCollection<Point>();
            
            points.Add(new Point(100, 25));
            points.Add(new Point(50, 70));
            points.Add(new Point(75, 115));
            points.Add(new Point(125, 115));
            points.Add(new Point(150, 70));
           
            return points;
        }
    }
}
