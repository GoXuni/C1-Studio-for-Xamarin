using SQLite;
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

            var connectionString = new SQLiteConnectionString(path, false);
            return new SQLiteAsyncConnection(path);
        }

        #endregion
    }
}