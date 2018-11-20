using Foundation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UIKit;
using C1.CollectionView;

namespace FlexGrid101
{
    public partial class FilterController : UIViewController
    {
        public FilterController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var data = Customer.GetCustomerList(100);
            Grid.ItemsSource = data;
        }
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            Grid.RemoveFromSuperview();
            ReleaseDesignerOutlets();
        }
        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            var popupController = (segue.DestinationViewController as UINavigationController).ChildViewControllers.First() as FilterFormController;
            var currentFilters = GetCurrentFilters(Grid.CollectionView.GetFilterExpression());
            var filters = new ObservableCollection<StringFilter>();
            foreach (var column in Grid.Columns)
            {
                if (column.DataType == typeof(string))
                {
                    var stringFilter = new StringFilter();
                    stringFilter.Field = column.Binding;
                    stringFilter.FieldName = column.ActualHeader;
                    var existingFilter = currentFilters.FirstOrDefault(f => f.FilterPath == column.Binding);
                    if (existingFilter != null)
                    {
                        stringFilter.Operation = existingFilter.FilterOperation;
                        stringFilter.Value = existingFilter.Value.ToString();
                    }
                    else
                    {
                        stringFilter.Operation = FilterOperation.Contains;
                    }
                    filters.Add(stringFilter);
                }
            }
            popupController.Filters = filters;
        }

        [Action("CloseFilterForm:")]
        public async void CloseFilterForm(UIStoryboardSegue segue)
        {
            var popup = segue.SourceViewController as FilterFormController;
            if (popup.Saved)
            {
                var filters = new List<FilterExpression>();
                foreach (var filter in popup.Filters)
                {
                    if (!string.IsNullOrWhiteSpace(filter.Value))
                    {
                        filters.Add(new FilterOperationExpression(filter.Field, filter.Operation, filter.Value));
                    }
                }
                await Grid.CollectionView.FilterAsync(FilterExpression.Combine(FilterCombination.And, filters.ToArray()));
            }
        }

        private IEnumerable<FilterOperationExpression> GetCurrentFilters(FilterExpression filterExpression)
        {
            var uf = filterExpression as FilterOperationExpression;
            if (uf != null)
                yield return uf;
            var bf = filterExpression as FilterBinaryExpression;
            if (bf != null)
            {
                foreach (var lf in GetCurrentFilters(bf.LeftExpression))
                {
                    yield return lf;
                }
                foreach (var rf in GetCurrentFilters(bf.RightExpression))
                {
                    yield return rf;
                }
            }
            yield break;
        }

        async partial void UndoFilterButton_Activated(UIBarButtonItem sender)
        {
            await Grid.CollectionView.RemoveFilterAsync();
        }
    }
}