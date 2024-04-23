using System.Data;
using System;
using System.Data.SqlClient;
using System.Data.SqlClient;
using MPP_Csharp_Server_Client.FlightModel.domain;
using System.Collections.Generic;
using System.Text;
using log4net;
using MPP_Csharp_Server_Client.FlightPersistence.DataBase;

namespace MPP_Csharp_Server_Client.FlightPersistence.repository
{
    public class BiletRepository :Repository<int, Bilet>
    {
         private static readonly ILog log = LogManager.GetLogger("AgenciesRepository");

        IDictionary<String, string> props;

        public BiletRepository(IDictionary<String, string> props)
        {
            log.Info("Creating BiletRepository ");
            this.props = props;
        }

        public List<Bilet> findAll()
        {
            string sql = "select * from bilet";

            IDbConnection db = DBUtils.getConnection(props);

            List<Bilet> users = new List<Bilet>();

            using (var dataReader = db.CreateCommand())
            {
                dataReader.CommandText = sql;
                using (var dataR = dataReader.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        //User newUser = new User(dataR);
                        int id = dataR.GetInt32(0);
                        int ai = dataR.GetInt32(1);
                       int zi = dataR.GetInt32(2);
                        String nume = dataR.GetString(3);
                        String adresa = dataR.GetString(4);
                        int locuri = dataR.GetInt32(5);
                        Bilet bilet = new Bilet(id, zi, ai, nume, adresa, locuri);

                        users.Add(bilet);
                    }
                }
            }

            return users;
        }

        public Bilet findOne(int id)
        {
            return null ;
        }
        public Bilet findByName(string name)
        {
            return null ;
        }

        public Bilet findByDestination(string destinatie, DateTime data)
        {
            return null;
        }

        public Bilet save(Bilet entity)
        {
            string sql = "insert into bilet (bilet_id, angajat_id, zbor_id, client_nume, client_adresa, nr_locuri) values (@id, @ai,@zi, @cn, @ca, @nl)";

            log.InfoFormat("Entering ... with value {0}", entity);
            var con = DBUtils.getConnection(props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = sql;
                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.id;
                comm.Parameters.Add(paramId);

                var paramIdAng = comm.CreateParameter();
                paramIdAng.ParameterName = "@ai";
                paramIdAng.Value = entity.angajat_id;
                comm.Parameters.Add(paramIdAng);

                var paramIdZbor = comm.CreateParameter();
                paramIdZbor.ParameterName = "@zi";
                paramIdZbor.Value = entity.zbor_id;
                comm.Parameters.Add(paramIdZbor);
                
                var paramIdClient = comm.CreateParameter();
                paramIdClient.ParameterName = "@cn";
                paramIdClient.Value = entity.client_nume;
                comm.Parameters.Add(paramIdClient);
                
                var paramIdAdr = comm.CreateParameter();
                paramIdAdr.ParameterName = "@ca";
                paramIdAdr.Value = entity.client_adresa;
                comm.Parameters.Add(paramIdAdr);

                var paramLoc = comm.CreateParameter();
                paramLoc.ParameterName = "@nl";
                paramLoc.Value = entity.nr_locuri;
                comm.Parameters.Add(paramLoc);
                
                var result = comm.ExecuteNonQuery();
                if (result == 0)
                {
                    log.InfoFormat("Not saved {0} instances", entity);
                    return null;
                }
                else
                {
                    log.InfoFormat("Saved {0} instances", entity);
                    return entity;
                }
            }
        }
       /*public Bilet save(Bilet bilet)
       {
           var ok = 1;
           if (ok == 1)
           {
               var connection = DBUtils.getConnection(props);
               {
                   var cmd = connection.CreateCommand();
                   cmd.CommandText =
                       "insert into bilet(bilet_id,angajat_id,zbor_id,client_nume,client_adresa,nr_locuri) values (@id, @ai,@zi, @cn, @ca, @nl)";
                   var data = cmd.CreateParameter();
                   data.ParameterName = "@id";
                   data.Value = bilet.id;
                   cmd.Parameters.Add(data);

                   var locatie = cmd.CreateParameter();
                   locatie.ParameterName = "@ai";
                   locatie.Value = bilet.angajat_id;
                   cmd.Parameters.Add(locatie);

                   var disp = cmd.CreateParameter();
                   disp.ParameterName = "@zi";
                   disp.Value = bilet.zbor_id;
                   cmd.Parameters.Add(disp);

                   var vand = cmd.CreateParameter();
                   vand.ParameterName = "@cn";
                   vand.Value = bilet.client_nume;
                   cmd.Parameters.Add(vand);

                   var idArtist = cmd.CreateParameter();
                   idArtist.ParameterName = "@ca";
                   idArtist.Value = bilet.client_adresa;
                   
                   var loc = cmd.CreateParameter();
                   loc.ParameterName = "@nl";
                   loc.Value = bilet.nr_locuri;
                   cmd.Parameters.Add(loc);
                   cmd.ExecuteNonQuery();
               }
           }
           else throw new Exception("biletul exista deja in baza de date!");

           return bilet;
       }*/

        public Bilet update(Bilet entity)
        {
            return null;
        }
    }
}