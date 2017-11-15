using System.Xml.Serialization;
using UIKit;
using CoreGraphics;

namespace Sunburst101.Periodic
{
	public class Element : IChartModel
	{
        internal static UIView layout;
        private static UILabel symbol;
        private static UILabel name;
        private static UILabel atomicNumber;
        private static UILabel atomicWeight;

		[XmlElement("atomic-number")]
		public double AtomicNumber { get; set; }

		[XmlElement("atomic-weight")]
		public double AtomicWeight { get; set; }

		[XmlElement("element")]
		public string ElementName { get; set; }

		[XmlElement("symbol")]
		public string Symbol { get; set; }

		[XmlElement("type")]
		public string Type { get; set; }

		public double Value { get { return 1; } }

        public UIView GetUserView(CGRect rect)
		{
			if (layout == null)
			{
                layout = new UIView(new CGRect(0,0,rect.Width,rect.Height));
                layout.BackgroundColor = UIColor.Clear;

                symbol = new UILabel(new CGRect(0,0,rect.Width,rect.Height*3/16));
                symbol.Font = UIFont.BoldSystemFontOfSize(15);
                symbol.TextAlignment = UITextAlignment.Center;
				layout.Add(symbol);
                symbol.BackgroundColor = UIColor.Clear;

				name = new UILabel(new CGRect(0, rect.Height * 3 / 16, rect.Width, rect.Height * 3 / 16));
				name.Font = UIFont.SystemFontOfSize(12);
				name.TextAlignment = UITextAlignment.Center;
				layout.Add(name);
                name.BackgroundColor = UIColor.Clear;

				atomicNumber = new UILabel(new CGRect(0, rect.Height * 6 / 16, rect.Width, rect.Height * 3 / 16));
				atomicNumber.Font = UIFont.SystemFontOfSize(8);
				atomicNumber.TextAlignment = UITextAlignment.Center;
				layout.Add(atomicNumber);
                atomicNumber.BackgroundColor = UIColor.Clear;

				atomicWeight = new UILabel(new CGRect(0, rect.Height * 9 / 16, rect.Width, rect.Height * 3 / 16));
				atomicWeight.Font = UIFont.SystemFontOfSize(8);
				atomicWeight.TextAlignment = UITextAlignment.Center;
				layout.Add(atomicWeight);
                atomicWeight.BackgroundColor = UIColor.Clear;
			}

			symbol.Text = this.Symbol;
			name.Text = this.ElementName;
			atomicNumber.Text = "AtomicNumber: " + this.AtomicNumber;
			atomicWeight.Text = "AtomicWeight: " + this.AtomicWeight;

			return layout;
		}
	}

	public class ElementRoot
	{
		[XmlElement("id")]
		public int Id { get; set; }

		[XmlElement("fields")]
		public Element Element { get; set; }
	}

	[XmlRoot("Elements")]
	public class ElementsCollection
	{
		[XmlElement("PeriodicElement")]
		public ElementRoot[] Elements { get; set; }
	}
}
