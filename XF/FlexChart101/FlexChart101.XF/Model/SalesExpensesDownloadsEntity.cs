using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexChart101
{
    public class SalesExpensesDownloadsEntity
    {
        public string Name { get; set; }

        public double Sales { get; set; }

        public double Expenses { get; set; }

        public double Downloads { get; set; }

        public DateTime Date { get; set; }

        public double ExtraSeries1 { get; set; }
        public double ExtraSeries2 { get; set; }
        public double ExtraSeries3 { get; set; }

        public SalesExpensesDownloadsEntity()
        {
            this.Name = string.Empty;
            this.Sales = 0;
            this.Expenses = 0;
            this.Downloads = 0;
            this.Date = DateTime.Now;
        }

        public SalesExpensesDownloadsEntity(string name, double sales, double expenses, double downloads, DateTime date)
        {
            this.Name = name;
            this.Sales = sales;
            this.Expenses = expenses;
            this.Downloads = downloads;
            this.Date = date;
        }
    }

    public class ExtraEntity : SalesExpensesDownloadsEntity
    {
        public string Name { get; set; }

        public double Sales { get; set; }

        public double Expenses { get; set; }

        public double Downloads { get; set; }

        public DateTime Date { get; set; }

        public double ExtraSeries3 { get; set; }
        public double ExtraSeries4 { get; set; }
        public double ExtraSeries5 { get; set; }

        public double BubbleSize0 { get; set; }
        public double BubbleSize1 { get; set; }
        public double BubbleSize2 { get; set; }
        public double BubbleSize3 { get; set; }
        public double BubbleSize4 { get; set; }
        public double BubbleSize5 { get; set; }

        public ExtraEntity(string name, double sales, double expenses, double downloads, DateTime date) 
            : base(name, sales, expenses, downloads, date)
        {
            this.Name = name;
            this.Sales = sales;
            this.Expenses = expenses;
            this.Downloads = downloads;
            this.Date = date;
        }
    }
}
