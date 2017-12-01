using SQLite;
using SQLiteDataBase.Resources;
using System;
using Xamarin.Forms;

namespace SQLiteDataBase
{
    public partial class MainPage : ContentPage
    {
        static Random _rnd = new Random();
        static string[] _firstNames = "Andy|Ben|Charlie|Dan|Ed|Fred|Gil|Herb|Jack|Karl|Larry|Mark|Noah|Oprah|Paul|Quince|Rich|Steve|Ted|Ulrich|Vic|Xavier|Zeb".Split('|');
        static string[] _lastNames = "Ambers|Bishop|Cole|Danson|Evers|Frommer|Griswold|Heath|Jammers|Krause|Lehman|Myers|Neiman|Orsted|Paulson|Quaid|Richards|Stevens|Trask|Ulam".Split('|');

        public MainPage()
        {
            InitializeComponent();

            Load();
        }

        private async void Load()
        {
            try
            {
                var connection = DependencyService.Get<ISQLite>().GetConnection();
                #region ** creates testing data
                //await connection.DropTableAsync<Person>();
                var result = await connection.CreateTableAsync<Person>();
                var count = await connection.Table<Person>().CountAsync();
                if (count == 0)
                {
                    var total = 1000;
                    for (int i = 0; i < total; i++)
                    {
                        message.Text = $"Creating record {i + 1} of {total}";
                        var person = new Person() { FirstName = GetRandomString(_firstNames), LastName = GetRandomString(_lastNames) };
                        await connection.InsertAsync(person);
                    }
                    message.Text = "";
                }
                message.IsVisible = false;
                #endregion
                grid.ItemsSource = new SQLiteCollectionView<Person>(connection);
            }
            catch (SQLiteException ex) { throw; }

            grid.NewRowPlaceholder = AppResources.AddNewRecord;
        }

        static string GetRandomString(string[] arr)
        {
            return arr[_rnd.Next(arr.Length)];
        }

    }
}
