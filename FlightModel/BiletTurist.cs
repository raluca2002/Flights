using System;
using System.Data.SqlClient;

namespace MPP_Csharp_Server_Client.FlightModel.domain
{
    [Serializable]
    public class BiletTurist: Entity<int>
    {
        public int id_bilet { get; set; }
        public string turist { get; set; }

        public BiletTurist(int newId, int idBilet, string turist): base(newId)
        {
            id_bilet = idBilet;
            this.turist = turist;
        }
        
        public BiletTurist():base(-1){}
        public override string to_string()
        {
            throw new NotImplementedException();
        }
    }
}