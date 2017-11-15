using System;
using Xamarin.Forms;
using System.IO;
using SQLite.Net.Async;
using SQLite.Net.Platform.XamarinIOS;
using SQLite.Net;
using System.Diagnostics;

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

            var platform = new SQLitePlatformIOS();
            var connectionString = new SQLiteConnectionString(path, true);
            var connection = new SQLiteAsyncConnection(() => new SQLiteConnectionWithLock(platform, connectionString) { TraceListener = new MyTraceListener() });

            return connection;
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