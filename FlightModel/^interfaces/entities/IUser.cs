namespace MPP_Csharp_Server_Client.FlightModel.domain
{
    public interface IUser : ITableEntity
    {
        string username { get; set; }
        string password { get; set; }
    }
}