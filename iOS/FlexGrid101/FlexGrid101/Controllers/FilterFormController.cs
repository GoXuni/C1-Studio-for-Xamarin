using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UIKit;
using C1.DataCollection;
using C1.iOS.Grid;

namespace FlexGrid101
{
    public partial class FilterFormController : UIViewController
    {
        public ObservableCollection<StringFilter> Filters { get; set; }
        public bool Saved { get; set; }

        public FilterFormController(IntPtr handle) : base(handle)
        {
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            Grid.RemoveFromSuperview();
            ReleaseDesignerOutlets();
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var operators = new List<FilterOperation>();
            operators.Add(FilterOperation.Contains);
            operators.Add(FilterOperation.StartsWith);
            operators.Add(FilterOperation.EndsWith);
            operators.Add(FilterOperation.EqualText);
            Grid.AutoGeneratingColumn += (s, e) =>
            {
                if (e.Property.Name == "Field")
                {
                    e.Cancel = true;
                }
                if (e.Property.Name == "FieldName")
                {
                    e.Column.IsReadOnly = true;
                    e.Column.Width = GridLength.Auto;
                    e.Column.Header = "Field";
                }
                if (e.Property.Name == "Operation")
                {
                    e.Column.Width = GridLength.Auto;
                    e.Column.DataMap = new GridDataMap() { ItemsSource = operators };
                }
                if (e.Property.Name == "Value")
                {
                    e.Column.Width = GridLength.Star;
                }
            };
            Grid.ItemsSource = Filters;
        }

        partial void DoneButton_Activated(UIBarButtonItem sender)
        {
            Grid.FinishEditing();
            Saved = true;
            PerformSegue("CloseFilterForm", this);
        }
    }

    public class StringFilter
    {
        public string Field { get; set; }
        public string FieldName { get; set; }
        public FilterOperation Operation { get; set; }
        public string Value { get; set; }
    }
}