using System;
using System.Collections.Generic;
using MPP_Csharp_Server_Client.FlightModel.domain;


namespace MPP_Csharp_Server_Client.FlightsServices
{
    public interface IService
    {
        List<Zbor> findAllFlights();
        bool login(string username, string password, IObserver client);
        List<Zbor> findFlight(string destination, DateTime data);
        Zbor findOne(int id);
        void buyTicket(int zbor_id, string client_nume, string client_adresa, int nr_locuri, List<String> turisti);
        void logout();
        List<Zbor> getAvailableFlights();
        void deleteFlight(int id);
        void saveFlight(string destinatie, DateTime data_ora, string aeroport, int locuri);
    }
}