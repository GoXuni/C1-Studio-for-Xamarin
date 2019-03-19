using C1.CollectionView;
using C1.Xamarin.Forms.Grid;
using FlexGrid101.Resources;
using System.Collections;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlexGrid101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewRow : ContentPage
    {
        public NewRow()
        {
            InitializeComponent();

            Title = AppResources.NewRowTitle;

            var data = Customer.GetCustomerList(100);
            grid.ItemsSource = new CustomCollectionView<Customer>(data);
            grid.NewRowPlaceholder = AppResources.NewRowPlaceholder;
            grid.MinColumnWidth = 85;
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

    public class CustomCollectionView<T> : C1CollectionView<T>
        where T : class
    {
        public CustomCollectionView(IEnumerable source)
            : base(source)
        {
        }

        public override async Task<int> InsertAsync(int index, object item)
        {
            await Task.Delay(1000); //simulates a network operation
            return await base.InsertAsync(index, item);
        }

        public override async Task RemoveAsync(int index)
        {
            await Task.Delay(1000); //simulates a network operation
            await base.RemoveAsync(index);
        }

        public override async Task ReplaceAsync(int index, object item)
        {
            await Task.Delay(1000); //simulates a network operation
            await base.ReplaceAsync(index, item);
        }

        public override async Task MoveAsync(int fromIndex, int toIndex)
        {
            await Task.Delay(1000); //simulates a network operation
            await base.MoveAsync(fromIndex, toIndex);
        }
    }
}
