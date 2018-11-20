using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private int index;

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

        public int Index
        {
            get
            {
                return index;
            }

            set
            {
                index = value;
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

        public ChartPoint(String month, int high, int low)
        {
            this.Month = month;
            this.high = high;
            this.low = low;
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

        public static object[] CreateHierarchicalData()
        {
            var data = new object[] {
             new {
              type = "Music",
               items = new [] {
                new {
                 type = "Country",
                  items = new [] {
                   new {
                    type = "Classic Country",
                     sales = rand()
                   }, new {
                    type = "Cowboy Country",
                     sales = rand()
                   }, new {
                    type = "Outlaw Country",
                     sales = rand()
                   }, new {
                    type = "Western Swing",
                     sales = rand()
                   }, new {
                    type = "Roadhouse Country",
                     sales = rand()
                   }
                  }
                }, new {
                 type = "Rock",
                  items = new [] {
                   new {
                    type = "Hard Rock",
                     sales = rand()
                   }, new {
                    type = "Blues Rock",
                     sales = rand()
                   }, new {
                    type = "Funk Rock",
                     sales = rand()
                   }, new {
                    type = "Rap Rock",
                     sales = rand()
                   }, new {
                    type = "Guitar Rock",
                     sales = rand()
                   }, new {
                    type = "Progressive Rock",
                     sales = rand()
                   }
                  }
                }, new {
                 type = "Classical",
                  items = new [] {
                   new {
                    type = "Symphonies",
                     sales = rand()
                   }, new {
                    type = "Chamber Music",
                     sales = rand()
                   }
                  }
                }, new {
                 type = "Soundtracks",
                  items = new [] {
                   new {
                    type = "Movie Soundtracks",
                     sales = rand()
                   }, new {
                    type = "Musical Soundtracks",
                     sales = rand()
                   }
                  }
                }, new {
                 type = "Jazz",
                  items = new [] {
                   new {
                    type = "Smooth Jazz",
                     sales = rand()
                   }, new {
                    type = "Vocal Jazz",
                     sales = rand()
                   }, new {
                    type = "Jazz Fusion",
                     sales = rand()
                   }, new {
                    type = "Swing Jazz",
                     sales = rand()
                   }, new {
                    type = "Cool Jazz",
                     sales = rand()
                   }, new {
                    type = "Traditional Jazz",
                     sales = rand()
                   }
                  }
                }, new {
                 type = "Electronic",
                  items = new [] {
                   new {
                    type = "Electronica",
                     sales = rand()
                   }, new {
                    type = "Disco",
                     sales = rand()
                   }, new {
                    type = "House",
                     sales = rand()
                   }
                  }
                }
               }
             }, new {
              type = "Video",
               items = new [] {
                new {
                 type = "Movie",
                  items = new [] {
                   new {
                    type = "Kid & Family",
                     sales = rand()
                   }, new {
                    type = "Action & Adventure",
                     sales = rand()
                   }, new {
                    type = "Animation",
                     sales = rand()
                   }, new {
                    type = "Comedy",
                     sales = rand()
                   }, new {
                    type = "Drama",
                     sales = rand()
                   }, new {
                    type = "Romance",
                     sales = rand()
                   }
                  }
                }, new {
                 type = "TV",
                  items = new [] {
                   new {
                    type = "Science Fiction",
                     sales = rand()
                   }, new {
                    type = "Documentary",
                     sales = rand()
                   }, new {
                    type = "Fantasy",
                     sales = rand()
                   }, new {
                    type = "Military & War",
                     sales = rand()
                   }, new {
                    type = "Horror",
                     sales = rand()
                   }
                  }
                }
               }
             }, new {
              type = "Books",
               items = new [] {
                new {
                 type = "Arts & Photography",
                  items = new [] {
                   new {
                    type = "Architecture",
                     sales = rand()
                   }, new {
                    type = "Graphic Design",
                     sales = rand()
                   }, new {
                    type = "Drawing",
                     sales = rand()
                   }, new {
                    type = "Photography",
                     sales = rand()
                   }, new {
                    type = "Performing Arts",
                     sales = rand()
                   }
                  }
                }, new {
                 type = "Children's Books",
                  items = new [] {
                   new {
                    type = "Beginning Readers",
                     sales = rand()
                   }, new {
                    type = "Board Books",
                     sales = rand()
                   }, new {
                    type = "Chapter Books",
                     sales = rand()
                   }, new {
                    type = "Coloring Books",
                     sales = rand()
                   }, new {
                    type = "Picture Books",
                     sales = rand()
                   }, new {
                    type = "Sound Books",
                     sales = rand()
                   }
                  }
                }, new {
                 type = "History",
                  items = new [] {
                   new {
                    type = "Ancient",
                     sales = rand()
                   }, new {
                    type = "Medieval",
                     sales = rand()
                   }, new {
                    type = "Renaissance",
                     sales = rand()
                   }
                  }
                }, new {
                 type = "Mystery",
                  items = new [] {
                   new {
                    type = "Mystery",
                     sales = rand()
                   }, new {
                    type = "Thriller & Suspense",
                     sales = rand()
                   }
                  }
                }, new {
                 type = "Romance",
                  items = new [] {
                   new {
                    type = "Action & Adventure",
                     sales = rand()
                   }, new {
                    type = "Holidays",
                     sales = rand()
                   }, new {
                    type = "Romantic Comedy",
                     sales = rand()
                   }, new {
                    type = "Romantic Suspense",
                     sales = rand()
                   }, new {
                    type = "Western",
                     sales = rand()
                   }, new {
                    type = "Historical",
                     sales = rand()
                   }
                  }
                }, new {
                 type = "Sci-Fi & Fantasy",
                  items = new [] {
                   new {
                    type = "Fantasy",
                     sales = rand()
                   }, new {
                    type = "Gaming",
                     sales = rand()
                   }, new {
                    type = "Science Fiction",
                     sales = rand()
                   }
                  }
                }
               }
             }, new {
              type = "Electronics",
               items = new object[] {
                new {
                 type = "Camera",
                  items = new [] {
                   new {
                    type = "Digital Cameras",
                     sales = rand()
                   }, new {
                    type = "Film Photography",
                     sales = rand()
                   }, new {
                    type = "Lenses",
                     sales = rand()
                   }, new {
                    type = "Video",
                     sales = rand()
                   }, new {
                    type = "Accessories",
                     sales = rand()
                   }
                  }
                }, new {
                 type = "Headphones",
                  items = new [] {
                   new {
                    type = "Earbud headphones",
                     sales = rand()
                   }, new {
                    type = "Over-ear headphones",
                     sales = rand()
                   }, new {
                    type = "On-ear headphones",
                     sales = rand()
                   }, new {
                    type = "Bluetooth headphones",
                     sales = rand()
                   }, new {
                    type = "Noise-cancelling headphones",
                     sales = rand()
                   }, new {
                    type = "Audiophile headphones",
                     sales = rand()
                   }
                  }
                }, new {
                 type = "Cell Phones",
                  items = new object[] {
                   new {
                    type = "Cell Phones",
                     sales = rand()
                   }, new {
                    type = "Accessories",
                     items = new [] {
                      new {
                       type = "Batteries",
                        sales = rand()
                      }, new {
                       type = "Bluetooth Headsets",
                        sales = rand()
                      }, new {
                       type = "Bluetooth Speakers",
                        sales = rand()
                      }, new {
                       type = "Chargers",
                        sales = rand()
                      }, new {
                       type = "Screen Protectors",
                        sales = rand()
                      }
                     }
                   }
                  }
                }, new {
                 type = "Wearable Technology",
                  items = new [] {
                   new {
                    type = "Activity Trackers",
                     sales = rand()
                   }, new {
                    type = "Smart Watches",
                     sales = rand()
                   }, new {
                    type = "Sports & GPS Watches",
                     sales = rand()
                   }, new {
                    type = "Virtual Reality Headsets",
                     sales = rand()
                   }, new {
                    type = "Wearable Cameras",
                     sales = rand()
                   }, new {
                    type = "Smart Glasses",
                     sales = rand()
                   }
                  }
                }
               }
             }, new {
              type = "Computers & Tablets",
               items = new [] {
                new {
                 type = "Desktops",
                  items = new [] {
                   new {
                    type = "All-in-ones",
                     sales = rand()
                   }, new {
                    type = "Minis",
                     sales = rand()
                   }, new {
                    type = "Towers",
                     sales = rand()
                   }
                  }
                }, new {
                 type = "Laptops",
                  items = new [] {
                   new {
                    type = "2 in 1 laptops",
                     sales = rand()
                   }, new {
                    type = "Traditional laptops",
                     sales = rand()
                   }
                  }
                }, new {
                 type = "Tablets",
                  items = new [] {
                   new {
                    type = "iOS",
                     sales = rand()
                   }, new {
                    type = "Andriod",
                     sales = rand()
                   }, new {
                    type = "Fire os",
                     sales = rand()
                   }, new {
                    type = "Windows",
                     sales = rand()
                   }
                  }
                }
               }
             }
            };
            return data;
        }

        static int rand()
        {
            Random rnd = new Random();
            return rnd.Next(10, 100);
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
