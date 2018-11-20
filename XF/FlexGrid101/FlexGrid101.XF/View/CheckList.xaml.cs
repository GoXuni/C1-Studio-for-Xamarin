using FlexGrid101.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlexGrid101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckList : ContentPage
    {
        public CheckList ()
        {
            InitializeComponent ();
            this.Title = AppResources.CheckListTitle;
            grid.ItemsSource = Customer.GetCities();
        }

        private void OnAutoGeneratingColumn(object sender, C1.Xamarin.Forms.Grid.GridAutoGeneratingColumnEventArgs e)
        {
            e.Column.Width = GridLength.Star;
        }
    }
}