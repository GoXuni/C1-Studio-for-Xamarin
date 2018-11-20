using System;
using System.Collections.Generic;
using C1.Xamarin.Forms.Chart;

namespace FlexChart101
{
    public static class ChartSampleFactory
    {
        //public static FlexChart GetFlexChartSample(ChartSample chartSample)
        //{
        //    switch (chartSample.SampleDataType)
        //    {
        //        case (int)ChartSampleDataType.SALES_EXPENSES_DOWNLOADS:
        //            return SalesExpensesDownloads();
        //        case (int)ChartSampleDataType.BUBBLE:
        //            return Bubble();
        //        //case (int)ChartSampleDataType.FINANCIAL:
        //        //    return FinancialChart();
        //    }
        //    return null;
        //}

        public static IEnumerable<SalesExpensesDownloadsEntity> CreateEntityList()
        {
            List<SalesExpensesDownloadsEntity> entityList = new List<SalesExpensesDownloadsEntity>();

            //TODO: add culture
            string[] countries = new string[] { "US", "Germany", "UK", "Japan", "Italy", "Greece" };

            Random random = new Random();

            for (int i = 0; i < countries.Length; i++)
            {
                double sales = random.NextDouble() * 10000;
                double expenses = random.NextDouble() * 5000;
                double downloads = Math.Round(random.NextDouble() * 20000);
               
                entityList.Add(new SalesExpensesDownloadsEntity(countries[i], sales, expenses, downloads, DateTime.Today.AddDays(i)));
            }
            return entityList;
        }

        public static IEnumerable<ExtraEntity> CreateExtraEntityList()
        {
            List<ExtraEntity> entityList = new List<ExtraEntity>();

            //TODO: add culture
            string[] countries = new string[] { "US", "Germany", "UK", "Japan", "Italy", "Greece" };

            Random random = new Random();

            for (int i = 0; i < countries.Length; i++)
            {
                double sales = random.NextDouble() * 10000;
                double expenses = random.NextDouble() * 5000;
                double downloads = Math.Round(random.NextDouble() * 20000);

                ExtraEntity entity = new ExtraEntity(countries[i], sales, expenses, downloads, DateTime.Today.AddDays(i));
                entity.ExtraSeries3 = Math.Round(random.NextDouble() * 20000);
                entity.ExtraSeries4 = Math.Round(random.NextDouble() * 20000);
                entity.ExtraSeries5 = Math.Round(random.NextDouble() * 20000);

                entity.BubbleSize0 = Math.Round(random.NextDouble() * 10);
                entity.BubbleSize1 = Math.Round(random.NextDouble() * 10);
                entity.BubbleSize2 = Math.Round(random.NextDouble() * 10);
                entity.BubbleSize3 = Math.Round(random.NextDouble() * 10);
                entity.BubbleSize4 = Math.Round(random.NextDouble() * 10);
                entity.BubbleSize5 = Math.Round(random.NextDouble() * 10);

                entityList.Add(entity);
            }
            return entityList;
        }

        public static IEnumerable<SalesExpensesDownloadsEntity> CreateEntityList2()
        {
            List<SalesExpensesDownloadsEntity> entityList = new List<SalesExpensesDownloadsEntity>();

            //TODO: add culture
            string[] countries = new string[] { "US", "Germany", "UK", "Japan", "Italy", "Greece" };

            Random random = new Random();

            for (int i = 0; i < countries.Length; i++)
            {
                double sales = random.Next(10, 50) * 100;
                double expenses = random.Next(10, 50) * 500;
                double downloads = random.Next(10, 50) * 200;

                entityList.Add(new SalesExpensesDownloadsEntity(countries[i], sales, expenses, downloads, DateTime.Today.AddDays(i)));
            }
            return entityList;
        }
        
        public static IEnumerable<ZonesData> GetZonesData(int nStudents,int nMaxPoints)
        {
            Random random = new Random();
            for (int i = 0; i < nStudents; i++)
            {
                yield return new ZonesData()
                {
                    Number = i,
                    Score = nMaxPoints * 0.5 * (1 + random.NextDouble()),
                };
            }
        }
        public static FlexChart SalesExpensesDownloads()
        {
            FlexChart chart = new FlexChart();

            chart.BindingX = "Name";

            //TODO: add culture
            chart.Series.Add(new ChartSeries() { SeriesName = "Sales", Binding = "Sales" });
            chart.Series.Add(new ChartSeries() { SeriesName = "Expenses", Binding = "Expenses" });
            chart.Series.Add(new ChartSeries() { SeriesName = "Downloads", Binding = "Downloads" });

            chart.ItemsSource = CreateEntityList();

            return chart;
        }
        private static FlexChart Bubble()
        {
            FlexChart chart = new FlexChart() { ChartType = ChartType.Bubble };

            chart.BindingX = "Name";

            chart.Series.Add(new ChartSeries() { SeriesName = "Sales", Binding = "Sales,Downloads" });
            chart.Series.Add(new ChartSeries() { SeriesName = "Expenses", Binding = "Expenses,Downloads" });

            chart.ItemsSource = CreateEntityList();

            return chart;
        }
        public static List<FinancialData> FinancialData()
        {
            Random rnd = new Random();

            List<FinancialData> listdata = new List<FinancialData>();
            for (int i = 0; i < 20; i++)
            {
                FinancialData data = new FinancialData();
                data.Date = DateTime.Today.AddDays(i);

                
                if (i > 0 && !double.IsNaN(listdata[i - 1].Close) )
                    data.Open = listdata[i - 1].Close;
                else
                    data.Open = 1000;

                data.High = data.Open + rnd.Next(20);
                data.Low = data.Open - rnd.Next(20);
                data.Close = rnd.Next((int)data.Low, (int)data.High);
                data.Volume = rnd.Next(40, 100);
                listdata.Add(data);
            }
            return listdata;
        }
        public static IEnumerable<ChartType> GetBasicChartTypes()
        {
            yield return ChartType.Column;
           yield return ChartType.Bar;
           yield return ChartType.Scatter;
           yield return ChartType.Line;
           yield return ChartType.LineSymbols;
           yield return ChartType.Area;
           yield return ChartType.Spline;
           yield return ChartType.SplineSymbols;
           yield return ChartType.SplineArea;
           yield return ChartType.Step;
           yield return ChartType.StepSymbols;
           yield return ChartType.StepArea;
        }

        public static IEnumerable<ChartType> GetAllChartTypes()
        {
            yield return ChartType.Column;
            yield return ChartType.Bar;
            yield return ChartType.Scatter;
            yield return ChartType.Line;
            yield return ChartType.LineSymbols;
            yield return ChartType.Area;
            yield return ChartType.Spline;
            yield return ChartType.SplineSymbols;
            yield return ChartType.SplineArea;
            yield return ChartType.Bubble;
            yield return ChartType.Candlestick;
            yield return ChartType.HighLowOpenClose;
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

    public class ZonesData
    {
        public int Number { get; set; }
        public double Score { get; set; }
    }

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
                            Y = rnd.Next(10, 80)
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
}
