using System.Data.SqlClient;

namespace Incercare.domain
{
    public class BiletTurist
    {
        public int id_bilet { get; set; }
        public string turist { get; set; }

        public BiletTurist(int idBilet, string turist)
        {
            id_bilet = idBilet;
            this.turist = turist;
        }
    }
}