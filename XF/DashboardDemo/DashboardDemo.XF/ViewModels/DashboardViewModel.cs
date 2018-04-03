using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using DashboardModel;

namespace DashboardDemo.ViewModels
{
    public class DashboardViewModel
    {
        DataService _service;

        public DashboardViewModel()
        {
            _service = DataService.GetService();
        }

        public List<SaleItem> TopSaleProducts
        {
            get
            {
                if (_service != null)
                    return _service.GetTopSaleProductList(3);
                else
                    return null;
            }
        }

        public List<SaleItem> TopSaleCustomers
        {
            get
            {
                if (_service != null)
                    return _service.GetTopSaleCustomerList(5);
                else
                    return null;
            }
        }

        public List<SalesVsGoalModel> CategorySalesVsGoal
        {
            get
            {
                if (_service != null && _service.CategorySalesVsGoal != null)
                    return GetSalesVsGoal(_service.CategorySalesVsGoal);
                else
                    return null;
            }
        }

        public List<SalesVsGoalModel> RegionSalesVsGoal
        {
            get
            {
                if (_service != null && _service.RegionSalesVsGoal != null)
                    return GetSalesVsGoal(_service.RegionSalesVsGoal);
                else
                    return null;
            }
        }

        public List<CurrentPriorBudgetItem> BudgetItems
        {
            get
            {
                if (_service != null && _service.BudgetItemList != null)
                    return _service.BudgetItemList;
                else
                    return null;
            }
        }

        public async Task Init()
        {
            if (_service.CategorySalesVsGoal == null || _service.RegionSalesVsGoal == null || _service.BudgetItemList == null)
                await _service.InitializeDataServiceAsync();
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
        }

        private List<SalesVsGoalModel> GetSalesVsGoal(List<SaleGoalItem> list)
        {
            var salesList = new List<SalesVsGoalModel>();

            foreach (var item in list)
            {
                salesList.Add(new SalesVsGoalModel()
                {
                    Name = item.Name,
                    RealSales = item.Sales / 1000000,
                    TargetSales = item.Goal / 1000000,
                    GoodSales = item.Goal * 0.0000008,
                    BadSales = item.Goal * 0.0000005,
                    SalesColor = item.CompletePrecent < 0.8 ? Color.Red : Color.FromRgb(0, 133, 199)
                });
            }

            return salesList;
        }
    }

    public class SalesVsGoalModel
    {
        public String Name { get; set; }

        public double RealSales { get; set; }

        public double TargetSales { get; set; }

        public double GoodSales { get; set; }

        public double BadSales { get; set; }

        public Color SalesColor { get; set; }
    }
}
