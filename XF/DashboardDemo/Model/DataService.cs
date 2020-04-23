﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
#if WINDOWS_UWP
using C1.Xaml;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Windows.Foundation;
using ListCollectionView = C1.Xaml.C1DataCollection;
#elif XF
using System.Reflection;
using System.Threading.Tasks;
using C1.DataCollection;
using Xamarin.Forms;
#else
#if ASP
using Point = System.Drawing.Point;
#endif
using System.ComponentModel;
using System.Data.Entity;
using System.Windows.Data;
#endif

namespace DashboardModel
{
    public class DataService
    {
        static DataService dataService;
#if !XF
        DashboardContext dashboardContext;
#endif
        Model model;

        DateRange dateRangeFilter;
        CategoryType categoryFilter;
        CampainTaskType campainFilter;

        List<SaleGoalItem> categorySalesVsGoal;
        List<SaleGoalItem> regionSalesVsGoal;
        List<SaleItem> dateSaleList;
        List<CurrentPriorBudgetItem> budgetItemList;
        List<Opportunity> opportunityList;
#if !XF
        ListCollectionView budgetCollection;
        ListCollectionView saleCollection;
        ListCollectionView productCollection;
        ListCollectionView opportunityCollection;
        ListCollectionView regionSaleGoalCollection;

        ListCollectionView regionWiseSaleCollection;
        ListCollectionView campainTaskCollection;
        ListCollectionView productWiseSaleCollection;
        ListCollectionView customerSaleCollection;
        ListCollectionView productSaleCollection;
#else
        C1DataCollection<BudgetItem> budgetCollection;
        C1DataCollection<Sale> saleCollection;
        C1DataCollection<Product> productCollection;
        C1DataCollection<OpportunityItem> opportunityCollection;
        C1DataCollection<RegionWiseSale> regionWiseSaleCollection;
        C1DataCollection<RegionSalesGoal> regionSaleGoalCollection;
        C1DataCollection<CampainTaskItem> campainTaskCollection;
        C1DataCollection<ProductsWiseSaleItem> productWiseSaleCollection;
        C1DataCollection<SaleItem> customerSaleCollection;
        C1DataCollection<SaleItem> productSaleCollection;
#endif
        public DataService()
        {
#if !XF
            dashboardContext = new DashboardContext();
#endif
        }

        public static DataService GetService()
        {
            if (dataService == null)
                dataService = new DataService();
            return dataService;
        }

#if !XF
        public void InitializeDataService()
#else
        public async Task InitializeDataServiceAsync()
#endif
        {

#if WPF || WinForms || ASP
            VerifyDatabase();
            dashboardContext.Budget.Load();
            dashboardContext.Sales.Load();
            dashboardContext.Products.Load();
            dashboardContext.RegionWiseSales.Load();
            dashboardContext.Opportunities.Load();
            dashboardContext.RegionSales.Load();
            var budgetList = dashboardContext.Budget.ToList();
            var productList = dashboardContext.Products.ToList();
            var saleList = dashboardContext.Sales.ToList();
            var opportunityList = dashboardContext.Opportunities.ToList();
            var regionWiseSales = dashboardContext.RegionWiseSales.ToList();
            var regionSales = dashboardContext.RegionSales.ToList();

            budgetCollection = new ListCollectionView(budgetList);
            productCollection = new ListCollectionView(productList);
            saleCollection = new ListCollectionView(saleList);
            opportunityCollection = new ListCollectionView(opportunityList);
            regionWiseSaleCollection = new ListCollectionView(regionWiseSales);
            regionSaleGoalCollection = new ListCollectionView(regionSales);
#elif WINDOWS_UWP || XF
#if WINDOWS_UWP
            Assembly assembly = Assembly.Load(new AssemblyName("DashboardUWP"));
            var stream = assembly.GetManifestResourceStream("DashboardUWP.InitialData.xml");
            model = Model.GetPopulated(stream);
            budgetCollection = new ListCollectionView(model.Budget.ToList());
            productCollection = new ListCollectionView(model.Products.ToList());
            saleCollection = new ListCollectionView(model.Sales.ToList());
            opportunityCollection = new ListCollectionView(model.Opportunities.ToList());
            regionWiseSaleCollection = new ListCollectionView(model.RegionWiseSales.ToList());
            regionSaleGoalCollection = new ListCollectionView(model.RegionSales.ToList());
            regionWiseSaleCollection.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Ascending));
            saleCollection.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Ascending));
