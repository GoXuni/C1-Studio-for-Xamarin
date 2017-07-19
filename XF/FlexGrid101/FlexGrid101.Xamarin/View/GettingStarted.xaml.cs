using FlexGrid101.Resources;
using System;
using Xamarin.Forms;
using C1.CollectionView;
using C1.Xamarin.Forms.Grid;

namespace FlexGrid101
{
    public partial class GettingStarted : ContentPage
    {
        public GettingStarted()
        {
            InitializeComponent();
            this.Title = AppResources.GettingStartedTitle;
            grid.ItemsSource = Customer.GetCustomerList(100);
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
    }
}
