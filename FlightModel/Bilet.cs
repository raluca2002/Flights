using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MPP_Csharp_Server_Client.FlightModel.domain
{
    [Serializable]
    public class Bilet: Entity<int>
    {
        public int zbor_id { get; set; }
        public int angajat_id { get; set; }
        public string client_nume { get; set; }
        //public List<string> turisti
        public string client_adresa { get; set; }
        public int nr_locuri { get; set; }

        public Bilet(int newId, int zborId, int angajatId, string clientNume, string clientAdresa, int nrLocuri) : base(newId)
        {
            zbor_id = zborId;
            angajat_id = angajatId;
            client_nume = clientNume;
            client_adresa = clientAdresa;
            nr_locuri = nrLocuri;
        }
        
        public Bilet():base(-1){}

        public override string to_string()
        {
            return zbor_id + client_nume + client_adresa + nr_locuri;
        }
    }
}