#else
            Assembly assembly = Assembly.Load(new AssemblyName("DashboardDemo.XF"));
            var stream = assembly.GetManifestResourceStream("DashboardDemo.InitialData.xml");
            model = Model.GetPopulated(stream);
            budgetCollection = new C1DataCollection<BudgetItem>(model.Budget.ToList());
            productCollection = new C1DataCollection<Product>(model.Products.ToList());
            saleCollection = new C1DataCollection<Sale>(model.Sales.ToList());
            opportunityCollection = new C1DataCollection<OpportunityItem>(model.Opportunities.ToList());
            regionWiseSaleCollection = new C1DataCollection<RegionWiseSale>(model.RegionWiseSales.ToList());
            regionSaleGoalCollection = new C1DataCollection<RegionSalesGoal>(model.RegionSales.ToList());
            await regionWiseSaleCollection.SortAsync("Date");
            await saleCollection.SortAsync("Date");
#endif
#endif

            var dateSaleMap = new Dictionary<DateTime, SaleItem>();
            var productsWiseSaleItems = new List<ProductsWiseSaleItem>();

            int i = 0;
            foreach (Sale sale in saleCollection)
            {
                ProductsWiseSaleItem productsWiseSale = new ProductsWiseSaleItem();
                productsWiseSale.Date = sale.Date;
                productsWiseSale.Quantity = sale.Quantity;
                productsWiseSale.Sale = sale.Summ;
                productsWiseSale.ID = sale.ProductId;
                productsWiseSale.Category = sale.Product.Category.Name;
                productsWiseSale.Product = sale.Product.Name;
                productsWiseSale.Region = sale.Customer.Region.Name;
                productsWiseSaleItems.Add(productsWiseSale);

                if (dateSaleMap.ContainsKey(sale.Date))
                    dateSaleMap[sale.Date].Sales += sale.Summ;
                else
                    dateSaleMap.Add(sale.Date, new SaleItem { Sales = sale.Summ, Date = sale.Date, Id = i++ });

            }
            dateSaleList = dateSaleMap.Values.ToList();
#if !XF
            productWiseSaleCollection = new ListCollectionView(productsWiseSaleItems);
#else
            productWiseSaleCollection = new C1DataCollection<ProductsWiseSaleItem>(productsWiseSaleItems);
#endif 
            var budgetSaleProfitMap = new Dictionary<int, CurrentPriorBudgetItem>();

            foreach (BudgetItem budget in budgetCollection)
            {
                if (budget.Expences > 0)
                {
                    int month = budget.Date.Month;
                    int year = budget.Date.Year;
                    if (budgetSaleProfitMap.ContainsKey(month))
                    {
                        if (year == 2017)
                        {
                            budgetSaleProfitMap[month].Sales += budget.Sales;
                            budgetSaleProfitMap[month].Profit += budget.Profit;
                        }
                        else
                        {
                            budgetSaleProfitMap[month].ProirSales += budget.Sales;
                            budgetSaleProfitMap[month].ProirProfit += budget.Profit;
                        }
                    }
                    else
                    {
                        if (year == 2017)
                            budgetSaleProfitMap.Add(month, new CurrentPriorBudgetItem { Date = budget.Date, Sales = budget.Sales, Profit = budget.Profit });
                        else
                            budgetSaleProfitMap.Add(month, new CurrentPriorBudgetItem { Date = budget.Date, ProirSales = budget.Sales, ProirProfit = budget.Profit });
                    }
                }
            }

            budgetItemList = budgetSaleProfitMap.Values.ToList();
#if XF
            await UpdataDataByDateRangeAsync();
#endif
        }

#if !XF
        void VerifyDatabase()
        {
#if WPF || WinForms || ASP
            string initialPath = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "InitialData.xml");
            bool isExists = dashboardContext.Database.Exists();
            bool isCompatible = isExists && dashboardContext.Database.CompatibleWithModel(false);
            if (!isCompatible)
            {
                if (isExists)
                {
                    dashboardContext.Database.Delete();
                    dashboardContext = new DashboardContext();
                }
                dashboardContext.Database.Create();
                model = Model.GetPopulated(initialPath);
#elif WINDOWS_UWP
            dashboardContext.Database.Migrate();
            bool isCreate = dashboardContext.Database.EnsureCreated();
            if (!isCreate)
            {
                Assembly assembly = Assembly.Load(new AssemblyName("DashboardUWP"));
                var stream = assembly.GetManifestResourceStream("DashboardUWP.InitialData.xml");
                model = Model.GetPopulated(stream);
#endif
                dashboardContext.Seed(model);
            }
        }
