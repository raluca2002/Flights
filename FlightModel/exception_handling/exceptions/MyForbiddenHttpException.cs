namespace MPP_Csharp_Server_Client.FlightModel.domain.exceptions
{
    public class MyForbiddenHttpException : AbstractMyHttpException
    {
        public MyForbiddenHttpException(string message = "") : base(message, 403) { }
    }
}