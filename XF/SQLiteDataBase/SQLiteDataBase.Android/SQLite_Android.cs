using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Platform.XamarinAndroid;
using System.Diagnostics;
using System.IO;
using Xamarin.Forms;


[assembly: Dependency(typeof(SQLiteDataBase.SQLite_Android))]

namespace SQLiteDataBase
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android()
        {
        }

        #region ISQLite implementation

        public SQLiteAsyncConnection GetConnection()
        {
            var fileName = "SQLiteDataBase.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);

            var platform = new SQLitePlatformAndroid();
            var connectionString = new SQLiteConnectionString(path, false);
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