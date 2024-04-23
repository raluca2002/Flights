using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightNetwork.utils
{
    public abstract class AbsConcurrentServer : AbstractServer
    {

        public AbsConcurrentServer(string host, int port) : base(host, port)
        {
        }

        public override void processRequest(TcpClient client)
        {
            Thread t = createWorker(client);
            t.Start();

        }

        protected abstract Thread createWorker(TcpClient client);

    }
}
