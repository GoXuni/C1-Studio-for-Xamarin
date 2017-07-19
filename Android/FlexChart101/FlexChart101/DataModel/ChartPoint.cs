using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using Java.IO;
/**
* A class that encapsulates and manipulates series data
* 
* @author GrapeCity
*/
namespace FlexChart101.DataModel
{
    public class ChartPoint : Java.Lang.Object
    {
       static Random random = new Random();

        private const long serialVersionUID = 1L;

        private String name;
        private DateTime date;
        private int sales;
        private int expenses;
        private int downloads;
        private int high;
        private int low;
        private int open;
        private int close;
        private int count;
        private double sine;
        private double cosine;
        private String month;
        private double precipitation;
        private int temperature;
        private char letter;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public int Sales
        {
            get
            {
                return sales;
            }

            set
            {
                sales = value;
            }
        }

        public int Expenses
        {
            get
            {
                return expenses;
            }

            set
            {
                expenses = value;
            }
        }

        public int Downloads
        {
            get
            {
                return downloads;
            }

            set
            {
                downloads = value;
            }
        }

        public int High
        {
            get
            {
                return high;
            }

            set
            {
                high = value;
            }
        }

        public int Low
        {
            get
            {
                return low;
            }

            set
            {
                low = value;
            }
        }

        public int Open
        {
            get
            {
                return open;
            }

            set
            {
                open = value;
            }
        }

        public int Close
        {
            get
            {
                return close;
            }

            set
            {
                close = value;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }

            set
            {
                count = value;
            }
        }

        public double Sine
        {
            get
            {
                return sine;
            }

            set
            {
                sine = value;
            }
        }

        public double Cosine
        {
            get
            {
                return cosine;
            }

            set
            {
                cosine = value;
            }
        }

        public string Month
        {
            get
            {
                return month;
            }

            set
            {
                month = value;
            }
        }

        public double Precipitation
        {
            get
            {
                return precipitation;
            }

            set
            {
                precipitation = value;
            }
        }

        public int Temperature
        {
            get
            {
                return temperature;
            }

            set
            {
                temperature = value;
            }
        }

        public char Letter
        {
            get
            {
                return letter;
            }

            set
            {
                letter = value;
            }
        }
        public ChartPoint()
        {

        }
        public ChartPoint(int count, double d, double e)
        {

            this.Count = count;
            this.Sine = d;
            this.Cosine = e;
        }

        public ChartPoint(double sine)
        {
            this.Sine = sine;
        }

        public ChartPoint(String name, int sales, int expenses, int downloads)
        {
            this.Name = name;
            this.Sales = sales;
            this.Expenses = expenses;
            this.Downloads = downloads;
        }

        public ChartPoint(char letter, int count)
        {
            this.Count = count;
            this.Letter = letter;
        }

        public ChartPoint(int high, int low, int open, int close, DateTime date)
        {
            this.Date = date;
            this.High = high;
            this.Low = low;
            this.Open = open;
            this.Close = close;
        }

        public ChartPoint(int volume, int high, int low)
        {
            this.Sales = volume;
            this.High = high;
            this.Low = low;
        }


        public ChartPoint(String month, double precipitation, int temperature)
        {
            this.Month = month;
            this.Precipitation = precipitation;
            this.Temperature = temperature;
        }

        // a method to create a list of random objects of type ChartPoint
        public static IList<object> GetList()
        {
            //ObservableCollection<ChartPoint> list = new ObservableCollection<ChartPoint>();
            List<object> list = new List<object>();
            int n = 6; // number of series elements
            String[] countries =
            { "US", "Germany", "UK", "Japan", "Italy", "Greece", "India", "Canada" };

            for (int i = 0; i < n; i++)
            {
                list.Add(new ChartPoint(countries[i], random.Next(20000), random.Next(20000), random.Next(20000)));
            }
            return list;
        }

        public static ObservableCollection<ChartPoint> getLogList()
        {
            ObservableCollection<ChartPoint> list = new ObservableCollection<ChartPoint>();

            int n = 6; // number of series elements
            String[] countries =
            { "US", "Germany", "UK", "Japan", "Italy", "Greece", "India", "Canada" };
            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                int scale = random.Next(14);
                scale = (int)Math.Exp((double)scale);
                list.Add(new ChartPoint(countries[i], random.Next(scale), random.Next(scale), random.Next(scale)));
            }
            return list;
        }

        /**
         * a method to create a list of random objects of type ChartPoint with a fixed element size;
         * 
         * @param size
         *            - size of element of series.
         * */
        public static IList<object> GetList(int size)
        {
            IList<object> list = new List<object>();

            Random random = new Random();

            for (int i = 0; i < size; i++)
            {

                list.Add(new ChartPoint(i + "", random.Next(20000), random.Next(20000), random.Next(20000)));
            }
            return list;
        }
    }

    public class ZonesData : Java.Lang.Object
    {
        public int Number { get; set; }
        public double Score { get; set; }

        public ZonesData(int Number, double Score)
        {
            this.Number = Number;
            this.Score = Score;
        }

        // a method to create a list of zones sample objects of type ChartPoint
        public static IList<object> getZonesList(int nStudents, int nMaxPoints)
        {
            List<object> list = new List<object>();

            Random random = new Random();
            for (int i = 0; i < nStudents; i++)
            {
                ZonesData point = new ZonesData(i, nMaxPoints * 0.5 * (1 + random.NextDouble()));
                list.Add(point);
            }
            return list;
        }
    }
}
