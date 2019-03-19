using C1.CollectionView;
using C1.Xamarin.Forms.Grid;
using FlexGrid101.Resources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlexGrid101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilterForm : ContentPage
    {
        private TaskCompletionSource<bool> _completion;

        public FilterForm()
        {
            InitializeComponent();
            Filters = new ObservableCollection<FlexGrid101.StringFilter>();
            var operators = new List<FilterOperation>();
            operators.Add(FilterOperation.Contains);
            operators.Add(FilterOperation.StartsWith);
            operators.Add(FilterOperation.EndsWith);
            operators.Add(FilterOperation.EqualText);
            grid.AutoGeneratingColumn += (s, e) =>
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
            grid.ItemsSource = Filters;
            btnFilter.Text = AppResources.Filter;
            btnCancel.Text = AppResources.Cancel;
        }

        protected override bool OnBackButtonPressed()
        {
            if (_completion != null)
                _completion.TrySetCanceled();
            return base.OnBackButtonPressed();
        }

        public ObservableCollection<StringFilter> Filters { get; set; }

        private async void FilterClicked(object sender, EventArgs e)
        {
            grid.FinishEditing();
            await Navigation.PopModalAsync(true);
            _completion.TrySetResult(true);
        }

        private async void CancelClicked(object sender, EventArgs e)
        {
            if (_completion != null)
                _completion.TrySetCanceled();
            // close pop-up without saving anything
            await Navigation.PopModalAsync();
        }

        public async Task ShowAsync(INavigation navigation)
        {
            _completion = new TaskCompletionSource<bool>();
            await navigation.PushModalAsync(this, true);
            await _completion.Task;
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