#endif


        public DateRange DateRange
        {
            get { return dateRangeFilter; }
            set
            {
                dateRangeFilter = value;
#if !XF
                UpdataDataByDateRange();
#else
                //UpdataDataByDateRangeAsync();
#endif
            }
        }

#if !XF
        public CampainTaskType CampainTaskType
        {
            get { return campainFilter; }
            set
            {
                if (campainFilter != value)
                {
                    campainFilter = value;
                    campainTaskCollection.Filter = new Predicate<object>(FilterByCampainTaskType);
                }
            }
        }
#else

        public async Task UpdataCampainTaskTypeAsync(CampainTaskType type)
        {
            if(campainFilter != type)
            {
                campainFilter = type;
                await campainTaskCollection.FilterAsync(FilterByCampainTaskType);
            }
        }
#endif

#if !XF
        public ListCollectionView CampainTaskCollction { get { return campainTaskCollection; } }
        public ListCollectionView ProductWiseSaleCollection { get { return productWiseSaleCollection; } }
#else
        public C1DataCollection<CampainTaskItem> CampaignTaskCollction { get { return campainTaskCollection; } }
        public C1DataCollection<ProductsWiseSaleItem> ProductWiseSaleCollection { get { return productWiseSaleCollection; } }
        public List<Region> RegionList { get { return model.Regions.ToList(); } }
        public List<Product> ProductList { get { return model.Products.ToList(); } }
#endif
        public List<CurrentPriorBudgetItem> BudgetItemList { get { return budgetItemList; } }
        public List<SaleItem> DateSaleList { get { return dateSaleList; } }
        public List<Opportunity> OpportunityItemList { get { return opportunityList; } }
        public List<Category> CategoryList { get { return model.Categories.ToList(); } }


        public List<RegionSaleItem> GetRegionWiseSales()
        {
            var regionSaleMap = new Dictionary<int, RegionSaleItem>();
            foreach (RegionWiseSale regionWiseSale in regionWiseSaleCollection)
            {
                if (regionSaleMap.ContainsKey(regionWiseSale.RegionId))
                {
                    regionSaleMap[regionWiseSale.RegionId].Sales += regionWiseSale.Sales;
                    regionSaleMap[regionWiseSale.RegionId].Profit += regionWiseSale.Profit;
                }
                else
                {
#if ASP
                    regionSaleMap.Add(regionWiseSale.RegionId, new RegionSaleItem { Id = regionWiseSale.RegionId, Locat = new Point((int)regionWiseSale.X, (int)regionWiseSale.Y), Sales = regionWiseSale.Sales, Profit = regionWiseSale.Profit, Name = regionWiseSale.Region });
#else
                    regionSaleMap.Add(regionWiseSale.RegionId, new RegionSaleItem { Id = regionWiseSale.RegionId, Locat = new Point(regionWiseSale.X, regionWiseSale.Y), Sales = regionWiseSale.Sales, Profit = regionWiseSale.Profit, Name = regionWiseSale.Region });
#endif
                }
            }
            return regionSaleMap.Values.ToList();
        }
#if !XF
        public List<ProductItem> GetProductItemList(CategoryType filter)
#else
        public async Task<List<ProductItem>> GetProductItemListAsync(CategoryType filter)
#endif
        {
            categoryFilter = filter;
#if !XF
#if WINDOWS_UWP
            productCollection.Filter = null;
#endif
            productCollection.Filter = new Predicate<object>(FilterByCategoryType);
#else
            await productCollection.FilterAsync(FilterByCategoryType);
#endif
            List<ProductItem> list = new List<ProductItem>();
            foreach (Product product in productCollection)
            {
                ProductItem item = new ProductItem(product);
                list.Add(item);
            }
            return list;
        }

        public List<SaleItem> GetTopSaleProductList(int top)
        {
            if (productSaleCollection == null)
                return null;

            var item = new List<SaleItem>();
            foreach (SaleItem productSale in productSaleCollection)
            {
                item.Add(productSale);
                if (item.Count == top)
                    break;
            }
            return item;
        }
        public List<SaleItem> GetTopSaleCustomerList(int top)
        {
            if (customerSaleCollection == null)
                return null;

            var item = new List<SaleItem>();
            foreach (SaleItem customerSale in customerSaleCollection)
            {
                item.Add(customerSale);
                if (item.Count == top)
                    break;
            }
            return item;
        }

        public List<SaleGoalItem> CategorySalesVsGoal { get { return categorySalesVsGoal; } }
        public List<SaleGoalItem> RegionSalesVsGoal { get { return regionSalesVsGoal; } }
#if !XF
        void UpdataDataByDateRange()
#else
        public async Task UpdataDataByDateRangeAsync()
