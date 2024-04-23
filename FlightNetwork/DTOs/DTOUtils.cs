using System;
using System.Collections.Generic;
using MPP_Csharp_Server_Client.FlightModel.domain;

namespace FlightNetwork.DTOs
{
    public class DTOUtils
    {
        public static Zbor getFromDTO(ZborDTO zborDTO)
        {
            int id = zborDTO.id;
            string destinatie = zborDTO.destinatie;
            DateTime data_ora = zborDTO.data_ora;
            string aeroport = zborDTO.aeroport;
            int locuri = zborDTO.locuri;
            return new Zbor(id, destinatie, data_ora, aeroport, locuri);
        }
        
        
        public static ZborDTO getDTO(Zbor zbor)
        {
            int id = zbor.id;
            string destinatie = zbor.destinatie;
            DateTime data_ora = zbor.data_ora;
            int locuri = zbor.locuri;
            string aeroport = zbor.aeroport;
            return new ZborDTO(id, destinatie, data_ora, aeroport, locuri);
        }
    }
}