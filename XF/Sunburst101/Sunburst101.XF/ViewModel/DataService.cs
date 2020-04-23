using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using C1.DataCollection;

namespace Sunburst101
{
    public class DataService
    {
        Random rnd = new Random();
        static DataService _default;

        public static DataService Instance
        {
            get
            {
                if (_default == null)
                {
                    _default = new DataService();
                }

                return _default;
            }
        }

        public static List<SunburstDataItem> CreateHierarchicalData()
        {
            Random rnd = Instance.rnd;

            List<string> years = new List<string>();
            List<List<string>> times = new List<List<string>>()
            {
                new List<string>() { "Jan", "Feb", "Mar"},
                new List<string>() { "Apr", "May", "June"},
                new List<string>() { "Jul", "Aug", "Sep"},
                new List<string>() { "Oct", "Nov", "Dec" }
            };

            List<SunburstDataItem> items = new List<SunburstDataItem>();
            var yearLen = Math.Max((int)Math.Round(Math.Abs(5 - Instance.rnd.NextDouble() * 10)), 3);
            int currentYear = DateTime.Now.Year;
            for (int i = yearLen; i > 0; i --)
            {
                years.Add((currentYear - i).ToString());
            }
            var quarterAdded = false;

            foreach (string y in years)
            {
                var i = years.IndexOf(y);
                var addQuarter = Instance.rnd.NextDouble() > 0.5;
                if (!quarterAdded && i == years.Count - 1)
                {
                    addQuarter = true;
                }
                var year = new SunburstDataItem() { Year = y};
                if (addQuarter)
                {
                    quarterAdded = true;

                    foreach (List<string> q in times)
                    {
                        var addMonth = Instance.rnd.NextDouble() > 0.5;
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
            Random rnd = Instance.rnd;
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

        public static C1DataCollection<Item> CreateGroupDataCollection()
        {
            var data = new List<Item>();
            var quarters = new string[] { "Q1", "Q2", "Q3", "Q4" };
            var months = new[]
            {
                new { Name = "Jan", Value = 1 },
                new { Name = "Feb", Value = 2 },
                new { Name = "Mar", Value = 3 },
                new { Name = "Apr", Value = 4 },
                new { Name = "May", Value = 5 },
                new { Name = "June", Value = 6 },
                new { Name = "Jul", Value = 7 },
                new { Name = "Aug", Value = 8 },
                new { Name = "Sep", Value = 9 },
                new { Name = "Oct", Value = 10 },
                new { Name = "Nov", Value = 11 },
                new { Name = "Dec", Value = 12 }
            };
            var year = DateTime.Now.Year;
            int yearLen, i, len = 100;
            var years = new List<int>();
            yearLen = 3;

            for (i = yearLen; i > 0; i--)
            {
                years.Add(year - i);
            }

            int y, q, m;
            for (i = 0; i < len; i++)
            {
                y = (int)Math.Floor(Instance.rnd.NextDouble() * yearLen);
                q = (int)Math.Floor(Instance.rnd.NextDouble() * 4);
                m = (int)Math.Floor(Instance.rnd.NextDouble() * 3);

                data.Add(new Item()
                {
                    Year = years[y],
                    Quarter = quarters[q],
                    MonthName = months[q].Name,
                    MonthValue = months[q].Value,
                    Value = Math.Round(Instance.rnd.NextDouble() * 100)
                });
            }
            var cv = new C1DataCollection<Item>(data);

            //Sort cannot work synchronize with group in current DataCollection
            SortDescription yearSortDescription = new SortDescription("Year", SortDirection.Ascending);
            SortDescription quarterSortDescription = new SortDescription("Quarter", SortDirection.Ascending);
            SortDescription monthSortDescription = new SortDescription("MonthValue", SortDirection.Ascending);
            SortDescription[] sortDescriptions = new SortDescription[] { yearSortDescription, quarterSortDescription, monthSortDescription };
            cv.SortAsync(sortDescriptions);

            GroupDescription yearGroupDescription = new GroupDescription("Year");
            GroupDescription quarterGroupDescription = new GroupDescription("Quarter");
            GroupDescription monthGroupDescription = new GroupDescription("MonthName");
            GroupDescription[] groupDescriptions = new GroupDescription[] { yearGroupDescription, quarterGroupDescription, monthGroupDescription };
         //   cv.GroupAsync(groupDescriptions);

            return cv;
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

    public class Item
    {
        public int Year { get; set; }
        public string Quarter { get; set; }
        public string MonthName { get; set; }
        public int MonthValue { get; set; }
        public double Value { get; set; }
    }
}
