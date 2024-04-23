using Microsoft.AspNetCore.Mvc;
using MPP_Csharp_Server_Client.Api.view_models;
using MPP_Csharp_Server_Client.FlightModel.domain;

namespace MPP_Csharp_Server_Client.Api.IterfaceControllers;

public interface IZborController
{
    IActionResult GetAll(string destinatie, DateTime data_ora);
    //MyHttpResponseMessage GetOne();
    IActionResult Add(Zbor zbor);
    IActionResult Update(Zbor zbor);
    IActionResult Delete(int id);
}