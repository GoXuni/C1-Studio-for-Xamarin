
using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace SQLiteDataBase
{
    public class PeopleContext : DbContext
    {
        public DbSet<Person> Person { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = "SQLiteDataBase.db3";
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                case Device.Android:
                    dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), dbPath);
                    break;
            }
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }

    public class Person
    {
        public Person() { }

        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            return string.Format("[Person: ID={0}, FirstName={1}, LastName={2}]", ID, FirstName, LastName);
        }
    }
}