#endif
        {
#if !XF
            saleCollection.Filter = new Predicate<object>(FilterByDateRange);
            saleCollection.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Ascending));
            budgetCollection.Filter = new Predicate<object>(FilterByDateRange);
            opportunityCollection.Filter = new Predicate<object>(FilterByDateRange);
            regionWiseSaleCollection.Filter = new Predicate<object>(FilterByDateRange);
            regionSaleGoalCollection.Filter = new Predicate<object>(FilterByDateRange);
#else
            await saleCollection.FilterAsync(FilterByDateRange);
            await saleCollection.SortAsync("Date");
            await budgetCollection.FilterAsync(FilterByDateRange);
            await opportunityCollection.FilterAsync(FilterByDateRange);
            await regionWiseSaleCollection.FilterAsync(FilterByDateRange);
            await regionSaleGoalCollection.FilterAsync(FilterByDateRange);
#endif
            opportunityList = new List<Opportunity>();
            foreach (OpportunityLevel value in Enum.GetValues(typeof(OpportunityLevel)))
                opportunityList.Add(new Opportunity { Level = value, Sales = 0 });


            var campainTaskItems = new List<CampainTaskItem>();
            var productSaleMap = new Dictionary<int, SaleItem>();
            var customerSaleMap = new Dictionary<int, SaleItem>();
            var productsWiseSaleItems = new List<ProductsWiseSaleItem>();

            foreach (Sale sale in saleCollection)
            {
                var profit = DataService.GetService().FindProfitFormCurrentSale(sale);
                if (sale.Campaign.Name != "None")
                    campainTaskItems.Add(new CampainTaskItem(sale));
                if (customerSaleMap.ContainsKey(sale.CustomerId))
                {
                    customerSaleMap[sale.CustomerId].Sales += sale.Summ;
                    customerSaleMap[sale.CustomerId].Profit += profit;
                }
                else
                    customerSaleMap.Add(sale.CustomerId, new SaleItem { Id = sale.CustomerId, Sales = sale.Summ, Profit = profit, Name = sale.Customer.ToString(), Date = sale.Date });
                if (productSaleMap.ContainsKey(sale.ProductId))
                {
                    productSaleMap[sale.ProductId].Sales += sale.Summ;
                    productSaleMap[sale.ProductId].Profit += profit;
                }
                else
                    productSaleMap.Add(sale.ProductId, new SaleItem { Id = sale.ProductId, Sales = sale.Summ, Profit = profit, Name = sale.Product.ToString(), Date = sale.Date });

                ProductsWiseSaleItem productsWiseSale = new ProductsWiseSaleItem();
                productsWiseSale.Date = sale.Date;
                productsWiseSale.Quantity = sale.Quantity;
                productsWiseSale.Sale = sale.Summ;
                productsWiseSale.ID = sale.ProductId;
                productsWiseSale.Category = sale.Product.Category.ToString();
                productsWiseSale.Product = sale.Product.Name;
                productsWiseSale.Region = sale.Customer.Region.ToString();
                productsWiseSaleItems.Add(productsWiseSale);
            }

#if XF
            productWiseSaleCollection = new C1DataCollection<ProductsWiseSaleItem>(productsWiseSaleItems);
            var budgetSaleProfitMap = new Dictionary<int, CurrentPriorBudgetItem>();
