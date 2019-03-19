using C1.CollectionView;
using C1.CollectionView.EntityFramework;
using C1.Xamarin.Forms.Grid;
using Microsoft.Data.Sqlite;
using SQLiteDataBase.Resources;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteDataBase
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
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
                var db = new PeopleContext();
                #region ** creates testing data
                //await db.Database.EnsureDeletedAsync();
                await db.Database.EnsureCreatedAsync();
                var count = db.Person.Count();
                if (count == 0)
                {
                    var total = 1000;
                    for (int i = 0; i < total; i++)
                    {
                        var person = new Person() { FirstName = GetRandomString(_firstNames), LastName = GetRandomString(_lastNames) };
                        db.Person.Add(person);
                    }
                    message.Text = $"Creating {total} records";
                    await db.SaveChangesAsync();
                    message.Text = "";
                }
                message.IsVisible = false;
                #endregion
                var cv = new EntityFrameworkCollectionView<Person>(db);
                await cv.SortAsync(p => p.ID, SortDirection.Descending);
                grid.ItemsSource = cv;
            }
            catch (SqliteException) { throw; }

            grid.NewRowPlaceholder = AppResources.AddNewRecord;
        }

        static string GetRandomString(string[] arr)
        {
            return arr[_rnd.Next(arr.Length)];
        }

        private void OnAutoGeneratingColumn(object sender, GridAutoGeneratingColumnEventArgs e)
        {
            if (e.Property.Name == "FirstName" || e.Property.Name == "LastName")
                e.Column.Width = GridLength.Star;
        }
    }
}
