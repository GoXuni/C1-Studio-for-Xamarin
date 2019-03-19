using C1.Xamarin.Forms.Grid;
using FlexGrid101.Resources;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlexGrid101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Export : ContentPage
    {
        private string FILENAME = "ExportedGrid";
        public Export ()
        {
            InitializeComponent ();
            this.Title = AppResources.ExportTitle;
            btnSave.Text = AppResources.Save;
            grid.ItemsSource = Customer.GetCustomerList(100);
            grid.MinColumnWidth = 85;
            grid.AllowDragging = GridAllowDragging.Both;
            grid.AllowResizing = GridAllowResizing.Both;
        }
        private void OnAutoGeneratingColumn(object sender, GridAutoGeneratingColumnEventArgs e)
        {
            if (e.Property.Name == "Country" || e.Property.Name == "Name" || e.Property.Name == "OrderAverage")
            {
                //Avoids generating these columns
                e.Cancel = true;
            }
            else if (e.Property.Name == "Id")
            {
                e.Column.IsReadOnly = true;
            }
            else if (e.Property.Name == "CountryId")
            {
                //Sets the DataMap to the country column so a picker is used to select the country.
                e.Column.Header = "Country";
                e.Column.HorizontalAlignment = LayoutAlignment.Start;
                e.Column.DataMap = new GridDataMap() { ItemsSource = Customer.GetCountries(), DisplayMemberPath = "Value", SelectedValuePath = "Key" };
            }
            else if (e.Property.Name == "OrderTotal" || e.Property.Name == "OrderAverage")
            {
                //Sets currency format the these columns
                e.Column.Format = "C";
            }
            else if (e.Property.Name == "LastOrderDate")
            {
                //Replaces the column so that the editor is a date-picker instead of an entry.
                e.Column = new GridDateTimeColumn(e.Property);
            }
            else if (e.Property.Name == "Address")
            {
                e.Column.WordWrap = true;
            }
        }
        async void OnSave(object sender, EventArgs e)
        {
            var type = await DisplayActionSheet("Save As", "Cancel", null, "CSV", "Text", "HTML");

            string PathAndName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), FILENAME) + "." + type;
            switch (type)
            {
                case "CSV":
                    grid.Save(PathAndName, GridFileFormat.Csv, System.Text.Encoding.UTF8, GridSaveOptions.SaveColumnHeaders);
                    break;
                case "Text":
                    grid.Save(PathAndName, GridFileFormat.Text, System.Text.Encoding.UTF8, GridSaveOptions.SaveColumnHeaders);
                    break;
                case "HTML":
                    grid.Save(PathAndName, GridFileFormat.Html, System.Text.Encoding.UTF8, GridSaveOptions.SaveColumnHeaders);
                    break;
            }
            if(type != "Cancel")
            {
                await DisplayAlert("Saved", "File has been saved to: " + PathAndName, "OK");
            }
        }
    }
}