#endif 

            var regionSaleMap = new Dictionary<int, SaleGoalItem>();
            var categorySaleMap = new Dictionary<int, SaleGoalItem>();

            foreach (BudgetItem budget in budgetCollection)
            {
                if (categorySaleMap.ContainsKey(budget.CategoryId))
                {
                    categorySaleMap[budget.CategoryId].Sales += budget.Sales;
                    categorySaleMap[budget.CategoryId].Profit += budget.Profit;
                    categorySaleMap[budget.CategoryId].Goal += budget.Goal;
                }
                else
                {
                    SaleGoalItem item = new SaleGoalItem();
                    item.Name = budget.Category.ToString();
                    item.Goal = budget.Goal;
                    item.Sales = budget.Sales;
                    item.Profit = budget.Profit;
                    categorySaleMap.Add(budget.CategoryId, item);
                }

                if (budget.Expences > 0)
                {
                    int month = budget.Date.Month;
                    int year = budget.Date.Year;
                    if (budgetSaleProfitMap.ContainsKey(month))
                    {
                        if (year == 2017)
                        {
                            budgetSaleProfitMap[month].Sales += budget.Sales;
                            budgetSaleProfitMap[month].Profit += budget.Profit;
                        }
                        else
                        {
                            budgetSaleProfitMap[month].ProirSales += budget.Sales;
                            budgetSaleProfitMap[month].ProirProfit += budget.Profit;
                        }
                    }
                    else
                    {
                        if (year == 2017)
                            budgetSaleProfitMap.Add(month, new CurrentPriorBudgetItem { Date = budget.Date, Sales = budget.Sales, Profit = budget.Profit });
                        else
                            budgetSaleProfitMap.Add(month, new CurrentPriorBudgetItem { Date = budget.Date, ProirSales = budget.Sales, ProirProfit = budget.Profit });
                    }
                }
            }

            budgetItemList = budgetSaleProfitMap.Values.ToList();

            foreach (RegionSalesGoal region in regionSaleGoalCollection)
            {
                if (regionSaleMap.ContainsKey(region.RegionId))
                {
                    regionSaleMap[region.RegionId].Sales += region.Sales;
                    regionSaleMap[region.RegionId].Profit += region.Profit;
                    regionSaleMap[region.RegionId].Goal += region.Goal;
                }
                else
                {
                    SaleGoalItem item = new SaleGoalItem();
                    item.Name = region.Region.ToString();
                    item.Goal = region.Goal;
                    item.Sales = region.Sales;
                    item.Profit = region.Profit;
                    regionSaleMap.Add(region.RegionId, item);
                }
            }
#if !XF
            campainTaskCollection = new ListCollectionView(campainTaskItems);
            campainTaskCollection.Filter = new Predicate<object>(FilterByCampainTaskType);
            productSaleCollection = new ListCollectionView(productSaleMap.Values.ToList());
            productSaleCollection.SortDescriptions.Add(new SortDescription("Sales", ListSortDirection.Descending));
            customerSaleCollection = new ListCollectionView(customerSaleMap.Values.ToList());
            customerSaleCollection.SortDescriptions.Add(new SortDescription("Sales", ListSortDirection.Descending));
#else
            campainTaskCollection = new C1DataCollection<CampainTaskItem>(campainTaskItems);
            await campainTaskCollection.FilterAsync(FilterByCampainTaskType);
            productSaleCollection = new C1DataCollection<SaleItem>(productSaleMap.Values.ToList());
            await productSaleCollection.SortAsync("Sales", SortDirection.Descending);
            customerSaleCollection = new C1DataCollection<SaleItem>(customerSaleMap.Values.ToList());
            await customerSaleCollection.SortAsync("Sales", SortDirection.Descending);
#endif
            regionSalesVsGoal = regionSaleMap.Values.ToList();
            categorySalesVsGoal = categorySaleMap.Values.ToList();

            foreach (OpportunityItem opportunity in opportunityCollection)
            {
                OpportunityItemList[opportunity.LevelId].Sales += opportunity.Sales;
            }
        }

        bool FilterByCategoryType(object product)
        {
            Product data = product as Product;
            if (data.Name == "None")
                return false;
            else
                return categoryFilter == CategoryType.All ? true : (product as Product).CategoryId == (int)categoryFilter;
        }
        bool FilterByDateRange(object item)
        {
            if (dateRangeFilter == null)
                return true;
            DateTime date = DateTime.MinValue;
            if (item is Sale)
                date = (item as Sale).Date;
            else if (item is BudgetItem)
                date = (item as BudgetItem).Date;
            else if (item is RegionWiseSale)
                date = (item as RegionWiseSale).Date;
            else if (item is RegionSalesGoal)
                date = (item as RegionSalesGoal).Date;
            else
                date = (item as OpportunityItem).Date;
            return date >= dateRangeFilter.Start && date <= dateRangeFilter.End;
        }
        bool FilterByCampainTaskType(object campainTask)
        {
            var current = campainTask as CampainTaskItem;
            if (current == null)
                return false;
            switch (campainFilter)
            {
                case CampainTaskType.Completed:
                    return current.Complete == 1.0;
                case CampainTaskType.InProgress:
                    return (current.Complete != 1.0 && current.Complete > 0);
                case CampainTaskType.Deferred:
                    return current.Deferred;
                case CampainTaskType.Urgent:
                    return current.Urgent;
            }
            return true;
        }

        double FindProfitFormCurrentSale(Sale sale)
        {
            foreach (BudgetItem budget in budgetCollection)
            {
                if (budget.Date.Year == sale.Date.Year && budget.Date.Month == sale.Date.Month && budget.CategoryId == sale.Product.CategoryId)
                {
                    double precent = sale.Summ / budget.Sales;
                    return budget.Profit * precent;
                }
            }
            return 0;
        }
    }
}
