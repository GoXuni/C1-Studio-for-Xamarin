using C1.Xamarin.Forms.Grid;
using FlexGrid101.Resources;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FlexGrid101
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LiveUpdates : ContentPage
    {
        private const int ANIMATION_LENGTH = 800;
        private Random _rand = new Random();
        private ObservableCollection<Customer> _customers;
        private Boolean _toggle = true;

        public LiveUpdates()
        {
            InitializeComponent();

            Title = AppResources.LiveUpdatesTitle;
            ColorLabel.Text = AppResources.ColorUpdates;
            grid.AutoGeneratingColumn += OnAutoGeneratingColumn;
            grid.UpdateAnimation.Duration = TimeSpan.FromMilliseconds(ANIMATION_LENGTH);
            _customers = Customer.GetCustomerList(10);
            grid.ItemsSource = _customers;
            grid.IsReadOnly = true;
            grid.AllowSorting = false;
            SimulateChanges();
        }

        private void OnAutoGeneratingColumn(object sender, GridAutoGeneratingColumnEventArgs e)
        {
            var columns = new string[] { "FirstName", "LastName", "Country", "City" };
            if (!columns.Contains(e.Property.Name))
                e.Cancel = true;
            e.Column.Width = new GridLength(1, GridUnitType.Star);
            e.Column.MinWidth = double.NaN;
        }

        private async void SimulateChanges()
        {
            await Task.Delay(TimeSpan.FromMilliseconds(ANIMATION_LENGTH + 200));
            GenerateRandomChangeAsync();
            SimulateChanges();
        }

        private async Task GenerateRandomChangeAsync()
        {
            int random = _rand.Next(_customers.Count);
            switch (_rand.Next(4))
            {

                case 0:
                    _customers.Insert((random), new Customer(_rand.Next()));
                    if(_toggle) await grid.ColorTo(Color.Orange, Color.White, c => grid.Rows[random].BackgroundColor = c, ANIMATION_LENGTH);
                    break;
                case 1:
                    if (_customers.Count > 0)
                    {
                        if(_toggle) grid.Rows[random].BackgroundColor = Color.Violet;
                        _customers.RemoveAt(random);
                    }
                    break;
                case 2:
                    int moveto = _rand.Next(_customers.Count);
                    if (_customers.Count > 0)
                    {
                        _customers.Move(random, moveto);
                        if (random > moveto)
                        {
                            if(_toggle) await grid.ColorTo(Color.LightGreen, Color.White, c => grid.Rows[moveto].BackgroundColor = c, ANIMATION_LENGTH);
                        }
                        else if (random < moveto)
                        {
                            if(_toggle) await grid.ColorTo(Color.IndianRed, Color.White, c => grid.Rows[moveto].BackgroundColor = c, ANIMATION_LENGTH);
                        }
                    }
                    break;
                case 3:
                    if (_customers.Count > 0)
                    {
                        if (_toggle) grid.ColorTo(Color.LightBlue, Color.White, c => grid.Rows[random].BackgroundColor = c, ANIMATION_LENGTH);
                        _customers[random] = new Customer(_rand.Next());
                    }
                    break;
            }
        }

        private void Switch_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            _toggle = ((Switch)sender).IsToggled;
        }
    }
}
