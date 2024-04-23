

using System;

namespace MPP_Csharp_Server_Client.FlightModel.domain
{
    public interface IZbor : ITableEntity
    {
         string destinatie { get; set; }
        DateTime data_ora { get; set; }
         string aeroport { get; set; }
        int locuri { get; set; }
    }
}