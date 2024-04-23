using System.Collections.Generic;
using MPP_Csharp_Server_Client.FlightModel.domain;

namespace MPP_Csharp_Server_Client.FlightsServices
{
    public interface IObserver
    {
        void boughtTickets(List<Zbor> zbor);
    }
}