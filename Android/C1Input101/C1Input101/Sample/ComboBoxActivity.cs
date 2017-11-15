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
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V4.Content;

namespace C1Input101
{
    [Activity(Label = "@string/combobox", Icon = "@drawable/icon")]
    public class ComboBoxActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            this.SetContentView(Resource.Layout.activity_combobox);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = GetString(Resource.String.combobox);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            TextView editableLabel = ((TextView)this.FindViewById(Resource.Id.textView1));
		    editableLabel.SetText(Resource.String.editable);

            C1ComboBox comboBox = (C1ComboBox)this.FindViewById(Resource.Id.editable_combobox);
            comboBox.DisplayMemberPath = "Name";
            comboBox.ItemsSource = Countries.GetDemoDataList();
			comboBox.SelectedBackgroundColor = Color.Green;
            comboBox.EditableHeaderBackgroundColor = Android.Graphics.Color.White;
            comboBox.DropDownBackgroundColor = new Android.Graphics.Color(ContextCompat.GetColor(this, Resource.Color.window_background));
            comboBox.DropDownBorderWidth = 1;
            comboBox.HeaderBorderWidth = 1;
            comboBox.HeaderBorderColor = Android.Graphics.Color.Black;

            TextView nonEditableLabel = ((TextView)this.FindViewById(Resource.Id.textView2));
            nonEditableLabel.SetText(Resource.String.noneditable);
			nonEditableLabel.TextSize = 18; 

            C1ComboBox nonEditableComboBox = (C1ComboBox)this.FindViewById(Resource.Id.noneditable_combobox);
            nonEditableComboBox.ItemsSource = Countries.GetDemoDataList();
            nonEditableComboBox.DisplayMemberPath = "Name";
			nonEditableComboBox.SelectedBackgroundColor = Color.Green;
			nonEditableComboBox.IsEditable = false;
            nonEditableComboBox.EditableHeaderBackgroundColor = Android.Graphics.Color.White;
            nonEditableComboBox.DropDownBackgroundColor = new Android.Graphics.Color(ContextCompat.GetColor(this, Resource.Color.window_background));
            nonEditableComboBox.DropDownBorderWidth = 1;
            nonEditableComboBox.HeaderBorderWidth = 1;
            nonEditableComboBox.HeaderBorderColor = Android.Graphics.Color.Black;
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == global::Android.Resource.Id.Home)
            {
                Finish();
                return true;
            }
            else
            {
                return base.OnOptionsItemSelected(item);
            }
        }
    }
}

