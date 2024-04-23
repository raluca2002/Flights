using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Xml.Schema;
using MPP_Csharp_Server_Client.FlightModel.domain;
using MPP_Csharp_Server_Client.FlightPersistence.repository;
using MPP_Csharp_Server_Client.FlightsServices;

namespace MPP_Csharp_Server_Client.FlightServer
{
    public class Service: IService
    {
        private UserRepository repou;
        private ZborRepository repoz;
        private BiletRepository repob;
        private BiletTuristRepository repobt;
        private readonly IDictionary<Zbor, IObserver> flightManage;
        private readonly IDictionary<int, IObserver> loggedClients;
        private int user_id;
        //public DBContext dataBaseContext;

        
       /* static string GetConnectionStringByName(string name)
        {
            string returnValue = null;

            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];

            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }*/

       public Service(UserRepository repou, ZborRepository repoz, BiletRepository repob, BiletTuristRepository repobt)
       {
           this.repou = repou;
           this.repoz = repoz;
           this.repob = repob;
           this.repobt = repobt;
           loggedClients = new Dictionary<int, IObserver>();
           flightManage = new Dictionary<Zbor, IObserver>();
           
       }

       public List<Zbor> findAllFlights()
        {
            return repoz.findAll();
        }

        public bool login(string username, string password, IObserver client)
        {
            List<User> users = repou.findAll();
            foreach(User user in users)
            {
                if (user.username == username && user.password==password)
                {
                    user_id = user.id;
                    loggedClients[user.id] = client;
                    return true;
                }
            }
            return false;
        }

        public List<Zbor> findFlight(string destination, DateTime data)
        {
            List<Zbor> zboruri = repoz.findAll();
            List<Zbor> newzboruri = new List<Zbor>();
            foreach (Zbor zbor in zboruri)
            {
                if (zbor.destinatie==destination && zbor.data_ora.Date==data.Date)
                    newzboruri.Add(zbor);
            }

            return newzboruri;
        }

        public int generate_id()
        { 
            List<Bilet> bilete = repob.findAll();
            int maxi = 0;
            foreach (Bilet bilet in bilete)
            {
                if (bilet.id > maxi)
                    maxi = bilet.id;
            }

            maxi = maxi + 1;
            return maxi;
        }


        public Zbor findOne(int id)
        {
            foreach (Zbor zbor in repoz.findAll())
            {
                if (zbor.id == id)
                    return zbor;
            }

            return null;
        }

        private void notifyBoughtTickets()
        {
            foreach (var user in loggedClients)
            {
                IObserver obs = user.Value;
                int id = user.Key;
                Task.Run(() => obs.boughtTickets(findAllFlights()));
            }
        }
        
        
        public void buyTicket(int zbor_id, string client_nume, string client_adresa, int nr_locuri, List<String> turisti)
        {
            int id = generate_id();
            Bilet bilet = new Bilet(id, zbor_id, user_id, client_nume, client_adresa, nr_locuri);
            repob.save(bilet);
            Zbor zbor = findOne(zbor_id);
            int locuri = zbor.locuri;
            zbor.locuri = locuri - nr_locuri;
            repoz.update(zbor);
            notifyBoughtTickets();
          ///  foreach(string turist in turisti)
           /// {
           ///     BiletTurist bt = new BiletTurist(id, turist);
             ///   repobt.save(bt);
            ///}
        }

        public void logout()
        {
            user_id = -1;
        }

        public List<Zbor> getAvailableFlights()
        {
            List<Zbor> zboruri = new List<Zbor>();
            foreach (Zbor zbor in repoz.findAll())
            {
                if (zbor.locuri>0)
                    zboruri.Add(zbor);
            }

            return zboruri;
        }
        
        public void deleteFlight(int id){}
        public void saveFlight(string destinatie, DateTime data_ora, string aerport, int loc){}
    }
}