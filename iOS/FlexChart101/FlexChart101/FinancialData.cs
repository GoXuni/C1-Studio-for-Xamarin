using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexChart101
{
    public class FinancialData
    {
        public DateTime Date { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
        public double Volume { get; set; }
		public int Index { get; set; }

        public FinancialData()
        {

        }
        public FinancialData(DateTime date, double high, double low, double open, double close, double vol)
        {
            this.Date = date;
            this.High = high;
            this.Low = low;
            this.Open = open;
            this.Close = close;
            this.Volume = vol;
        }

		public static List<FinancialData> GetFinancialDataList()
		{
			Random rnd = new Random();

			List<FinancialData> listdata = new List<FinancialData>();
			for (int i = 0; i < 20; i++)
			{
				FinancialData data = new FinancialData();
				data.Date = DateTime.Today.AddDays(i);
				data.Index = i;

				if (i > 0)
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
    }
}
