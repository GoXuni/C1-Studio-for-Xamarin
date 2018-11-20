﻿using FlexGrid101.Resources;
using System;
using Xamarin.Forms;
using C1.Xamarin.Forms.Grid;

namespace FlexGrid101
{
    public partial class Editing : ContentPage
    {
        GridCellRange selectedRange;
        public Editing()
        {
            InitializeComponent();

            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = data;
            grid.SelectionChanged += grid_SelectionChanged;
            grid.CellDoubleTapped += OnCellDoubleTapped;
            grid.IsReadOnly = true;
            grid.MinColumnWidth = 85;

            toolbarItemEdit.Text = AppResources.EditRow;

            this.Title = AppResources.EditingTitle;
        }

        void grid_SelectionChanged(object sender, GridCellRangeEventArgs e)
        {
            this.selectedRange = e.CellRange;
        }

        async void OnCellDoubleTapped(object sender, GridCellRangeEventArgs e)
        {
            if(e.CellType == GridCellType.Cell)
            {
                Customer c = grid.Rows[e.CellRange.Row].DataItem as Customer;
                if (c != null)
                    await Navigation.PushModalAsync(new EditCustomerForm(c));
            }
        }

        private async void OnEditButtonClicked(object sender, EventArgs e)
        {
            if (this.selectedRange != null)
            {
                Customer c = grid.Rows[this.selectedRange.Row].DataItem as Customer;
                if(c != null)
                    await Navigation.PushModalAsync(new EditCustomerForm(c));
            }
            else
            {
                await DisplayAlert("", AppResources.SelectRowMessage, AppResources.OK);
            }
        }

    }
}
