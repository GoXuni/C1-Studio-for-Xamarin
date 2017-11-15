using System.Collections.Generic;
using System.Linq;
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

                Label groupName = new Label() { FontAttributes = FontAttributes.Bold, FontSize = 18 * fontSizeRate, HorizontalOptions = LayoutOptions.Center };
                groupName.SetBinding(Label.TextProperty, "GroupName");
                layout.Children.Add(groupName);
                Thickness thickness = new Thickness() { Top = 5 * fontSizeRate };
                Label subGroup = new Label() { FontAttributes = FontAttributes.Bold, FontSize = 12 * fontSizeRate, Margin = thickness, HorizontalOptions = LayoutOptions.Center };
                subGroup.Text = "Sub Groups";
                layout.Children.Add(subGroup);
                groupName.BackgroundColor = Color.Transparent;
                subGroup.BackgroundColor = Color.Transparent;

                ListView listView = new ListView();
                listView.BackgroundColor = Color.Transparent;
                listView.RowHeight = 15;
                Device.OnPlatform(iOS: () => { listView.RowHeight = 7; });
                listView.SeparatorColor = Color.Transparent;
                listView.ItemTemplate = new DataTemplate(() =>
                {
                    StackLayout itemLayout = new StackLayout();
                    Label subGroupName = new Label() { FontSize = 10 * fontSizeRate, HorizontalOptions = LayoutOptions.Center };
                    subGroupName.BackgroundColor = Color.Transparent;
                    subGroupName.SetBinding(Label.TextProperty, "SubGroupNameAndElementsCount");
                    itemLayout.Children.Add(subGroupName);
                    return new ViewCell { View = itemLayout};
                });

                listView.SetBinding(ListView.ItemsSourceProperty, "SubGroups");
                layout.Children.Add(listView);
            }

            layout.BindingContext = this;
            return layout;
        }
    }

    public class SubGroup : IChartModel
    {
        internal static StackLayout layout;

        private List<Element> _elements;

        public string SubGroupName{ get; set; }

        public string Characteristics { get; set; }

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
        public List<string> CharacteristicsList
        {
            get
            {
                if (Characteristics != null)
                    return Characteristics.Split(',').ToList<string>();
                return new List<string>();
            }
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

                ListView listView = new ListView();
                listView.RowHeight = 15;
                Device.OnPlatform(iOS: () => { listView.RowHeight = 7; });
                listView.SeparatorColor = Color.Transparent;
                listView.BackgroundColor = Color.Transparent;
                listView.ItemTemplate = new DataTemplate(() =>
                {
                    StackLayout itemLayout = new StackLayout();
                    Label charecteristicsItem = new Label() { FontSize = 10 * fontSizeRate, HorizontalOptions = LayoutOptions.Center };
                    charecteristicsItem.SetBinding(Label.TextProperty, ".");
                    itemLayout.Children.Add(charecteristicsItem);
                    charecteristicsItem.BackgroundColor = Color.Transparent;
                    return new ViewCell { View = itemLayout};
                });

                listView.SetBinding(ListView.ItemsSourceProperty, "CharacteristicsList");
                layout.Children.Add(listView);
            }

            layout.BindingContext = this;
            return layout;
        }
    }
}
