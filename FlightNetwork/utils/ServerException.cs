using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightNetwork.utils
{
    internal class ServerException : Exception
    {
        public ServerException(String message) : base(message)
        {
        }

        public ServerException(String message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
