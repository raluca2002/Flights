using System.Data;
using log4net;
using MPP_Csharp_Server_Client.FlightModel.domain;
using MPP_Csharp_Server_Client.FlightPersistenceORM.repository;

namespace FlightPersistenceORM;

public class ZborRepository : Repository<int, Zbor>
{
    private static readonly ILog log = LogManager.GetLogger("AgenciesRepository");

    public Zbor findByDestination(string destinatie, DateTime data)
    {
        var connection = ConnectionUtils.CreateConnection();
        var command = connection.CreateCommand();
        command.CommandText = "select * from zbor";
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            //User newUser = new User(dataR);
            int idi = reader.GetInt32(0);
            string dest = reader.GetString(1);
            DateTime data_ora = reader.GetDateTime(2);
            if (dest == destinatie && data_ora.Date == data.Date)
            {
                string aeroport = reader.GetString(3);
                int locuri = reader.GetInt32(4);
                Zbor zbor = new Zbor(idi, destinatie, data, aeroport, locuri);
                return zbor;
            }
        }

        return null;
    }

    public Zbor save(Zbor entity)
    {
        var connection = ConnectionUtils.CreateConnection();
        var command = connection.CreateCommand();
        command.CommandText = "insert into zbor (destinatie, data_ora, aeroport, locuri) values (@dest, @do,@aer, @loc)";
        command.Parameters.Add("@dest", DbType.String);
        command.Parameters["@dest"].Value = entity.destinatie;
        command.Parameters.Add("@do", DbType.DateTime);
        command.Parameters["@do"].Value = entity.data_ora;
        command.Parameters.Add("@aer", DbType.String);
        command.Parameters["@aer"].Value = entity.aeroport;
        command.Parameters.Add("@loc", DbType.Int32);
        command.Parameters["@loc"].Value = entity.locuri;
        try
        {
            command.ExecuteNonQuery();
            return entity;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public Zbor update(Zbor entity)
    {
        var connection = ConnectionUtils.CreateConnection();
        var cmd = connection.CreateCommand();
        cmd.CommandText = "update zbor set locuri=@disp where id=@id";
        cmd.Parameters.Add("@disp", DbType.Int32);
        cmd.Parameters["@disp"].Value = entity.locuri;
        cmd.Parameters.Add("@id", DbType.Int32);
        cmd.Parameters["@id"].Value = entity.id;
        cmd.ExecuteNonQuery();
        return entity;

    }

    public List<Zbor> findAll()
    {
        List<Zbor> users = new List<Zbor>();

        var connection = ConnectionUtils.CreateConnection();
        var command = connection.CreateCommand();
        command.CommandText = "select * from zbor";
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            //User newUser = new User(dataR);
            int id = reader.GetInt32(0);
            string destinatie = reader.GetString(1);
            DateTime data_ora = reader.GetDateTime(2);
            String aeroport = reader.GetString(3);
            int locuri = reader.GetInt32(4);
            Zbor zbor = new Zbor(id, destinatie, data_ora, aeroport, locuri);

            users.Add(zbor);
        }

        return users;
    }

    public Zbor findOne(int id)
    {
        var connection = ConnectionUtils.CreateConnection();
        var command = connection.CreateCommand();
        command.CommandText = "select * from zbor";
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            //User newUser = new User(dataR);
            int idi = reader.GetInt32(0);
            if (idi == id)
            {
                string destinatie = reader.GetString(1);
                DateTime data = reader.GetDateTime(2);
                string aeroport = reader.GetString(3);
                int locuri = reader.GetInt32(4);
                Zbor zbor = new Zbor(id, destinatie, data, aeroport, locuri);
                return zbor;
            }
        }

        return null;
    }


    public Zbor findByName(string name)
    {
        return null;
    }

    public Zbor delete(Zbor entity)
    {
        var connection = ConnectionUtils.CreateConnection();
        var cmd = connection.CreateCommand();
        cmd.CommandText = "delete from zbor where id=@id";
        cmd.Parameters.Add("@id", DbType.Int32);
        cmd.Parameters["@id"].Value = entity.id;
        
        return entity;
    }
    
}