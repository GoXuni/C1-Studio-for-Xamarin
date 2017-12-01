using SQLite;
using System.Diagnostics;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDataBase.SQLite_UWP))]

namespace SQLiteDataBase
{
    public class SQLite_UWP : ISQLite
    {
        public SQLite_UWP() { }

        #region ISQLite implementation
        public SQLiteAsyncConnection GetConnection()
        {
            var sqliteFilename = "SQLiteDataBase.db3";
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
            var connectionString = new SQLiteConnectionString(path, true);
            return new SQLiteAsyncConnection(path);
        }
        #endregion
    }
}
