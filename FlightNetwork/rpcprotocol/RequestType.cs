using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightNetwork.rpcprotocol
{
    [Serializable]
    public enum RequestType
    {
        LOGIN, LOGOUT, GET_FOUND_FLIGHTS, BUY, GET_ALL_FLIGHTS
    }
}
