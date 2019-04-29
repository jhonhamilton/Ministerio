namespace Ministerio.Sqlite
{
    public interface IConfig
    {
        //string DirectorioDB { get; }
        //ISQLitePlatform Platform { get; }
        SQLite.SQLiteConnection DbConnection(string dbName);
        string DataBasePath(string dbName);
    }
}
