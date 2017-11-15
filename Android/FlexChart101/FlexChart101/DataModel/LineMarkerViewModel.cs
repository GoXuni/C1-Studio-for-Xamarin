using System;
using System.Collections.Generic;
using C1.Android.Chart.Interaction;

namespace FlexChart101
{
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

        public string[] LineType
        {
            get
            {
                return Enum.GetNames(typeof(LineMarkerLines));
            }
        }

        public string[] LineMarkerInteraction
        {
            get
            {
                return Enum.GetNames(typeof(LineMarkerInteraction));
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
