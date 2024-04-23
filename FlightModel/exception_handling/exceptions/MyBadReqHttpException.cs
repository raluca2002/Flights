namespace MPP_Csharp_Server_Client.FlightModel.domain.exceptions
{
    public class MyBadReqHttpException : AbstractMyHttpException
    {
        public MyBadReqHttpException(string message = "") : base(message, 400) { }
    }
}