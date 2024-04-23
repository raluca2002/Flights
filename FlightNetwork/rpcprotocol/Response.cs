using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightNetwork.rpcprotocol
{
    [Serializable]
    public class Response
    {
        private ResponseType type;
        private Object data;

        public ResponseType Type { get => this.type; set => this.type = value; }
        public object Data { get => this.data; set => this.data = value; }

        public Response() { }


        public override String ToString()
        {
            return "Response{" +
                   "type='" + type + '\'' +
                   ", data='" + data + '\'' +
                   '}';
        }


        public class Builder
        {
            private Response response = new Response();

            public Builder type(ResponseType type)
            {
                response.Type = type;
                return this;
            }

            public Builder data(Object data)
            {
                response.Data = data;
                return this;
            }

            public Response build()
            {
                return response;
            }
        }
    }
}
