using System.Data;
using log4net;
using MPP_Csharp_Server_Client.FlightModel.domain;
using MPP_Csharp_Server_Client.FlightPersistenceORM.repository;


namespace FlightPersistenceORM;

public class BiletRepository : Repository<int, Bilet>
{
    private static readonly ILog log = LogManager.GetLogger("AgenciesRepository");

    public Bilet findByDestination(string destinatie, DateTime data)
    {
        return null;
    }

    public Bilet save(Bilet entity)
    {
        var connection = ConnectionUtils.CreateConnection();
        var command = connection.CreateCommand();
        command.CommandText = "insert into bilet (id, angajat_id, zbor_id, client_nume, client_adresa, nr_locuri) values (@id, @ai,@zi, @cn, @ca, @nl)";
        command.Parameters.Add("@id", DbType.Int32);
        command.Parameters["@id"].Value = entity.id;
        command.Parameters.Add("@ai", DbType.Int32);
        command.Parameters["@ai"].Value = entity.angajat_id;
        command.Parameters.Add("@zi", DbType.Int32);
        command.Parameters["@zi"].Value = entity.zbor_id;
        command.Parameters.Add("@cn", DbType.String);
        command.Parameters["@cn"].Value = entity.client_nume;
        command.Parameters.Add("@ca", DbType.String);
        command.Parameters["@ca"].Value = entity.client_adresa;
        command.Parameters.Add("@nl", DbType.Int32);
        command.Parameters["@nl"].Value = entity.nr_locuri;
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

    public Bilet update(Bilet entity)
    {
        return null;
    }

    public List<Bilet> findAll()
    {
        List<Bilet> users = new List<Bilet>();

        var connection = ConnectionUtils.CreateConnection();
        var command = connection.CreateCommand();
        command.CommandText = "select * from bilet";
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            //User newUser = new User(dataR);
            int id = reader.GetInt32(0);
            int ai = reader.GetInt32(1);
            int zi = reader.GetInt32(2);
            String nume = reader.GetString(3);
            String adresa = reader.GetString(4);
            int locuri = reader.GetInt32(5);
            Bilet bilet = new Bilet(id, zi, ai, nume, adresa, locuri);

            users.Add(bilet);
        }

        return users;
    }

    public Bilet findOne(int id)
    {
        return null;
    }


    public Bilet findByName(string name)
    {
        return null;
    }

    public Bilet delete(Bilet entity)
    {
        return null;
    }
}