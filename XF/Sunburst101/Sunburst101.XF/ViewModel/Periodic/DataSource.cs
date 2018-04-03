using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace Sunburst101.Periodic
{
    public class DataSource
    {
        private List<Group> _groups;

        public List<Group> Groups
        {
            get
            {
                if (_groups == null)
                    _groups = new List<Group>();
                return _groups;
            }
        }
    
        public DataSource()
        {
            var metals = new Group("Metals");
            //Add subgroups to metals
            metals.SubGroups.Add(new SubGroup("Alkali Metal") { Characteristics = "Shiny, Soft, Highly Reactive,Low Melting Point" });
            metals.SubGroups.Add(new SubGroup("Alkaline Earth Metal") { Characteristics = "Ductile,Malleable,Low Density,High Melting Point" });
            metals.SubGroups.Add(new SubGroup("Transition Metal") { Characteristics = "High Melting Point, High Density" });
            metals.SubGroups.Add(new SubGroup("Lanthanide") { Characteristics = "Soluble, Highly Reactive," });
            metals.SubGroups.Add(new SubGroup("Actinide") { Characteristics = "Radioactive,Paramagnetic" });
            metals.SubGroups.Add(new SubGroup("Others") { Characteristics = "Brittle, Poor Metals,Low Melting Point" });

            var nonmetals = new Group("Non Metals");
            //Add subgroups to non-metals
            nonmetals.SubGroups.Add(new SubGroup("Halogen") { Characteristics = "Toxic,Highly Reactive,Poor Conductors" });
            nonmetals.SubGroups.Add(new SubGroup("Noble Gas") { Characteristics = "Colorless,Odorless,Low Chemical Reactivity" });
            nonmetals.SubGroups.Add(new SubGroup("Others") { Characteristics = "Volatile, Low Elasticity, Good Insulators" });

            var others = new Group("Others");
            //Add subgroups to others
            others.SubGroups.Add(new SubGroup("Metalloids") { Characteristics = "Metallic looking solids, SemiConductors" });
            others.SubGroups.Add(new SubGroup("Transactinides") { Characteristics = "Radioactive,Synthetic Elements" });

            Groups.Add(metals);
            Groups.Add(nonmetals);
            Groups.Add(others);
            GroupElements();
        }

        void GroupElements()
        {
            var elementsCollection = Utils.DeserializeXml("Sunburst101.Resources.Periodic Table of Elements.xml");
            var metals = "Alkali Metal|Alkaline Earth Metal|Metal|Transition Metal|Lanthanide|Actinide".Split('|');
            var nonmetals = "Nonmetal|Noble Gas|Halogen".Split('|');
            Group group;
            SubGroup sub;
            for (int i = 0; i < elementsCollection.Elements.Length; i++)
            {
                var e = elementsCollection.Elements[i];
                if (metals.Contains(e.Element.Type))
                {
                    group = Groups[0];
                    if (e.Element.Type == "Metal")
                        sub = group.SubGroups.Find(s => s.SubGroupName.Equals("Others"));
                    else
                        sub = group.SubGroups.Find(s => s.SubGroupName.Equals(e.Element.Type));
                    sub.Elements.Add(e.Element);
                }
                else if (nonmetals.Contains(e.Element.Type))
                {
                    group = Groups[1];
                    if (e.Element.Type == "Nonmetal")
                        sub = group.SubGroups.Find(s => s.SubGroupName.Equals("Others"));
                    else
                        sub = group.SubGroups.Find(s => s.SubGroupName.Equals(e.Element.Type));
                    sub.Elements.Add(e.Element);
                }
                else
                {
                    group = Groups[2];
                    if (e.Element.Type == "Metalloid")
                        sub = group.SubGroups.Find(s => s.SubGroupName.Equals("Metalloids"));
                    else
                        sub = group.SubGroups.Find(s => s.SubGroupName.Equals("Transactinides"));
                    sub.Elements.Add(e.Element);
                }
            }
        }
    }

    public class Group : IChartModel
    {
        internal static StackLayout layout;

        private List<SubGroup> _subGroups;

        public string GroupName{ get; set; }
        private static Label _groupName;
        private static Label _subGroup;
        private static Label _subGroupName;
        private static ListView _listView;
        private static double _fontSizeRate;
        public List<SubGroup> SubGroups
        {
            get
            {
                if (_subGroups == null)
                    _subGroups = new List<SubGroup>();
                return _subGroups;
            }
        }

        public Group(){}

        public Group(string name)
        {
            GroupName = name;
        }

        public View GetUserView(float fontSizeRate)
        {
            if (layout == null)
            {
                layout = new StackLayout();
                _fontSizeRate = fontSizeRate;
                Label groupName = new Label() { FontAttributes = FontAttributes.Bold, FontSize = 18 * fontSizeRate, HorizontalOptions = LayoutOptions.Center };
                groupName.SetBinding(Label.TextProperty, "GroupName");
                layout.Children.Add(groupName);
                Thickness thickness = new Thickness() { Top = 5 * fontSizeRate };
                Label subGroup = new Label() { FontAttributes = FontAttributes.Bold, FontSize = 12 * fontSizeRate, Margin = thickness, HorizontalOptions = LayoutOptions.Center };
                subGroup.Text = "Sub Groups";
                layout.Children.Add(subGroup);
                groupName.BackgroundColor = Color.Transparent;
                subGroup.BackgroundColor = Color.Transparent;
                _groupName = groupName;
                _subGroup = subGroup;

                ListView listView = new ListView();
                listView.RowHeight = 16;
                Device.OnPlatform(iOS: () => { listView.RowHeight = 7; });
                listView.SeparatorColor = Color.Transparent;
                listView.BackgroundColor = Color.Transparent;
                listView.ItemTemplate = new DataTemplate(() =>
                {
                    StackLayout itemLayout = new StackLayout();
                    Label subGroupName = new Label() { FontSize = 10 * fontSizeRate, HorizontalOptions = LayoutOptions.Center , VerticalOptions = LayoutOptions.CenterAndExpand };
                    subGroupName.BackgroundColor = Color.Transparent;
                    subGroupName.SetBinding(Label.TextProperty, "SubGroupNameAndElementsCount");
                    subGroupName.SetBinding(Label.FontSizeProperty, "FontSize");
                    itemLayout.Children.Add(subGroupName);
                    _subGroupName = subGroupName;
                    return new ViewCell { View = itemLayout};
                });
                _listView = listView;

                listView.SetBinding(ListView.ItemsSourceProperty, "SubGroups");
                layout.Children.Add(listView);

            }

            layout.BindingContext = this;
            return layout;
        }

        public void SetFontSize(float fontSizeRate)
        {
            _groupName.FontSize = 18 * fontSizeRate;
            _subGroup.FontSize = 12 * fontSizeRate;
            _listView.RowHeight = (int)(16 * fontSizeRate / _fontSizeRate);
            Device.OnPlatform(iOS: () => { _listView.RowHeight = (int)(7 * fontSizeRate / _fontSizeRate); ResetAndroidAndiOSFontSize(10 * fontSizeRate); });
            Device.OnPlatform(Android: () => { ResetAndroidAndiOSFontSize(10 * fontSizeRate); });
            Device.OnPlatform(WinPhone: () => { ResetUWPFontSize(10 * fontSizeRate); });
            
        }

        private void ResetAndroidAndiOSFontSize(float fontSize)
        {
            IEnumerable<PropertyInfo> pInfos = (_listView as ItemsView<Cell>).GetType().GetRuntimeProperties();
            var templatedItems = pInfos.FirstOrDefault(info => info.Name == "TemplatedItems");
            if (templatedItems != null)
            {
                var cells = templatedItems.GetValue(_listView);
                foreach (ViewCell cell in cells as Xamarin.Forms.ITemplatedItemsList<Xamarin.Forms.Cell>)
                {
                    if (cell.BindingContext != null && cell.BindingContext is SubGroup)
                    {
                        Label label = (cell.View as StackLayout).Children.OfType<Label>().FirstOrDefault();
                        if (label != null)
                        {
                            label.FontSize = fontSize;
                        }
                    }
                }
            }
        }

        private void ResetUWPFontSize(float fontSize)
        {
            List<SubGroup> newList = new List<SubGroup>();
            foreach (var item in SubGroups)
            {
                item.FontSize = fontSize;
                newList.Add(item);
            }
            _listView.ItemsSource = newList;
        }

    }

    public class CharacteristicsDataItem
    {
        public string Name { get; set; }
        public float FontSize { get; set; }
    }
    public class SubGroup : IChartModel
    {
        internal static StackLayout layout;

        private List<Element> _elements;

        public string SubGroupName{ get; set; }
        public double FontSize { get; set; }
        public string Characteristics { get; set; }
        private static Label _subGroupName;
        private static Label _elementCount;
        private static Label _charecteristics;
        private static ListView _listView;
        private static double _fontSizeRate;
        private List<CharacteristicsDataItem> _characteristicsList;
        private string _SubGroupNameAndElementsCount;

        public List<Element> Elements
        {
            get
            {
                if (_elements == null)
                    _elements = new List<Element>();
                return _elements;
            }
        }

        public int ElementsCount
        {
            get
            {
                if (_elements != null)
                    return _elements.Count;
                return 0;
            }
        }
        public string SubGroupNameAndElementsCount
        {
            get
            {
                return SubGroupName + "(" + ElementsCount + ")";
            }
        }

        public List<CharacteristicsDataItem> CharacteristicsList
        {
            get
            {
                if (_characteristicsList != null)
                {
                    return _characteristicsList;
                }
                List<CharacteristicsDataItem> newDataItemList = new List<CharacteristicsDataItem>();
                string[] itmes = Characteristics.Split(',');
                foreach (var item in itmes)
                {
                    CharacteristicsDataItem dataItem = new CharacteristicsDataItem();
                    dataItem.Name = item;
                    dataItem.FontSize = 20;
                    newDataItemList.Add(dataItem);
                }
                _characteristicsList = newDataItemList;
                return newDataItemList;
            }
            set { _characteristicsList = value; }
        }

        public SubGroup() { }

        public SubGroup(string name)
        {
            SubGroupName = name;
        }

        public View GetUserView(float fontSizeRate)
        {
            if (layout == null)
            {
                _fontSizeRate = fontSizeRate;
                layout = new StackLayout();
                Label subGroupName = new Label() { FontAttributes = FontAttributes.Bold, FontSize = 15 * fontSizeRate, HorizontalOptions = LayoutOptions.Center };
                subGroupName.SetBinding(Label.TextProperty, "SubGroupName");
                layout.Children.Add(subGroupName);
                subGroupName.BackgroundColor = Color.Transparent;

                Thickness thickness = new Thickness() { Top = 5 * fontSizeRate, Bottom= 8 * fontSizeRate };
                Label elementCount = new Label() { FontAttributes = FontAttributes.Bold, FontSize = 12 * fontSizeRate, Margin = thickness, HorizontalOptions = LayoutOptions.Center };
                elementCount.SetBinding(Label.TextProperty, "ElementsCount", stringFormat: "No. of Elements: {0}");
                layout.Children.Add(elementCount);
                elementCount.BackgroundColor = Color.Transparent;

                Label charecteristics = new Label() { FontSize = 12 * fontSizeRate, FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.Center };
                charecteristics.Text = "Characteristics";
                layout.Children.Add(charecteristics);
                charecteristics.BackgroundColor = Color.Transparent;

                _subGroupName = subGroupName;
                _elementCount = elementCount;
                _charecteristics = charecteristics;

                ListView listView = new ListView();
                listView.RowHeight = 16;
                Device.OnPlatform(iOS: () => { listView.RowHeight = 7; });
                listView.SeparatorColor = Color.Transparent;
                listView.BackgroundColor = Color.Transparent;
                listView.ItemTemplate = new DataTemplate(() =>
                {
                    StackLayout itemLayout = new StackLayout();
                    Label charecteristicsItem = new Label() { FontSize = 10 * fontSizeRate, HorizontalOptions = LayoutOptions.Center,VerticalOptions = LayoutOptions.CenterAndExpand };
                    charecteristicsItem.SetBinding(Label.TextProperty, "Name");
                    charecteristicsItem.SetBinding(Label.FontSizeProperty, "FontSize");
                    itemLayout.Children.Add(charecteristicsItem);
                    charecteristicsItem.BackgroundColor = Color.Transparent;
                    return new ViewCell { View = itemLayout};
                });
                _listView = listView;
                listView.SetBinding(ListView.ItemsSourceProperty, "CharacteristicsList");
                layout.Children.Add(listView);
            }

            layout.BindingContext = this;
            return layout;
        }

        public void SetFontSize(float fontSizeRate)
        {
            _subGroupName.FontSize = 15 * fontSizeRate;
            _elementCount.FontSize = 12 * fontSizeRate;
            _charecteristics.FontSize = 10 * fontSizeRate;
            _listView.RowHeight = (int)(16 * fontSizeRate / _fontSizeRate);
            Device.OnPlatform(iOS: () => { _listView.RowHeight = (int)(7 * fontSizeRate / _fontSizeRate); ResetAndroidAndiOSFontSize(10 * fontSizeRate); });
            Device.OnPlatform(Android: () => { ResetAndroidAndiOSFontSize(10 * fontSizeRate); });
            Device.OnPlatform(WinPhone: () => {ResetUWPFontSize(10 * fontSizeRate); });
        }

        private void ResetUWPFontSize(float fontSize)
        {
            List<CharacteristicsDataItem> newList = new List<CharacteristicsDataItem>();
            foreach (var item in CharacteristicsList)
            {
                item.FontSize = fontSize;
                newList.Add(item);
            }
            _listView.ItemsSource = newList;
        }

        private void ResetAndroidAndiOSFontSize(float fontSize)
        {
            IEnumerable<PropertyInfo> pInfos = (_listView as ItemsView<Cell>).GetType().GetRuntimeProperties();
            var templatedItems = pInfos.FirstOrDefault(info => info.Name == "TemplatedItems");
            if (templatedItems != null)
            {
                var cells = templatedItems.GetValue(_listView);
                foreach (ViewCell cell in cells as Xamarin.Forms.ITemplatedItemsList<Xamarin.Forms.Cell>)
                {
                    if (cell.BindingContext != null)
                    {
                        Label label = (cell.View as StackLayout).Children.OfType<Label>().FirstOrDefault();
                        if (label != null)
                        {
                            label.FontSize = fontSize;
                        }
                    }
                }
            }
        }

    }
}
