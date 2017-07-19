using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;

using C1.Android.Input;
using C1.Android.Core;
using Java.Lang;

namespace C1Input101
{
    [Activity(Label = "@string/combobox", Icon = "@drawable/icon")]
    public class ComboBoxActivity : Activity
    {
        //AutoCompleteTextView autoCompleteTextView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            LinearLayout layout = new LinearLayout(this);
            layout.Orientation = Orientation.Vertical;

		    TextView editableLabel = new TextView(this);
		    editableLabel.SetText(Resource.String.editable);
		    editableLabel.TextSize = 18;
		    layout.AddView(editableLabel);

            C1ComboBox comboBox = new C1ComboBox(this);
            comboBox.DisplayMemberPath = "Name";
            comboBox.ItemsSource = Countries.GetDemoDataList();
			comboBox.SelectedBackgroundColor = Color.Green;
            layout.AddView(comboBox);

            Space emptySpace = new Space(this);
            layout.AddView(emptySpace);

            TextView nonEditableLabel = new TextView(this);
            nonEditableLabel.SetText(Resource.String.noneditable);
			nonEditableLabel.TextSize = 18; 
            layout.AddView(nonEditableLabel);

            C1ComboBox nonEditableComboBox = new C1ComboBox(this);
            nonEditableComboBox.ItemsSource = Countries.GetDemoDataList();
            nonEditableComboBox.DisplayMemberPath = "Name";
			nonEditableComboBox.SelectedBackgroundColor = Color.Green;
			nonEditableComboBox.IsEditable = false;
            layout.AddView(nonEditableComboBox);

		    this.SetContentView(layout);
           
        }
      
    }
}

