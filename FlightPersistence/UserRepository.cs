using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using MPP_Csharp_Server_Client.FlightModel.domain;
using log4net;
using MPP_Csharp_Server_Client.FlightPersistence.DataBase;

namespace MPP_Csharp_Server_Client.FlightPersistence.repository
{
    public class UserRepository: Repository<int,User>
    {
        //private SqlConnection connection;
        private static readonly ILog log = LogManager.GetLogger("AgenciesRepository");

        IDictionary<String, string> props;

        public UserRepository(IDictionary<String, string> props)
        {
            log.Info("Creating UserRepository ");
            this.props = props;
        }
        
        ///private static readonly ILog log = LogManager.GetLogger(typeof(UserRepository));


        public List<User> findAll()
        {
            string sql = "select * from user";

            IDbConnection db = DBUtils.getConnection(props);
            
            List<User> users = new List<User>();

            using (var dataReader = db.CreateCommand())
            {
                dataReader.CommandText = sql;
                using (var dataR = dataReader.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        //User newUser = new User(dataR);
                        int id = dataR.GetInt32(0);
                        string username = dataR.GetString(1);
                        string parola = dataR.GetString(2);
                        User user = new User(id, username, parola);

                        users.Add(user);
                    }
                }
            }
            return users;
        }

        public User findOne(int id)
        {
            
            string sql = "select * from user";

            IDbConnection db = DBUtils.getConnection(props);
            

            using (var dataReader = db.CreateCommand())
            {
                dataReader.CommandText = sql;
                using (var dataR = dataReader.ExecuteReader())
                {
                    //User newUser = new User(dataR);
                    int idi = dataR.GetInt32(0);
                    if (idi == id)
                    {
                        string username = dataR.GetString(1);
                        string parola = dataR.GetString(2);
                        User user = new User(id, username, parola);
                        return user;
                    }
                }
            }
            return null;
           
        }
        public User findByName(string name)
        {
            string sql = "select * from user";

            IDbConnection db = DBUtils.getConnection(props);
            

            using (var dataReader = db.CreateCommand())
            {
                dataReader.CommandText = sql;
                using (var dataR = dataReader.ExecuteReader())
                {
                    //User newUser = new User(dataR);
                    int idi = dataR.GetInt32(0);
                    string username = dataR.GetString(1);
                    if (username == name)
                    {
                        string parola = dataR.GetString(2);
                        User user = new User(idi, username, parola);
                        return user;
                    }
                }
            }
            return null;

        }

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
    }
    
}