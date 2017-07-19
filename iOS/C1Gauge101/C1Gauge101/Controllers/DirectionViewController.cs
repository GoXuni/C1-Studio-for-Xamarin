using Foundation;
using System;
using System.Linq;
using System.Collections.Generic;
using UIKit;
using C1.iOS.Gauge;
using C1.iOS.Core;
using CoreGraphics;

namespace C1Gauge101
{
    public partial class DirectionViewController : UIViewController
    {
        private const string DirectionTitleKey = "Direction";

        private IList<string> directionItems = new List<string>() {
            LinearGaugeDirection.Right.ToString(),
            LinearGaugeDirection.Left.ToString(),
            LinearGaugeDirection.Up.ToString(),
            LinearGaugeDirection.Down.ToString()
        };

        public IList<string> DirectionItems
        {
            get
            {
                return directionItems;
            }
        }

        public DirectionViewController(IntPtr handle) : base(handle)
        {
        }

        public override void UpdateViewConstraints()
        {
            if (StackView.Axis == UILayoutConstraintAxis.Horizontal)
            {
                StackViewHeightContraint.Constant = StackView.Superview.Frame.Size.Height;
            }
            else
            {
                StackViewHeightContraint.Constant = 208;
            }
            base.UpdateViewConstraints();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            NavigationItem.Title = DirectionTitleKey.Localize();

            var localizedItems = new List<string>();
            DirectionItems.ToList().ForEach(x => localizedItems.Add(x.Localize()));

            Entry.ToPickerWithValues(localizedItems, 0, (selectedIndex) =>
            {
                var direction = (LinearGaugeDirection)Enum.Parse(typeof(LinearGaugeDirection), DirectionItems[selectedIndex]);
                LinearGauge.Direction = BulletGraph.Direction = direction;
                if (direction == LinearGaugeDirection.Left || direction == LinearGaugeDirection.Right)
                {
                    StackView.Axis = UILayoutConstraintAxis.Vertical;
                    View.SetNeedsUpdateConstraints();
                }
                else
                {
                    StackView.Axis = UILayoutConstraintAxis.Horizontal;
                    View.SetNeedsUpdateConstraints();
                }
            });
        }
    }

    public static class UITextFieldEx
    {
        public static void ToPickerWithValues(this UITextField textField, IList<string> values, int index, Action<int> action)
        {
            var toolBar = new UIToolbar(new CGRect(0, 0, 320, 44));
            var doneButton = new UIBarButtonItem(UIBarButtonSystemItem.Done);
            var flexibleSpace = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace);
            toolBar.SetItems(new UIBarButtonItem[] { flexibleSpace, doneButton }, true);

            var model = new UIPickerViewStringArrayModel();
            var picker = new UIPickerView();
            picker.Model = model;
            foreach (var displayValue in values)
            {
                model.Items.Add(displayValue.ToString());
            }
            picker.Select(index, 0, true);
            textField.InputView = picker;
            textField.InputAccessoryView = toolBar;
            textField.Text = values[index].ToString();

            doneButton.Clicked += (s, e) =>
            {
                var selectedIndex = (int)picker.SelectedRowInComponent(0);
                textField.Text = values[selectedIndex].ToString();
                textField.EndEditing(true);
                action?.Invoke(selectedIndex);
            };
        }
    }
    internal class UIPickerViewStringArrayModel : UIPickerViewModel
    {
        public UIPickerViewStringArrayModel()
        {
            Items = new List<string>();
        }

        public List<string> Items { get; private set; }
        public event EventHandler<SelectedItemEventArgs> SelectedItem;
        public override nint GetComponentCount(UIPickerView picker)
        {
            return 1;
        }

        public override nint GetRowsInComponent(UIPickerView picker, nint component)
        {
            return Items.Count;
        }

        public override string GetTitle(UIPickerView picker, nint row, nint component)
        {
            return Items[(int)row];
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            if (SelectedItem != null)
                SelectedItem(this, new SelectedItemEventArgs((int)row));
        }

        internal class SelectedItemEventArgs : EventArgs
        {

            public SelectedItemEventArgs(int row)
            {
                Index = row;
            }
            public int Index { get; private set; }
        }
    }

}