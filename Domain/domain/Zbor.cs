using System;
using System.Data.SqlClient;

namespace Incercare.domain
{
    public class Zbor: Entity<int>
    {
        public string destinatie { get; set; }
        public DateTime data_ora { get; set; }
        public string aeroport { get; set; }
        public int locuri { get; set; }

        public Zbor(int newId, string destinatie, DateTime dataOra, string aeroport, int locuri) : base(newId)
        {
            this.destinatie = destinatie;
            data_ora = dataOra;
            this.aeroport = aeroport;
            this.locuri = locuri;
        }

        public override string to_string()
        {
            return destinatie + data_ora + aeroport + locuri;
        }
    }
}