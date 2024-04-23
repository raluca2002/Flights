using log4net;
using MPP_Csharp_Server_Client.FlightModel.domain;
using MPP_Csharp_Server_Client.FlightPersistenceORM.repository;


namespace FlightPersistenceORM;

public class UserRepository : Repository<int, User>
{
    private static readonly ILog log = LogManager.GetLogger("AgenciesRepository");

    public User findByDestination(string destinatie, DateTime data)
    {
        return null;
    }

    public User save(User entity)
    {
        return null;
    }

    public User update(User entity)
    {
        return null;
    }

    public List<User> findAll()
    {
        List<User> users = new List<User>();

        var connection = ConnectionUtils.CreateConnection();
        var command = connection.CreateCommand();
        command.CommandText = "select * from user";
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            //User newUser = new User(dataR);
            int id = reader.GetInt32(0);
            string username = reader.GetString(1);
            string parola = reader.GetString(2);
            User user = new User(id, username, parola);
            users.Add(user);
        }

        return users;
    }

    public User findOne(int id)
    {
        var connection = ConnectionUtils.CreateConnection();
        var command = connection.CreateCommand();
        command.CommandText = "select * from user";
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            //User newUser = new User(dataR);
            int idi = reader.GetInt32(0);
            if (idi == id)
            {
                string username = reader.GetString(1);
                string parola = reader.GetString(2);
                User user = new User(id, username, parola);
                return user;
            }
        }

        return null;
    }


    public User findByName(string name)
    {
        var connection = ConnectionUtils.CreateConnection();
        var command = connection.CreateCommand();
        command.CommandText = "select * from user";
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            //User newUser = new User(dataR);
            int idi = reader.GetInt32(0);
            string username = reader.GetString(1);
            if (username == name)
            {
                string parola = reader.GetString(2);
                User user = new User(idi, username, parola);
                return user;
            }
        }

        return null;
    }

    public User delete(User entity)
    {
        return null;
    }
}