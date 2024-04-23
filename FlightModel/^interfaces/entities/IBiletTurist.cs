namespace MPP_Csharp_Server_Client.FlightModel.domain
{
    public interface IBiletTurist : ITableEntity
    {
        int id_bilet { get; set; }
        string turist { get; set; }
    }
}