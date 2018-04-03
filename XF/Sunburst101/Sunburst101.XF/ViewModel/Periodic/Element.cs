using System.Xml.Serialization;
using Xamarin.Forms;

namespace Sunburst101.Periodic
{
    public class Element: IChartModel
    {
        internal static StackLayout layout;

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
        private static Label _symbol;
        private static Label _name;
        private static Label _attomicNumber;
        private static Label _attomicWeight;

        public View GetUserView(float fontSizeRate)
        {
            if (layout == null)
            {
                layout = new StackLayout();

                Label symbol = new Label() { FontAttributes = FontAttributes.Bold, FontSize=20 * fontSizeRate, HorizontalOptions=LayoutOptions.Center};
                symbol.SetBinding(Label.TextProperty, "Symbol");
                layout.Children.Add(symbol);
                Label name = new Label() { FontSize = 15 * fontSizeRate, HorizontalOptions = LayoutOptions.Center };
                name.SetBinding(Label.TextProperty, "ElementName");
                layout.Children.Add(name);
                Thickness thickness = new Thickness() { Top = 10 * fontSizeRate };
                Label attomicNumber = new Label() { FontSize = 12 * fontSizeRate, Margin = thickness, HorizontalOptions = LayoutOptions.Center };
                attomicNumber.SetBinding(Label.TextProperty, "AtomicNumber", stringFormat: "AtomicNumber: {0}");
                layout.Children.Add(attomicNumber);
                Label attomicWeight = new Label() { FontSize = 12 * fontSizeRate, HorizontalOptions = LayoutOptions.Center };
                attomicWeight.SetBinding(Label.TextProperty, "AtomicWeight", stringFormat: "AtomicWeight: {0}");
                layout.Children.Add(attomicWeight);
                _symbol = symbol;
                _name = name;
                _attomicNumber = attomicNumber;
                _attomicWeight = attomicWeight;
            }
            layout.BindingContext = this;
            return layout;
        }

        public void SetFontSize(float fontSizeRate)
        {
            _symbol.FontSize = 20 * fontSizeRate;
            _name.FontSize = 15 * fontSizeRate;
            _attomicNumber.FontSize = 12 * fontSizeRate;
            _attomicWeight.FontSize = 12 * fontSizeRate;
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
