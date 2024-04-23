namespace MPP_Csharp_Server_Client.FlightModel.domain.exceptions
{
    public class MyInternalServerErrorHttpException : AbstractMyHttpException
    {
        public MyInternalServerErrorHttpException(string message = "") : base(message, 500) { }
    }
}