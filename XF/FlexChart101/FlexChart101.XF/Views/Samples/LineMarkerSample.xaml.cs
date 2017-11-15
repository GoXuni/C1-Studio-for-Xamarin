using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using C1.Xamarin.Forms.Chart.Interaction;
using FlexChart101.Resources;
using C1.Xamarin.Forms.Chart;

namespace FlexChart101
{
    public partial class LineMarkerSample
    {
        double[] verticalPositions = { double.NaN, 0, 0.25, 0.5, 0.75, 1 };
        public LineMarkerSample()
        {
            InitializeComponent();
            Title = AppResources.LineMarkerTitle;

            pickerLineType.Title = AppResources.LineType;
            pickerAligment.Title = AppResources.LineMarkerAlignment;
            this.pickerInteraction.Title = AppResources.Interaction;

            this.flexChart.ItemsSource = new LineMarkerViewModel().Items;

            foreach (var item in Enum.GetNames(typeof(LineMarkerLines)))
            {
                this.pickerLineType.Items.Add(item);
            }
            foreach (var item in Enum.GetNames(typeof(LineMarkerAlignment)))
            {
                this.pickerAligment.Items.Add(item);
            }
            foreach (var item in Enum.GetNames(typeof(LineMarkerInteraction)))
            {
                this.pickerInteraction.Items.Add(item);
            }

            this.pickerLineType.SelectedIndex = 1;
            this.pickerAligment.SelectedIndex = 2;
            this.pickerInteraction.SelectedIndex = 1;
            
            initMarker();

            lineMarker.DragLines = true;

            this.flexChart.SeriesVisibilityChanged += FlexChart_SeriesVisibilityChanged;
        }

        private void FlexChart_SeriesVisibilityChanged(object sender, SeriesEventArgs e)
        {
            initMarker();
        }

        void pickerLineType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lineMarker.Lines = (LineMarkerLines)Enum.Parse(typeof(LineMarkerLines), this.pickerLineType.Items[this.pickerLineType.SelectedIndex]);
        }
        void pickerAligment_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lineMarker.Alignment = (LineMarkerAlignment)Enum.Parse(typeof(LineMarkerAlignment), this.pickerAligment.Items[this.pickerAligment.SelectedIndex]);
        }
        void pickerInterraction_SelectedIndexChanged(object sender, EventArgs e)
        {
              this.lineMarker.Interaction = (LineMarkerInteraction)Enum.Parse(typeof(LineMarkerInteraction), this.pickerInteraction.Items[this.pickerInteraction.SelectedIndex]);
        }

        private StackLayout layout ;
        private Label xLabel;
        private IList<Label> yLabels = new List<Label>();
        private void initMarker()
        {
            yLabels.Clear();
            layout = new StackLayout();
            xLabel = new Label();
            xLabel.VerticalOptions = LayoutOptions.FillAndExpand;
            xLabel.HorizontalOptions = LayoutOptions.FillAndExpand;
            
            layout.Padding = new Thickness(5,5,5,5);
            for (int index = 0; index < flexChart.Series.Count; index++)
            {
                if (flexChart.Series[index].Visibility == ChartSeriesVisibilityType.Visible)
                {
                    var series = flexChart.Series[index];
                    var fill = (int)((IChart)flexChart).GetColor(index);
                    Label yLabel = new Label();
                    yLabel.VerticalOptions = LayoutOptions.FillAndExpand;
                    yLabel.HorizontalOptions = LayoutOptions.FillAndExpand;
                    var bytes = BitConverter.GetBytes(fill);
                    yLabel.TextColor = Color.FromRgba(bytes[2], bytes[1], bytes[0], bytes[3]);
                    yLabels.Add(yLabel);
                    layout.Children.Add(yLabel);
                }
                   
            }

            if (layout.Children.Count > 0)
            {
                layout.Children.Insert(0, xLabel);
                layout.IsVisible = true;
            }
            else
            {
                layout.IsVisible = false;
            }

            layout.BackgroundColor = Color.Gray;
            lineMarker.Content = layout;
        }
        
        private void OnLineMarkerPositionChanged(object sender, PositionChangedArgs e)
        {
            if (flexChart != null)
            {
                var info = flexChart.HitTest(new Point(e.Position.X, double.NaN));
                if (info == null)
                {
                    return;
                }
                int pointIndex = info.PointIndex;
                if (pointIndex < 0)
                {
                    return;
                }
                xLabel.Text = string.Format("{0:MM-dd}", info.X);
                
                for (int index = 0, i=0; index < flexChart.Series.Count; index++)
                {
                    if (flexChart.Series[index].Visibility == ChartSeriesVisibilityType.Visible)
                    {
                        var series = flexChart.Series[index];
                        var value = series.GetValues(0)[pointIndex];

                        var fill = (int)((IChart)flexChart).GetColor(index);
                        string content = string.Format("{0} = {1}", series.SeriesName, string.Format("{0:f0}", value));
                        Label yLabel = yLabels[i];
                        yLabel.Text = content;

                        i++;
                    }
                       
                }
            }

        }
    }

    public class LineMarkerViewModel
    {
        const int Count = 300;
        Random rnd = new Random();

        public List<LineMarkerSampleDataItem> Items
        {
            get
            {
                List<LineMarkerSampleDataItem> items = new List<LineMarkerSampleDataItem>();
                DateTime date = new DateTime(2016, 1, 1);
                for (var i = 0; i < Count; i++)
                {
                    var item = new LineMarkerSampleDataItem()
                    {
                        Date = date.AddDays(i),
                        Input = rnd.Next(10, 20),
                        Output = rnd.Next(0, 10)
                    };
                    items.Add(item);
                }

                return items;
            }
        }

        public List<string> LineType
        {
            get
            {
                return Enum.GetNames(typeof(LineMarkerLines)).ToList();
            }
        }

        public List<string> LineMarkerInteraction
        {
            get
            {
                return Enum.GetNames(typeof(LineMarkerInteraction)).ToList();
            }
        }
    }

    public class LineMarkerSampleDataItem
    {
        public int Input { get; set; }
        public int Output { get; set; }
        public DateTime Date { get; set; }
    }
    
}
