

using System;

namespace MPP_Csharp_Server_Client.FlightModel.domain.exceptions
{
    public class AbstractMyHttpException
        : Exception, IMyHttpException
    {
        private readonly int _code;

        protected AbstractMyHttpException(string message, int code) : base(message)
        {
            _code = code;
        }
        
        public int Code => _code;
        public new string Message => base.Message;
        public new string StackTrace => base.StackTrace ?? "";
    }
}