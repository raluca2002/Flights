using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightClient;
using FlightNetwork.rpcprotocol;
using MPP_Csharp_Server_Client.FlightsServices;

namespace FlightClient
{
    internal class RpcClient 
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IService server = new ServiceRpcProxy("127.0.0.1", 57777);
            Login login = new Login(server);
            Application.Run(login);
        }
    } //"127.0.0.1", 57777
}
