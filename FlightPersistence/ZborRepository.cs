using MPP_Csharp_Server_Client.FlightModel.domain;
using System;
using System.Data.SqlClient;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using MPP_Csharp_Server_Client.FlightPersistence.DataBase;
using log4net;

namespace MPP_Csharp_Server_Client.FlightPersistence.repository
{
    public class ZborRepository : Repository<int, Zbor>
    {
        //private SqlConnection connection;
        private static readonly ILog log = LogManager.GetLogger("AgenciesRepository");

        IDictionary<String, string> props;

        public ZborRepository(IDictionary<String, string> props)
        {
            log.Info("Creating ZborRepository ");
            this.props = props;
        }


        public List<Zbor> findAll()
        {
            string sql = "select * from zbor";

            IDbConnection db = DBUtils.getConnection(props);

            List<Zbor> users = new List<Zbor>();

            using (var dataReader = db.CreateCommand())
            {
                dataReader.CommandText = sql;
                using (var dataR = dataReader.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        //User newUser = new User(dataR);
                        int id = dataR.GetInt32(0);
                        string destinatie = dataR.GetString(1);
                        DateTime data_ora = dataR.GetDateTime(2);
                        String aeroport = dataR.GetString(3);
                        int locuri = dataR.GetInt32(4);
                        Zbor zbor = new Zbor(id, destinatie, data_ora, aeroport, locuri);

                        users.Add(zbor);
                    }
                }
            }

            return users;
        }


        public Zbor findOne(int id)
        {
            string sql = "select * from zbor";

            IDbConnection db = DBUtils.getConnection(props);

            List<Zbor> users = new List<Zbor>();

            using (var dataReader = db.CreateCommand())
            {
                dataReader.CommandText = sql;
                using (var dataR = dataReader.ExecuteReader())
                {
                    //User newUser = new User(dataR);
                    int idi = dataR.GetInt32(0);
                    if (idi == id)
                    {
                        string destinatie = dataR.GetString(1);
                        DateTime data = dataR.GetDateTime(2);
                        string aeroport = dataR.GetString(3);
                        int locuri = dataR.GetInt32(4);
                        Zbor zbor = new Zbor(id, destinatie, data, aeroport, locuri);
                        return zbor;
                    }
                }
            }

            return null;
        }

        public Zbor findByName(string name)
        {
            return null;
        }

        public Zbor findByDestination(string destinatie, DateTime data)
        {
            string sql = "select * from zbor";

            IDbConnection db = DBUtils.getConnection(props);

            List<Zbor> users = new List<Zbor>();

            using (var dataReader = db.CreateCommand())
            {
                dataReader.CommandText = sql;
                using (var dataR = dataReader.ExecuteReader())
                {
                    //User newUser = new User(dataR);
                    int idi = dataR.GetInt32(0);
                    string dest = dataR.GetString(1);
                    DateTime data_ora = dataR.GetDateTime(2);
                    if (dest == destinatie && data_ora.Date == data.Date)
                    {
                        string aeroport = dataR.GetString(3);
                        int locuri = dataR.GetInt32(4);
                        Zbor zbor = new Zbor(idi, destinatie, data, aeroport, locuri);
                        return zbor;
                    }
                }
            }

            return null;
        }

        public Zbor save(Zbor entity)
        {
            return null;
        }

        /*   public Zbor update(Zbor entity)
           {
               log.InfoFormat("Entering findOne with value {0}", entity);
               var con = DBUtils.getConnection(props);
   
               using (var comm = con.CreateCommand())
               {
                   comm.CommandText = "update zbor set locuri=@nr_locuri where zbor_id=@id";
                   var paramId = comm.CreateParameter();
                   paramId.ParameterName = "@id";
                   paramId.Value = entity.id;
                   comm.Parameters.Add(paramId);
   
                   var paramDestination = comm.CreateParameter();
                   paramDestination.ParameterName = "@nr_locuri";
                   paramDestination.Value = entity.locuri;
                   comm.Parameters.Add(paramDestination);
   
                   var result = comm.ExecuteNonQuery();
                   if (result == 0)
                   {
                       log.InfoFormat("Not saved {0} instances", entity);
                       return entity;
                   }
                   else
                   {
                       log.InfoFormat("Saved {0} instances", entity);
                       return null;
                   }
               }
           }*/
        public Zbor update(Zbor zbor)
        {
            var connection = DBUtils.getConnection(props);
            var cmd = connection.CreateCommand();
            cmd.CommandText = "update zbor set locuri=@disp where zbor_id=@id";
            var idParameter = cmd.CreateParameter();
            idParameter.ParameterName = "@id";
            idParameter.Value = zbor.id;
            cmd.Parameters.Add(idParameter);
            var disp = cmd.CreateParameter();
            disp.ParameterName = "@disp";
            disp.Value = zbor.locuri;
            cmd.Parameters.Add(disp);
            cmd.ExecuteNonQuery();
            return zbor;
        }
    }
}
