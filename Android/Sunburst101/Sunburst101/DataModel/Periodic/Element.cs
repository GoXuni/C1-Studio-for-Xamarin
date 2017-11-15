using System.Xml.Serialization;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Sunburst101.Periodic
{
    public class Element: IChartModel
    {
        internal static LinearLayout layout;
        private static TextView symbol;
        private static TextView name;
        private static TextView atomicNumber;
        private static TextView atomicWeight;

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

        public ViewGroup GetUserView(Context context)
        {
            if (layout == null)
            {
                layout = new LinearLayout(context);
                layout.Orientation = Orientation.Vertical;

                symbol = new TextView(context);
                symbol.SetTextSize(ComplexUnitType.Dip ,18);
                symbol.Typeface = Typeface.DefaultFromStyle(TypefaceStyle.Bold);
                symbol.Gravity = GravityFlags.Center;
                layout.AddView(symbol);

                name = new TextView(context);
                name.SetTextSize(ComplexUnitType.Dip, 16);
                name.Gravity = GravityFlags.Center;
                layout.AddView(name);
                
                atomicNumber = new TextView(context);
                atomicNumber.SetTextSize(ComplexUnitType.Dip, 12);
                atomicNumber.SetPaddingRelative(0, 10, 0, 0);
                atomicNumber.Gravity = GravityFlags.Center;
                layout.AddView(atomicNumber);

                atomicWeight = new TextView(context);
                atomicWeight.SetTextSize(ComplexUnitType.Dip, 12);
                atomicWeight.Gravity = GravityFlags.Center;
                layout.AddView(atomicWeight);
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
