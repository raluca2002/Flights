namespace MPP_Csharp_Server_Client.FlightModel.domain.exceptions
{
    public interface IMyHttpException
    {
        // public constructor required for non-abstract classes !!

        int Code { get; }
        string Message { get; }
        string StackTrace { get; }
    }
}