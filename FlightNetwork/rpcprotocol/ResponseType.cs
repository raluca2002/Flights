using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightNetwork.rpcprotocol
{
    [Serializable]
    public enum ResponseType
    {
        OK, ERROR, UPDATE, BOUGHT, FOUND_FLIGHTS, ALL_FLIGHTS
    }
}
