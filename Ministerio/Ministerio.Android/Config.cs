using Ministerio.Sqlite;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(Ministerio.Droid.Config))]

namespace Ministerio.Droid
{
    public class Config : IConfig
    {
        public string DataBasePath(string dbName)
        {
            return System.IO.Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                dbName
                );
        }
        public SQLiteConnection DbConnection(string dbName)
        {
            var path = System.IO.Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                dbName
                );
            return new SQLite.SQLiteConnection(path);
        }
    }
}