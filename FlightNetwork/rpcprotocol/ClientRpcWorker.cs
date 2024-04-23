using System;
using System.Collections.Generic;
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
    internal class ClientRpcWorker : IObserver
    {
        private IService server;
        private TcpClient connection;
        private NetworkStream stream;
        private IFormatter formatter;
        private volatile bool connected;


        public ClientRpcWorker(IService server, TcpClient connection)
        {
            this.server = server;
            this.connection = connection;
            try
            {
                stream = connection.GetStream();
                formatter = new BinaryFormatter();
                connected = true;
            }
            catch (IOException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public void run()
        {
            while (connected)
            {
                try
                {
                    if (stream != null && formatter!=null)
                    {
                        Object request = formatter.Deserialize(stream);
                        Response response = handleRequest((Request)request);
                        if (response != null)
                        {
                            sendResponse(response);
                        }
                    }
                    else{Console.WriteLine("stream null");}
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }

                // why do we need this?
                try
                {
                    Thread.Sleep(1000);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
            try
            {
                stream.Close();
                connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e);
            }
        }


        private Response handleRequest(Request request)
        {
            Response response = null;

            switch (request.Type)
            {
                case RequestType.LOGIN:
                    {
                        response = solveLogin(request);
                        break;
                    }
                case RequestType.LOGOUT:
                    {
                        response = solveLogout(request);
                        break;
                    }
                case RequestType.GET_ALL_FLIGHTS:
                    {
                        response = solveGetFlights(request);
                        break;
                    }
                case RequestType.GET_FOUND_FLIGHTS:
                    {
                        response = solveGetFoundFlight(request);
                        break;
                    }
                case RequestType.BUY:
                    {
                        response = solveBuyTicket(request);
                        break;
                    }
            }
            return response;
        }


        private Response solveBuyTicket(Request request)
        {
            Console.WriteLine("BuyTicket Request ...");
            Console.WriteLine($"request.Data = {request.Data}");
            Console.WriteLine($"request.Data type = {request.Data.GetType()}");
            BiletDTO biletDTO = (BiletDTO)request.Data;

            try
            {
                //Bilet bilet = DTOUtils.getFromDTO(biletDTO);
                server.buyTicket(biletDTO.zbor_id, biletDTO.client_nume, biletDTO.client_adresa, biletDTO.nr_locuri, null);
                return new Response.Builder().type(ResponseType.BOUGHT).build();
            }
            catch (Exception e)
            {
                return new Response.Builder().type(ResponseType.ERROR).data(e.Message).build();
            }
        }

        private Response solveGetFoundFlight(Request request)
        {
            Console.WriteLine("GetParticipantsOfContest Request ...");
            Console.WriteLine($"request.Data = {request.Data}");
            Console.WriteLine($"request.Data type = {request.Data.GetType()}");
            Zbor zbor = (Zbor)request.Data;
            
            //int contestId = (int)request.Data;
            try
            {
                List<Zbor> zborDTOList = server.findFlight(zbor.destinatie, zbor.data_ora);
                return new Response.Builder().type(ResponseType.FOUND_FLIGHTS).data(zborDTOList).build();
            }
            catch (Exception e)
            {
                return new Response.Builder().type(ResponseType.ERROR).data(e.Message).build();
            }
        }

        private Response solveGetFlights(Request request)
        {
            Console.WriteLine("GetContests Request ...");
            try
            {
                List<Zbor> contests = server.findAllFlights();
                return new Response.Builder().type(ResponseType.ALL_FLIGHTS).data(contests).build();
            }
            catch (Exception e)
            {
                return new Response.Builder().type(ResponseType.ERROR).data(e.Message).build();
            }
        }

        private Response solveLogout(Request request)
        {
            Console.WriteLine("Logout request");

            UserDTO userDTO = (UserDTO)request.Data;
            String username = userDTO.username;
            try
            {
                server.logout();
                connected = false;
                return new Response.Builder().type(ResponseType.OK).data(true).build();
            }
            catch (Exception e)
            {
                return new Response.Builder().type(ResponseType.ERROR).data(e.Message).build();
            }
        }

        private Response solveLogin(Request request)
        {
            Console.WriteLine("Login request ..." + request.Type);
            Console.WriteLine($"request.Data = {request.Data}");
            Console.WriteLine($"request.Data type = {request.Data.GetType()}");
            LoginDTO userDTO = (LoginDTO)request.Data;
            String username = userDTO.username;
            String password = userDTO.password;

            try
            {
                Boolean loggedIn = server.login(username, password, this);
                return new Response.Builder().type(ResponseType.OK).data(loggedIn).build();
            }
            catch (Exception e)
            {
                connected = false;
                return new Response.Builder().type(ResponseType.ERROR).data(e.Message).build();
            }
        }

        private void sendResponse(Response response)
        {
            Console.WriteLine("sending response " + response);
            lock (stream)
            {
                formatter.Serialize(stream, response);
                stream.Flush();
            }
        }

        public void boughtTickets(List<Zbor> zbor)
        {
            Response resp = new Response.Builder().type(ResponseType.UPDATE).build();
            Console.WriteLine("ticket added");
            try
            {
                sendResponse(resp);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
