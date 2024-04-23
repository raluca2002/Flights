using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FlightNetwork.rpcprotocol;
using MPP_Csharp_Server_Client.FlightsServices;

namespace FlightNetwork.utils
{
    public class RpcConcurrentServer : AbsConcurrentServer
    {
        private IService server;

        public RpcConcurrentServer(string host, int port, IService server) : base(host, port)
        {
            this.server = server;
            Console.WriteLine("RpcConcurrentServer");
        }


        protected override Thread createWorker(TcpClient client)
        {
            ClientRpcWorker worker = new ClientRpcWorker(server, client);
            return new Thread(new ThreadStart(worker.run));
        }
    }
}
