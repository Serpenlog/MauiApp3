public static class Constants
{
    // SQLite uses SQLitePCL.raw library that requires a call to SQLitePCL.Batteries.Init().
    // This is typically done in each platform specific project. Constants.Flags is used to decide
    // which SQLite library to use.
    public const string Flags = SQLitePCL.raw.SQLITE_OPEN_READWRITE | SQLitePCL.raw.SQLITE_OPEN_CREATE; //error, 6

    public static string DatabasePath
    {
        get
        {
            var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            return Path.Combine(basePath, "orders.db3");
        }
    }
}
