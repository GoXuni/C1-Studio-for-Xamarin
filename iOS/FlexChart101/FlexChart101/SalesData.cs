using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using Foundation;
using UIKit;

namespace FlexChart101
{
    class SalesData
    {
        #region ** fields

        static Random _rnd = new Random();
        static string[] _countries = new string[] { "US", "Germany", "UK", "Japan", "Italy", "Greece" };

        #endregion

        #region ** initialization

        public SalesData()
        {
            this.Name = string.Empty;
            this.Sales = 0;
            this.Expenses = 0;
            this.Downloads = 0;
            this.Date = DateTime.Now;
        }

        public SalesData(string name, double sales, double expenses, double downloads, DateTime date)
        {
            this.Name = name;
            this.Sales = sales;
            this.Expenses = expenses;
            this.Downloads = downloads;
            this.Date = date;
        }

        #endregion

        #region ** object model

        [Export("Name")]
        public string Name { get; set; }
        [Export("Sales")]
        public double Sales { get; set; }
        [Export("Expenses")]
        public double Expenses { get; set; }
        [Export("Downloads")]
        public double Downloads { get; set; }

        public DateTime Date { get; set; }
        [Export("Date")]
        public NSDate iOSDate
        {
            get
            {
                return DateTimeToNSDate(Date);
            }
            set
            {
                Date = NSDateToDateTime(value);
            }
        }
        #endregion

        #region ** implementation

        // ** static list provider
		public static List<SalesData> GetSalesDataList()
        {
			List<SalesData>  array = new List<SalesData> ();
            for (int i = 0; i < GetCountries().Length; i++)
            {
                array.Add(new SalesData
                {
                    Sales = _rnd.NextDouble() * 10000,
                    Expenses = _rnd.NextDouble() * 5000,
                    Downloads = _rnd.Next(20000),
                    Date = DateTime.Now.AddDays(i),
					Name = GetCountries()[i]
                });
            }
            return array;
        }

		public static List<SalesData> GetSalesDataList2()
		{
			List<SalesData> array = new List<SalesData>();
			for (int i = 0; i < GetCountries().Length; i++)
			{
				array.Add(new SalesData
				{
					Sales = _rnd.Next(100) * 100,
					Expenses = _rnd.Next(100) * 50,
					Downloads = _rnd.Next(100),
					Date = DateTime.Now.AddDays(i),
					Name = GetCountries()[i]
				});
			}
			return array;
		}

        public NSDate DateTimeToNSDate(DateTime date)
        {
            if (date.Kind == DateTimeKind.Unspecified)
                date = DateTime.SpecifyKind(date, DateTimeKind.Utc);
            return (NSDate)date;
        }

        public DateTime NSDateToDateTime(NSDate date)
        {
            // NSDate has a wider range than DateTime, so clip
            // the converted date to DateTime.Min|MaxValue.
            double secs = date.SecondsSinceReferenceDate;
            if (secs < -63113904000)
                return DateTime.MinValue;
            if (secs > 252423993599)
                return DateTime.MaxValue;
            return (DateTime)date;
        }

        // ** static value providers
        public static string[] GetCountries() { return _countries; }


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

        #endregion
    }
}