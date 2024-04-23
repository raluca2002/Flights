using System;

namespace FlightNetwork.DTOs
{
    [Serializable]
    public class ZborDTO
    {
        public int id { get; set; }
        public string destinatie { get; set; }
        public DateTime data_ora { get; set; }
        public  string aeroport { get; set; }
        public  int locuri { get; set; }

        public ZborDTO(int id, string destinatie, DateTime dataOra, string aeroport, int locuri)
        {
            this.id = id;
            this.destinatie = destinatie;
            data_ora = dataOra;
            this.aeroport = aeroport;
            this.locuri = locuri;
        }
    }
}