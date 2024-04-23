using System.Data;
using MPP_Csharp_Server_Client.FlightModel.domain;
using System;
using System.Collections.Generic;
using log4net;
using MPP_Csharp_Server_Client.FlightPersistence.DataBase;

namespace MPP_Csharp_Server_Client.FlightPersistence.repository
{
    public class BiletTuristRepository :Repository<int, BiletTurist>
    {
        private static readonly ILog log = LogManager.GetLogger("AgenciesRepository");

        IDictionary<String, string> props;

        public BiletTuristRepository(IDictionary<String, string> props)
        {
            log.Info("Creating BiletTuristRepository ");
            this.props = props;
        }
        

        public List<BiletTurist> findAll()
        {
            return null;
        }

        public BiletTurist findOne(int id)
        {
            return null ;
        }
        public BiletTurist findByName(string name)
        {
            return null ;
        }

        public BiletTurist findByDestination(string destinatie, DateTime data)
        {
            return null;
        }

        public BiletTurist save(BiletTurist entity)
        {
            string sql = "insert into bilet_turisti (id_bilet, turist_nume) values (@ib, @tn)";
            
            log.InfoFormat("Entering findOne with value {0}", entity);
            var con = DBUtils.getConnection(props);

            using (var comm = con.CreateCommand())
            {

                var paramIdAng = comm.CreateParameter();
                paramIdAng.ParameterName = "@ib";
                paramIdAng.Value = entity.id_bilet;
                comm.Parameters.Add(paramIdAng);

                var paramIdZbor = comm.CreateParameter();
                paramIdZbor.ParameterName = "@tn";
                paramIdZbor.Value = entity.turist;
                comm.Parameters.Add(paramIdZbor);
                
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
        }

        public BiletTurist update(BiletTurist entity)
        {
            return null;
        }
    }
}