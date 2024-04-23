
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using MPP_Csharp_Server_Client.FlightPersistence.DataBase;

namespace MPP_Csharp_Server_Client.FlightPersistence.DataBase
{
    public class MSSMConnectionFactory:ConnectionFactory
    {
        public override IDbConnection createConnection(IDictionary<string, string> props)
        {
            String connectionString = props["ConnectionString"];
            Console.WriteLine("SQLite ---Se deschide o conexiune la  ... {0}", connectionString);
            return new SQLiteConnection(connectionString);
        }
    }
}