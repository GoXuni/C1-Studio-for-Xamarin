using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;


namespace FlexChart101
{
    public class SunburstViewModel : INotifyPropertyChanged
    {
        private string _legendPosition = "Auto";
        private string _selectedItemPosition = "Top";

        public List<SunburstDataItem> HierarchicalData
        {
            get
            {
                return CreateHierarchicalData();
            }
        }

        public List<FlatDataItem> FlatData
        {
            get
            {
                return CreateFlatData();
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static List<SunburstDataItem> CreateHierarchicalData()
        {
            Random rnd = new Random();

            List<string> years = new List<string>();
            List<List<string>> times = new List<List<string>>()
            {
                new List<string>() { "Jan", "Feb", "Mar"},
                new List<string>() { "Apr", "May", "June"},
                new List<string>() { "Jul", "Aug", "Sep"},
                new List<string>() { "Oct", "Nov", "Dec" }
            };

            List<SunburstDataItem> items = new List<SunburstDataItem>();
            var yearLen = Math.Max((int)Math.Round(Math.Abs(5 - rnd.NextDouble() * 10)), 3);
            int currentYear = DateTime.Now.Year;
            for (int i = yearLen; i > 0; i--)
            {
                years.Add((currentYear - i).ToString());
            }
            var quarterAdded = false;

            foreach (string y in years)
            {
                var i = years.IndexOf(y);
                var addQuarter = rnd.NextDouble() > 0.5;
                if (!quarterAdded && i == years.Count - 1)
                {
                    addQuarter = true;
                }
                var year = new SunburstDataItem() { Year = y };
                if (addQuarter)
                {
                    quarterAdded = true;

                    foreach (List<string> q in times)
                    {
                        var addMonth = rnd.NextDouble() > 0.5;
                        int idx = times.IndexOf(q);
                        var quar = "Q" + (idx + 1);
                        var quarters = new SunburstDataItem() { Year = y, Quarter = quar };
                        if (addMonth)
                        {
                            foreach (string m in q)
                            {
                                quarters.Items.Add(new SunburstDataItem()
                                {
                                    Year = y,
                                    Quarter = quar,
                                    Month = m,
                                    Value = rnd.Next(20, 30)
                                });
                            };
                        }
                        else
                        {
                            quarters.Value = rnd.Next(80, 100);
                        }
                        year.Items.Add(quarters);
                    };
                }
                else
                {
                    year.Value = rnd.Next(80, 100);
                }
                items.Add(year);
            };

            return items;
        }

        public static List<FlatDataItem> CreateFlatData()
        {
            Random rnd = new Random();
            List<string> years = new List<string>();
            List<List<string>> times = new List<List<string>>()
            {
                new List<string>() { "Jan", "Feb", "Mar"},
                new List<string>() { "Apr", "May", "June"},
                new List<string>() { "Jul", "Aug", "Sep"},
                new List<string>() { "Oct", "Nov", "Dec" }
            };

            List<FlatDataItem> items = new List<FlatDataItem>();
            var yearLen = Math.Max((int)Math.Round(Math.Abs(5 - rnd.NextDouble() * 10)), 3);
            int currentYear = DateTime.Now.Year;
            for (int i = yearLen; i > 0; i--)
            {
                years.Add((currentYear - i).ToString());
            }
            var quarterAdded = false;
            foreach (string y in years)
            {

                var i = years.IndexOf(y);
                var addQuarter = rnd.NextDouble() > 0.5;
                if (!quarterAdded && i == years.Count - 1)
                {
                    addQuarter = true;
                }
                if (addQuarter)
                {
                    quarterAdded = true;
                    foreach (List<string> q in times)
                    {
                        var addMonth = rnd.NextDouble() > 0.5;
                        int idx = times.IndexOf(q);
                        var quar = "Q" + (idx + 1);
                        if (addMonth)
                        {
                            foreach (string m in q)
                            {
                                items.Add(new FlatDataItem()
                                {
                                    Year = y,
                                    Quarter = quar,
                                    Month = m,
                                    Value = rnd.Next(30, 40)
                                });
                            };
                        }
                        else
                        {
                            items.Add(new FlatDataItem()
                            {
                                Year = y,
                                Quarter = quar,
                                Value = rnd.Next(80, 100)
                            });
                        }
                    };
                }
                else
                {
                    items.Add(new FlatDataItem()
                    {
                        Year = y.ToString(),
                        Value = rnd.Next(80, 100)
                    });
                }
            };

            return items;
        }
    }


    public class FlatDataItem
    {
        public string Year { get; set; }
        public string Quarter { get; set; }
        public string Month { get; set; }
        public double Value { get; set; }
    }

    public class SunburstDataItem
    {
        List<SunburstDataItem> _items;

        public string Year { get; set; }
        public string Quarter { get; set; }
        public string Month { get; set; }
        public double Value { get; set; }
        public List<SunburstDataItem> Items
        {
            get
            {
                if (_items == null)
                {
                    _items = new List<SunburstDataItem>();
                }

                return _items;
            }
        }
    }
}
