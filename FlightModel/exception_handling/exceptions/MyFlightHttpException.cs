namespace MPP_Csharp_Server_Client.FlightModel.domain.exceptions
{
    public class MyFlightHttpException : AbstractMyHttpException
    {
        public MyFlightHttpException(string message = "") : base(message, 418) {}
    }
}