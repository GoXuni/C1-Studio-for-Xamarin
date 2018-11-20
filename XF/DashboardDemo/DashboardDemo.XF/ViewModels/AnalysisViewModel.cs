using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

using DashboardModel;
using C1.CollectionView;

namespace DashboardDemo.ViewModels
{
    public class AnalysisViewModel : INotifyPropertyChanged
    {
        DataService _service;

        public AnalysisViewModel()
        {
            _service = DataService.GetService();
        }

        public List<RegionProductSalesModel> RegionProductSales
        {
            get
            {
                return GetRegionProductSalesList();
            }
        }

        public List<OpportunityModel> Opportunity
        {
            get
            {
                return GetOpportunityList();
            }
        }

        public List<RegionFilterModel> Regions
        {
            get
            {
                return GetRegions();
            }
        }

        public List<ProductFilterModel> Products
        {
            get
            {
                return GetProducts();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private List<RegionProductSalesModel> GetRegionProductSalesList()
        {
            if (_service == null || _service.ProductWiseSaleCollection == null)
                return null;

            var regionSalesList = new List<RegionProductSalesModel>();
            var regions = new List<Region>(_service.RegionList);
            regions.RemoveAt(0);

            foreach (var region in regions)
            {
                IEnumerable<ProductsWiseSaleItem> items = from item in _service.ProductWiseSaleCollection
                                                          where (item as ProductsWiseSaleItem).Region == region.Name
                                                          select item as ProductsWiseSaleItem;
                double sumSales = items.Sum(x => x.Sale);
                if (sumSales > 0)
                    regionSalesList.Add(new RegionProductSalesModel() { RegionName = region.Name, Sales = sumSales });
            }

            return regionSalesList;
        }

        private List<OpportunityModel> GetOpportunityList()
        {
            if (_service == null || _service.OpportunityItemList == null)
                return null;

            var opportunityList = new List<OpportunityModel>();
            double total = 0;

            foreach (var item in _service.OpportunityItemList)
            {
                total += item.Sales;
            }

            foreach (var item in _service.OpportunityItemList)
            {
                opportunityList.Add(new OpportunityModel() { Level = item.Level, Sales = item.Sales, TotalSales = total });
            }

            return opportunityList;
        }

        private List<RegionFilterModel> GetRegions()
        {
            var regionFilter = new List<RegionFilterModel>();
            var regions = new List<Region>(_service.RegionList);
            regions.RemoveAt(0);

            foreach (var region in regions)
            {
                regionFilter.Add(new RegionFilterModel() { RegionName = region.Name, IsSelected = true });
            }

            return regionFilter;
        }

        private List<ProductFilterModel> GetProducts()
        {
            var productFilter = new List<ProductFilterModel>();
            var products = new List<Product>(_service.ProductList);
            products.RemoveAt(0);

            foreach (var product in products)
            {
                productFilter.Add(new ProductFilterModel() { ProductName = product.Name, IsSelected = true });
            }

            return productFilter;
        }

        public async Task FilterMonthDataAsync()
        {
            await FilterByDateRangeAsync(new DateTime(2017, 7, 1), new DateTime(2017, 8, 1));
        }

        public async Task Filter3MonthsDataAsync()
        {
            await FilterByDateRangeAsync(new DateTime(2017, 5, 1), new DateTime(2017, 8, 1));
        }

        public async Task Filter6MonthsDataAsync()
        {
            await FilterByDateRangeAsync(new DateTime(2017, 2, 1), new DateTime(2017, 8, 1));
        }

        public async Task FilterYearDataAsync()
        {
            await FilterByDateRangeAsync(new DateTime(2016, 8, 1), new DateTime(2017, 8, 1));
        }

        public async Task Filter2YearsDataAsync()
        {
            await FilterByDateRangeAsync(new DateTime(2016, 1, 1), new DateTime(2017, 8, 1));
        }

        private async Task FilterByDateRangeAsync(DateTime start, DateTime end)
        {
            if (_service.DateRange != null && _service.DateRange.Start == start && _service.DateRange.End == end)
                return;

            _service.DateRange = new DateRange() { Start = start, End = end };
            await _service.UpdataDataByDateRangeAsync();
            OnPropertyChanged("RegionProductSales");
            OnPropertyChanged("Opportunity");
        }

        public async Task FilterProductAndRegion(List<ProductFilterModel> productFilter, List<RegionFilterModel> regionFilter)
        {
            await _service.ProductWiseSaleCollection.RemoveFilterAsync();

            var filterSource = _service.ProductWiseSaleCollection as ISupportFiltering;
            var filterExpressions = new List<FilterExpression>();

            if (filterSource != null)
            {
                foreach (var region in regionFilter)
                {
                    if (region.IsSelected)
                    {
                        filterExpressions.Add(new FilterOperationExpression("Region", FilterOperation.EqualText, region.RegionName));
                    }
                }
                if (filterExpressions.Count < 1)
                {
                    filterExpressions.Add(new FilterOperationExpression("Region", FilterOperation.EqualText, ""));
                }
                var feRegion = FilterExpression.Combine(FilterCombination.Or, filterExpressions.ToArray());

                filterExpressions = new List<FilterExpression>();

                foreach (var product in productFilter)
                {
                    if (product.IsSelected)
                    {
                        filterExpressions.Add(new FilterOperationExpression("Product", FilterOperation.EqualText, product.ProductName));
                    }
                }
                if (filterExpressions.Count < 1)
                {
                    filterExpressions.Add(new FilterOperationExpression("Product", FilterOperation.EqualText, ""));
                }
                var feProduct = FilterExpression.Combine(FilterCombination.Or, filterExpressions.ToArray());

                await filterSource.FilterAsync(new FilterBinaryExpression(FilterCombination.And, feRegion, feProduct));
                OnPropertyChanged("RegionProductSales");
            }
        }
    }

    public class OpportunityModel
    {
        public OpportunityLevel Level { get; set; }

        public double Sales { get; set; }

        public double TotalSales { get; set; }
    }

    public class RegionProductSalesModel
    {
        public string RegionName { get; set; }

        public double Sales { get; set; }
    }

    public class RegionFilterModel
    {
        public string RegionName { get; set; }

        public bool IsSelected { get; set; }

        public RegionFilterModel Clone()
        {
            return new RegionFilterModel() { RegionName = this.RegionName, IsSelected = this.IsSelected };
        }
    }

    public class ProductFilterModel
    {
        public string ProductName { get; set; }

        public bool IsSelected { get; set; }

        public ProductFilterModel Clone()
        {
            return new ProductFilterModel() { ProductName = this.ProductName, IsSelected = this.IsSelected };
        }
    }
}
