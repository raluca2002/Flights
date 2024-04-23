using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightNetwork.rpcprotocol
{
    [Serializable]
    internal class Request
    {
        private RequestType type;
        private Object data;

        public RequestType Type { get => this.type; set => this.type = value; }
        public object Data { get => this.data; set => this.data = value; }

        public Request() { }

        public override String ToString()
        {
            return "Request{" +
                    "type='" + type + '\'' +
                    ", data='" + data + '\'' +
                    '}';
        }
        public class Builder
        {
            private Request request = new Request();

            public Builder type(RequestType type)
            {
                request.Type = type;
                return this;
            }

            public Builder data(Object data)
            {
                request.Data = data;
                return this;
            }

            public Request build()
            {
                return request;
            }
        }

    }
}
