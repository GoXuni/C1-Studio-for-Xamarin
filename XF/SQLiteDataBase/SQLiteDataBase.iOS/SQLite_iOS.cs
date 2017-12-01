using System;
using Xamarin.Forms;
using System.IO;
using System.Diagnostics;
using SQLite;

[assembly: Dependency(typeof(SQLiteDataBase.SQLite_iOS))]

namespace SQLiteDataBase
{
    public class SQLite_iOS : ISQLite
    {
        public SQLite_iOS()
        { }

        #region ISQLite implementation

        public SQLiteAsyncConnection GetConnection()
        {
            var fileName = "SQLiteDataBase.db3";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);
            var connectionString = new SQLiteConnectionString(path, true);
            return new SQLiteAsyncConnection(path);
        }

        #endregion
    }
}