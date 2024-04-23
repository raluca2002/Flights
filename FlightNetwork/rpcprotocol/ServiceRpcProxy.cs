using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FlightNetwork.DTOs;
using MPP_Csharp_Server_Client.FlightModel.domain;
using MPP_Csharp_Server_Client.FlightsServices;

namespace FlightNetwork.rpcprotocol
{
    public class ServiceRpcProxy : IService
    {
        private String host;
        private int port;
        private NetworkStream stream;
        private IFormatter formatter;
        private TcpClient connection;
        private Queue<Response> qresponses;
        private volatile bool finished;
        private EventWaitHandle _waitHandle;

        private String username = null;
        private IObserver client = null;


        public ServiceRpcProxy(String host, int port)
        {
            this.host = host;
            this.port = port;
            qresponses = new Queue<Response>();
            initializeConnection();
        }

        public bool login(String usernamee, String password, IObserver client)
        {
            initializeConnection();
            LoginDTO userDTO = new LoginDTO(usernamee, password);
            Request request = new Request.Builder().type(RequestType.LOGIN).data(userDTO).build();
            sendRequest(request);
            Response response = readResponse();

            Boolean loggedIn = false;

            if (response.Type == ResponseType.OK)
            {
                loggedIn = (Boolean)response.Data;
                if (loggedIn)
                {
                    this.client = client;
                    this.username = usernamee;
                    return true;
                }
            }
            else if (response.Type == ResponseType.ERROR)
            {
                String err = response.Data.ToString();
                closeConnection();
                throw new Exception(err);
            }
            return loggedIn;
        }

        public List<Zbor> findAllFlights()
        {
            Request req = new Request.Builder().type(RequestType.GET_ALL_FLIGHTS).build();
            sendRequest(req);
            Response response = readResponse();
            if (response.Type == ResponseType.ERROR)
            {
                String err = response.Data.ToString();
                throw new Exception(err);
            }
            List<Zbor> zboruri = (List<Zbor>)response.Data;

            return zboruri;
        }
        public List<Zbor> findFlight(string destinatie, DateTime data_ora)
        {
            Zbor zbor = new Zbor(0, destinatie, data_ora, "", 0);
            Request req = new Request.Builder().type(RequestType.GET_FOUND_FLIGHTS).data(zbor).build();
            sendRequest(req);
            Response response = readResponse();
            if (response.Type == ResponseType.ERROR)
            {
                String err = response.Data.ToString();
                throw new Exception(err);
            }
            List<Zbor> DTOzbor = (List<Zbor>)response.Data;
            return DTOzbor;
        }

        public void buyTicket(int zborId, string client_nume, string client_adresa, int nr_locuri, List<string> turisti)
        {
            BiletDTO registrationDTO = new BiletDTO(0,zborId,client_nume,  client_adresa,  nr_locuri);
            Request req = new Request.Builder().type(RequestType.BUY).data(registrationDTO).build();
            sendRequest(req);
            Response response = readResponse();
            if (response.Type == ResponseType.ERROR)
            {
                if (response.Data == null)
                {
                    throw new Exception("An error occurred, but no details were provided.");
                }
                String err = response.Data.ToString();
                throw new Exception(err);
            }
        }
        
        

        public Zbor findOne(int id)
        {
            return null;
        }

        public List<Zbor> getAvailableFlights()
        {
            return null;
        }


        public void logout()
        {
            UserDTO userDTO = new UserDTO(0,username, null);
            Request req = new Request.Builder().type(RequestType.LOGOUT).data(userDTO).build();
            sendRequest(req);
            Console.WriteLine(req);
            Response response = readResponse();
            closeConnection();
            username = null;
            client = null;
            if (response.Type == ResponseType.ERROR)
            {
                String err = response.Data.ToString();
                throw new Exception(err);
            }
        }

        public void saveFlight(string dest, DateTime data, string aeroport, int locuri){}
        public void deleteFlight(int id){}

        private void closeConnection()
        {
            finished = true;
            try
            {
                stream.Close();
                connection.Close();
                client = null;
            }
            catch (IOException e)
            {
                Console.WriteLine(e.StackTrace);
            }

        }

        private void sendRequest(Request request)
        {
            try
            {
                if (formatter != null && stream != null)
                {
                    formatter.Serialize(stream, request);
                    stream.Flush();
                }
                else
                {
                    throw new Exception("Formatter or stream is null");
                }
            }
            catch (IOException e)
            {
                throw new Exception("Error sending object " + e);
            }

        }

        private Response readResponse()
        {
            Response response = null;
            try
            {
                _waitHandle.WaitOne();
                lock (qresponses)
                {
                    //Monitor.Wait(responses); 
                    response = qresponses.Dequeue();

                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            return response;
        }

        private void initializeConnection()
        {
            try
            {
                connection = new TcpClient(host, port);
                stream = connection.GetStream();
                formatter = new BinaryFormatter();
                finished = false;
                _waitHandle = new AutoResetEvent(false);
                startReader();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private void startReader()
        {
            Thread tw = new Thread(run);
            tw.Start();
        }

        public void run()
        {
            while (!finished)
            {
                try
                {
                    Response response = (Response)formatter.Deserialize(stream);
                    Console.WriteLine("response received " + response);
                    if (response.Type == ResponseType.UPDATE)
                    {
                        List<Zbor> zboruri = (List<Zbor>)response.Data;
                        client.boughtTickets(zboruri);
                    }
                    else
                    {
                        lock (qresponses)
                        {
                            qresponses.Enqueue((Response)response);
                        }
                        _waitHandle.Set();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Reading error " + e);
                }

            }
        }
    }
}
