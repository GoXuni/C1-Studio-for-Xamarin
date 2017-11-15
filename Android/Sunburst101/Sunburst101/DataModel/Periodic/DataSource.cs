using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using Android.Widget;

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
        internal static LinearLayout layout;
        private static TextView groupNameView;
        private static ListView listView;

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

        public ViewGroup GetUserView(Context context)
        {
            if (layout == null)
            {
                layout = new LinearLayout(context);
                layout.Orientation = Orientation.Vertical;

                groupNameView = new TextView(context);
                groupNameView.SetTextSize(ComplexUnitType.Dip, 18);
                groupNameView.Typeface = Typeface.DefaultFromStyle(TypefaceStyle.Bold);
                groupNameView.Gravity = GravityFlags.Center;
                layout.AddView(groupNameView);

                TextView subGroupNameView = new TextView(context);
                subGroupNameView.SetTextSize(ComplexUnitType.Dip, 12);
                subGroupNameView.Typeface = Typeface.DefaultFromStyle(TypefaceStyle.Bold);
                subGroupNameView.Gravity = GravityFlags.Center;
                subGroupNameView.SetPaddingRelative(0, 5, 0, 0);
                subGroupNameView.Text = "Sub Groups";
                layout.AddView(subGroupNameView);

                listView = new ListView(context);
                listView.Divider = null;
                listView.TranscriptMode = TranscriptMode.Disabled;
                layout.AddView(listView);
                
            }
            groupNameView.Text = this.GroupName;

            List<string> subGroupNameList = new List<string>();
            foreach (var subGroup in SubGroups)
            {
                subGroupNameList.Add(subGroup.SubGroupName +"("+ subGroup .ElementsCount+ ")");
                
            }
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(context, Resource.Layout.text_list, subGroupNameList);

            listView.Adapter = adapter;
            return layout;
        }
    }

    public class SubGroup : IChartModel
    {
        internal static LinearLayout layout;
        private static TextView subGroupNameView;
        private static TextView elementCountView;
        private static TextView charecteristicsView;
        private static ListView listView;

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

        public ViewGroup GetUserView(Context context)
        {
            if (layout == null)
            {
                layout = new LinearLayout(context);
                layout.Orientation = Orientation.Vertical;
                
                subGroupNameView = new TextView(context);
                subGroupNameView.SetTextSize(ComplexUnitType.Dip, 15);
                subGroupNameView.Typeface = Typeface.DefaultFromStyle(TypefaceStyle.Bold);
                subGroupNameView.Gravity = GravityFlags.Center;
                layout.AddView(subGroupNameView);

                elementCountView = new TextView(context);
                elementCountView.SetPaddingRelative(0, 5, 0, 0);
                elementCountView.SetTextSize(ComplexUnitType.Dip, 12);
                elementCountView.Typeface = Typeface.DefaultFromStyle(TypefaceStyle.Bold);
                elementCountView.Gravity = GravityFlags.Center;
                layout.AddView(elementCountView);

                charecteristicsView = new TextView(context);
                charecteristicsView.SetTextSize(ComplexUnitType.Dip, 12);
                charecteristicsView.Typeface = Typeface.DefaultFromStyle(TypefaceStyle.Bold);
                charecteristicsView.Gravity = GravityFlags.Center;
                charecteristicsView.Text = "Characteristics";
                layout.AddView(charecteristicsView);

                listView = new ListView(context);
                listView.Divider = null;
                listView.TranscriptMode = TranscriptMode.Disabled;
                layout.AddView(listView);

            }
            subGroupNameView.Text = this.SubGroupName;
            elementCountView.Text = "No. of Elements: " + this.ElementsCount;

            List<string> dataList = new List<string>();
            foreach (var characteristics in CharacteristicsList)
            {
                dataList.Add(characteristics);
            }
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(context, Resource.Layout.text_list, dataList);

            listView.Adapter = adapter;
            return layout;
        }
    }
}
