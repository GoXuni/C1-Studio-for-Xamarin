using FlexGrid101.Resources;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using C1.Xamarin.Forms.Grid;

namespace FlexGrid101
{
    public partial class CustomAppearance : ContentPage
    {
        public CustomAppearance()
        {
            InitializeComponent();
            this.Title = AppResources.CustomAppearanceTitle;

            PopulateEditGrid();
        }

        private void PopulateEditGrid()
        {
            // create the data
            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;

            // hide read-only "Country" column 
            var col = grid.Columns["Country"];
            col.IsVisible = false;

            // map countryID column so it shows country names instead of their IDs
            Dictionary<int, string> dct = new Dictionary<int, string>();
            foreach (var country in Customer.GetCountries())
            {
                dct[country.Key] = country.Value;
            }
            col = grid.Columns["CountryID"];
            col.DataMap = new GridDataMap() { ItemsSource = dct, DisplayMemberPath = "Value", SelectedValuePath = "Key" };
            col.HorizontalAlignment =  LayoutAlignment.Start;
            col.Width = new GridLength(120);

            // provide auto-complete lists for first and last name columns
            col = grid.Columns["FirstName"];
            col.DataMap = new GridDataMap() { ItemsSource = Customer.GetFirstNames() };
            col = grid.Columns["LastName"];
            col.DataMap = new GridDataMap() { ItemsSource = Customer.GetLastNames() };

            
            col = grid.Columns["Email"];
            col.InputType = Keyboard.Email;

            // make read-only columns look disabled
            var readOnlyBrush = Color.FromRgba(0xe0, 0xe0, 0xe0, 0xe0);
            foreach (var c in grid.Columns)
            {
                if (c.PropertyInfo != null && !c.PropertyInfo.CanWrite)
                {
                    c.BackgroundColor = readOnlyBrush;
                }
            }

            grid.Columns.Move(grid.Columns["Name"].Index, 1);
        }
    }
}
