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
            //return System.IO.Path.Combine(
            //    PCLStorage.FileSystem.Current.LocalStorage.Path,
            //    dbName
            //    );
        }
        public SQLiteConnection DbConnection(string dbName)
        {
            var path = System.IO.Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                dbName
                );
            return new SQLite.SQLiteConnection(path);
        }
        //private string directorioDB;
        //private ISQLitePlatform platform;
        //public string DirectorioDB
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(directorioDB))
        //        {
        //            directorioDB = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);                    
        //        }
        //        return directorioDB;
        //    }
        //}

        //public ISQLitePlatform Platform
        //{
        //    get
        //    {
        //        if (platform == null)
        //        {
        //            platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
        //        }
        //        return platform;
        //    }
        //}
    }
}