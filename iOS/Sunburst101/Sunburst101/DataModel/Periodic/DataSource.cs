using System.Collections.Generic;
using System.Linq;
using UIKit;
using CoreGraphics;
using Foundation;
using System;

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


	public class TableDelegate : UITableViewDelegate
	{
        UITableView Tabel;
		public TableDelegate(UITableView tabel)
		{
			Tabel = tabel;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
            Tabel.SelectRow(indexPath, false,UITableViewScrollPosition.None);
		}

		public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return 10;
		}

		public override void WillDisplay(UITableView tableView, UITableViewCell cell, NSIndexPath indexPath)
		{
			cell.SeparatorInset = UIEdgeInsets.Zero;
			cell.PreservesSuperviewLayoutMargins = false;
			cell.LayoutMargins = UIEdgeInsets.Zero;
		}
	}

	public class TableSource : UITableViewSource
	{
        List<string> Source;
		string CellIdentifier = "TableCell";

		public TableSource(List<string> source)
		{
            Source = source;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
            
			return (nint)(Source.Count);
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);

			if (cell == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);
			}

			CGRect rect = cell.ContentView.Frame;
			UIView selectedBackgroundView = new UIView(cell.Bounds);
            selectedBackgroundView.BackgroundColor = UIColor.Gray;

			foreach (UIView view in cell.ContentView.Subviews)
			{
				view.RemoveFromSuperview();
			}
            cell.TextLabel.Text = Source[indexPath.Row];
            cell.TextLabel.TextAlignment = UITextAlignment.Center;
            cell.TextLabel.Font = UIFont.SystemFontOfSize(8);
            cell.BackgroundColor = UIColor.Clear;
			return cell;
		}
	}


	public class Group : IChartModel
	{
        internal static UIView layout;
        private static UILabel groupNameView;
        private static UITableView listView;

		private List<SubGroup> _subGroups;

		public string GroupName { get; set; }

		public List<SubGroup> SubGroups
		{
			get
			{
				if (_subGroups == null)
					_subGroups = new List<SubGroup>();
				return _subGroups;
			}

		}

		public Group() { }

		public Group(string name)
		{
			GroupName = name;
		}

        public UIView GetUserView(CGRect rect)
		{
			if (layout == null)
			{
                layout = new UIView(new CGRect(0, 0, rect.Width, rect.Height));
                layout.BackgroundColor = UIColor.Clear;

                groupNameView = new UILabel(new CGRect(0, 0, rect.Width, rect.Height * 3 / 16));
                groupNameView.Font = UIFont.BoldSystemFontOfSize(15);
                groupNameView.TextAlignment = UITextAlignment.Center;
				layout.Add(groupNameView);
                groupNameView.BackgroundColor = UIColor.Clear;

                UILabel subGroupNameView = new UILabel(new CGRect(0, rect.Height * 3 / 16, rect.Width, rect.Height * 3 / 16));
				subGroupNameView.Font = UIFont.BoldSystemFontOfSize(12);
				subGroupNameView.TextAlignment = UITextAlignment.Center;
				subGroupNameView.Text = "Sub Groups";
				layout.Add(subGroupNameView);
                subGroupNameView.BackgroundColor = UIColor.Clear;

                listView = new UITableView(new CGRect(0, rect.Height * 6 / 16, rect.Width, rect.Height * 8/ 16));
                listView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
				layout.Add(listView);
                listView.BackgroundColor = UIColor.Clear;

			}
			groupNameView.Text = this.GroupName;

			List<string> subGroupNameList = new List<string>();
			foreach (var subGroup in SubGroups)
			{
				subGroupNameList.Add(subGroup.SubGroupName + "(" + subGroup.ElementsCount + ")");

			}
			listView.Source = new TableSource(subGroupNameList);
            listView.Delegate = new TableDelegate(listView);
			return layout;
		}
	}

	public class SubGroup : IChartModel
	{
		internal static UIView layout;
		private static UILabel subGroupNameView;
		private static UILabel elementCountView;
		private static UILabel charecteristicsView;
        private static UITableView listView;

		private List<Element> _elements;

		public string SubGroupName { get; set; }

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

        public UIView GetUserView(CGRect rect)
		{
			if (layout == null)
			{
                layout = new UIView(new CGRect(0,0,rect.Width,rect.Height));
                layout.BackgroundColor = UIColor.Clear;

				subGroupNameView = new UILabel(new CGRect(0, 0, rect.Width, rect.Height * 3 / 16));
				subGroupNameView.Font = UIFont.BoldSystemFontOfSize(12);
				subGroupNameView.TextAlignment = UITextAlignment.Center;
				layout.Add(subGroupNameView);
                subGroupNameView.BackgroundColor = UIColor.Clear;

				elementCountView = new UILabel(new CGRect(0, rect.Height * 3 / 16, rect.Width, rect.Height * 3 / 16));
				elementCountView.Font = UIFont.BoldSystemFontOfSize(10);
				elementCountView.TextAlignment = UITextAlignment.Center;
				layout.Add(elementCountView);
                elementCountView.BackgroundColor = UIColor.Clear;

				charecteristicsView = new UILabel(new CGRect(0, rect.Height * 6 / 16, rect.Width, rect.Height * 3 / 16));
				charecteristicsView.Font = UIFont.BoldSystemFontOfSize(12);
				charecteristicsView.TextAlignment = UITextAlignment.Center;
				charecteristicsView.Text = "Characteristics";
				layout.Add(charecteristicsView);
                charecteristicsView.BackgroundColor = UIColor.Clear;

                listView = new UITableView(new CGRect(0, rect.Height * 9 / 16, rect.Width, rect.Height * 7 / 16));
                listView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
				layout.Add(listView);
                listView.BackgroundColor = UIColor.Clear;

			}
			subGroupNameView.Text = this.SubGroupName;
			elementCountView.Text = "No. of Elements: " + this.ElementsCount;

			List<string> dataList = new List<string>();
			foreach (var characteristics in CharacteristicsList)
			{
				dataList.Add(characteristics);
			}
			listView.Source = new TableSource(dataList);
			listView.Delegate = new TableDelegate(listView);
			return layout;
		}
	}
}
