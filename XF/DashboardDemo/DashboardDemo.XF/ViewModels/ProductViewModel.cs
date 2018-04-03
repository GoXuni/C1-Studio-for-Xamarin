using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using DashboardModel;

namespace DashboardDemo.ViewModels
{
    public class ProductViewModel
    {
        DataService _service;

        public ProductViewModel()
        {
            _service = DataService.GetService();
        }

        public async Task<List<ProductsGroupModel>> GetProducts()
        {
            var list = new List<ProductsGroupModel>();

            foreach (var item in _service.CategoryList)
            {
                if (item.Id > 0)
                    list.Add(new ProductsGroupModel(item.Name, item.Name, await _service.GetProductItemListAsync((CategoryType)item.Id)));
            }

            return list;
        }
    }

    public class ProductsGroupModel : List<ProductItem>
    {
        public string Title { get; set; }

        public string ShortName { get; set; }

        public ProductsGroupModel(string title, string shortName, IEnumerable<ProductItem> collection)
            : base(collection)
        {
            Title = title;
            ShortName = shortName;
        }

        public ProductsGroupModel(string title, string shortName)
        {
            Title = title;
            ShortName = shortName;
        }
    }
}
