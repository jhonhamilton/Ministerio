using Ministerio.Sqlite;
using SQLite;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(Ministerio.iOS.Config))]

namespace Ministerio.iOS
{
    public class Config : IConfig
    {
        public string DataBasePath(string dbName)
        {
            string personalFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = System.IO.Path.Combine(personalFolder, "..", "Library");
            var path = System.IO.Path.Combine(libraryFolder, dbName);
            return path;
        }

        //private string directorioDB;
        //private ISQLitePlatform platform;
        //public string DirectorioDB
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(directorioDB))
        //        {
        //            var directorio = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        //            directorioDB = System.IO.Path.Combine(directorio, "..", "Library");
        //        }
        //        return directorioDB;
        //    }
        //}

        //public ISQLitePlatform Platform
        //{
        //    get
        //    {
        //        if(platform == null)
        //        {
        //            platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
        //        }
        //        return platform;
        //    }
        //}
        public SQLiteConnection DbConnection(string dbName)
        {
            string personalFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = System.IO.Path.Combine(personalFolder, "..", "Library");
            var path = System.IO.Path.Combine(libraryFolder, dbName);
            return new SQLite.SQLiteConnection(path);
        }
    }
}