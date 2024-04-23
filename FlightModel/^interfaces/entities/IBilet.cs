
namespace MPP_Csharp_Server_Client.FlightModel.domain
{
    public interface IBilet : ITableEntity
    { 
        int zbor_id { get; set; }
         int angajat_id { get; set; }
         string client_nume { get; set; }
        //public List<string> turisti
       string client_adresa { get; set; }
        int nr_locuri { get; set; }
    }
}