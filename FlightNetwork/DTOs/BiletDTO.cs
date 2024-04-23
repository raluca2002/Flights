using System;

namespace FlightNetwork.DTOs
{
    [Serializable]
    public class BiletDTO
    {
        public int bilet_id { get; set; }
        public int zbor_id { get; set; }
        public string client_nume { get; set; }
        public string client_adresa { get; set; }
        public int nr_locuri { get; set; }

        
        public BiletDTO(int biletId, int zborid, string clientNume, string clientAdresa, int nrLocuri)
        
        {
            bilet_id = biletId;      
            client_nume = clientNume;
            client_adresa = clientAdresa;
            nr_locuri = nrLocuri;
            zbor_id = zborid;
        }
    }
}