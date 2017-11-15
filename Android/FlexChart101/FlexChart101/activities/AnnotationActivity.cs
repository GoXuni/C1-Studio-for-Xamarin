using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Views;
using C1.Android.Chart.Annotation;
using C1.Android.Core;
using C1.Android.Chart;
using Android.Graphics;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace FlexChart101
{
	public class AnnotationViewModel
	{
		List<DataItem> _data;
		List<DataItem> _simpleData;
		Random rnd = new Random();

		public List<DataItem> Data
		{
			get
			{
				if (_data == null)
				{
					_data = new List<DataItem>();
					for (int i = 1; i < 51; i++)
					{
						_data.Add(new DataItem()
						{
							X = i,
							Y = rnd.Next(10, 100)
						});
					}
				}

				return _data;
			}
		}

		public List<DataItem> SimpleData
		{
			get
			{
				if (_simpleData == null)
				{
					_simpleData = new List<DataItem>();
					_simpleData.Add(new DataItem() { X = 1, Y = 30 });
					_simpleData.Add(new DataItem() { X = 2, Y = 20 });
					_simpleData.Add(new DataItem() { X = 3, Y = 30 });
					_simpleData.Add(new DataItem() { X = 4, Y = 65 });
					_simpleData.Add(new DataItem() { X = 5, Y = 70 });
					_simpleData.Add(new DataItem() { X = 6, Y = 60 });
				}

				return _simpleData;
			}
		}
	}

	public class DataItem
	{
		public int X { get; set; }
		public int Y { get; set; }
	}

    [Activity(Label = "@string/annotation", Icon = "@drawable/icon")]
    public class AnnotationActivity : AppCompatActivity
    {
        private FlexChart mChart;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_annotation);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.annotation);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            // initializing widgets
            mChart = this.FindViewById<FlexChart>(Resource.Id.flexchart);
            mChart.ChartType = ChartType.Line;
			mChart.BindingX = "X";
			mChart.Series.Add(new ChartSeries() { SeriesName = "Base dataList", Binding = "Y,Y" });
			mChart.ItemsSource = new AnnotationViewModel().Data;
            mChart.LegendPosition = ChartPositionType.None;

            Text text = new Text() { Content = "Relative", Location = new C1Point(0.5, 0.5), Attachment = AnnotationAttachment.Relative };
            text.AnnotationStyle = new ChartStyle() { FontSize = 15, FontFamily = "GenericSansSerif" };

			Ellipse ellipse = new Ellipse() { Content = "Relative", Location = new C1Point(0.4, 0.45), Width = 60, Height = 40, Attachment = AnnotationAttachment.Relative };
            ellipse.AnnotationStyle = new ChartStyle() { Fill = Color.Goldenrod, Stroke = Color.Argb(1*255, (int)(0.75 * 255), (int)(0.55 * 255), (int)(0.06 * 255)), FontAttributes = TypefaceStyle.Bold, FontSize = 10, FontFamily = "GenericSansSerif" };

			Circle circle = new Circle() { Content = "DataIndex", Radius = 40, SeriesIndex = 0, PointIndex = 27, Attachment = AnnotationAttachment.DataIndex };
            circle.AnnotationStyle = new ChartStyle() { Fill = Color.LightSeaGreen, Stroke = Color.Argb((int)(1.0 * 255), (int)(0.13 * 255), (int)(0.58 * 255), (int)(0.58 * 255)), FontFamily = "GenericSansSerif" ,FontAttributes = TypefaceStyle.Bold };

			Rectangle rectangle = new Rectangle() { Content = "DataCoordinate", Width = 100, Height = 50, Location = new C1Point(37, 80), Attachment = AnnotationAttachment.DataCoordinate };
            rectangle.AnnotationStyle = new ChartStyle() { Fill = Color.SlateBlue, Stroke = Color.Argb((int)(1.0 * 255), (int)(0.29 * 255), (int)(0.25 * 255), (int)(0.57 * 255)), FontFamily = "GenericSansSerif" ,FontSize = 10 };

			Square square = new Square() { Content = "DataIndex", Length = 70, SeriesIndex = 0, PointIndex = 40, Attachment = AnnotationAttachment.DataIndex };
            square.AnnotationStyle = new ChartStyle() { Fill = Color.SandyBrown, Stroke = Color.Chocolate, FontAttributes = TypefaceStyle.Bold, FontFamily = "GenericSansSerif" };

			Polygon polygon = new Polygon() { Content = "polygonAnno", Attachment = AnnotationAttachment.Absolute };
			polygon.Points = CreatePoints();
			polygon.AnnotationStyle = new ChartStyle() { Fill = Color.Red, StrokeThickness = 3, Stroke = Color.Argb((int)(1.0 * 255), (int)(0.98 * 255), (int)(0.06 * 255), (int)(0.05 * 255)), FontAttributes = TypefaceStyle.Bold, FontFamily = "GenericSansSerif" };

            Line line = new Line() { Content = "Absolute", Start = new C1Point(50, 200), End = new C1Point(300, 350), Attachment = AnnotationAttachment.Absolute };
			line.AnnotationStyle = new ChartStyle() { StrokeThickness = 4, FontSize = 10, FontAttributes = TypefaceStyle.Bold, Stroke = Color.Argb((int)(1.0 * 255), (int)(0.20 * 255), (int)(0.81 * 255), (int)(0.82 * 255)), FontFamily = "GenericSansSerif" };

			Image image = new Image() { Location = new C1Point(12, 20), Attachment = AnnotationAttachment.DataCoordinate, Width = 30, Height = 30 };
            image.Source = BitmapFactory.DecodeResource(this.Resources, Resource.Drawable.xuni_butterfly);

			AnnotationLayer layer = new AnnotationLayer(ApplicationContext);
			layer.Annotations.Add(text);
			layer.Annotations.Add(ellipse);
			layer.Annotations.Add(circle);
			layer.Annotations.Add(rectangle);
			layer.Annotations.Add(square);
			layer.Annotations.Add(polygon);
			layer.Annotations.Add(line);
			layer.Annotations.Add(image);
			mChart.Layers.Add(layer);

        }

        private System.Collections.ObjectModel.ObservableCollection<C1Point> CreatePoints()
		{
			System.Collections.ObjectModel.ObservableCollection<C1Point> points = new System.Collections.ObjectModel.ObservableCollection<C1Point>();

			points.Add(new C1Point(100, 25));
			points.Add(new C1Point(50, 70));
			points.Add(new C1Point(75, 115));
			points.Add(new C1Point(125, 115));
			points.Add(new C1Point(150, 70));

			return points;
		}
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == global::Android.Resource.Id.Home)
            {
                Finish();
                return true;
            }
            else
            {
                return base.OnOptionsItemSelected(item);
            }
        }
    }
}
