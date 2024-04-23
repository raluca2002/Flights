namespace MPP_Csharp_Server_Client.FlightModel.domain.exceptions
{
    public class MyUnauthorizedHttpException : AbstractMyHttpException
    {
        public MyUnauthorizedHttpException(string message = "") : base(message, 401) { }
    }
}