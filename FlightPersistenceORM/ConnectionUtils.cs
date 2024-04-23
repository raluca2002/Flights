
using System.Data.SQLite;

public static class ConnectionUtils
{
    public static SQLiteConnection CreateConnection()
    {

        SQLiteConnection sqlite_conn;
        // Create a new database connection:
        /*sqlite_conn = new SQLiteConnection(ConfigurationManager.AppSettings["connectionString"]);*/
        sqlite_conn = new SQLiteConnection("Data Source=C:\\Users\\40771\\RiderProjects\\MPP_CSHarp_Interfata\\zboruri.db");
        // Open the connection:
        try
        {
            sqlite_conn.Open();
        }
        catch (Exception ex)
        {

        }
        return sqlite_conn;
    }
}