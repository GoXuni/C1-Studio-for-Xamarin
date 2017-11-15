using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.WinRT;
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
            var platform = new SQLitePlatformWinRT();
            var connectionString = new SQLiteConnectionString(path, true);
            return new SQLiteAsyncConnection(() => new SQLiteConnectionWithLock(platform, connectionString) { TraceListener = new MyTraceListener() });
        }
        #endregion
    }

    public class MyTraceListener : ITraceListener
    {
        public void Receive(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
