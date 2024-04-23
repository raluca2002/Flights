using System.Data;
using log4net;
using MPP_Csharp_Server_Client.FlightModel.domain;
using MPP_Csharp_Server_Client.FlightPersistenceORM.repository;

namespace FlightPersistenceORM;

public class BiletTuristiRepository : Repository<int, BiletTurist>
{
    private static readonly ILog log = LogManager.GetLogger("AgenciesRepository");

    public BiletTurist findByDestination(string destinatie, DateTime data)
    {
        return null;
    }

    public BiletTurist save(BiletTurist entity)
    {
        var connection = ConnectionUtils.CreateConnection();
        var command = connection.CreateCommand();
        command.CommandText = "insert into bilet_turisti (id_bilet, turist) values (@ib, @tn)";
        command.Parameters.Add("@ib", DbType.Int32);
        command.Parameters["@ib"].Value = entity.id_bilet;
        command.Parameters.Add("@tn", DbType.String);
        command.Parameters["@tn"].Value = entity.turist;
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

    public BiletTurist update(BiletTurist entity)
    {
        return null;
    }

    public List<BiletTurist> findAll()
    {
        return null;
    }

    public BiletTurist findOne(int id)
    {
        return null;
    }


    public BiletTurist findByName(string name)
    {
        return null;
    }

    public BiletTurist delete(BiletTurist entity)
    {
        return null;
    }
}