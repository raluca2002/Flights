using lab_rest.api.view_models;
using Microsoft.AspNetCore.Mvc;
using MPP_Csharp_Server_Client.Api.IterfaceControllers;
using MPP_Csharp_Server_Client.Api.view_models;
using MPP_Csharp_Server_Client.FlightModel.domain;
using MPP_Csharp_Server_Client.FlightsServices;

namespace Api.Controllers;
[ApiController]
[Route("flights")]
public class ZborController: ControllerBase, IZborController
{
    private IService _service;

    public ZborController(IService service)
    {
        _service = service;
    }
    [HttpPost]
    public IActionResult Add([FromBody] Zbor zbor)
    {
        return new JsonResultBuilder()
            .Initialize(() =>
            {
                _service.saveFlight(zbor.destinatie,zbor.data_ora,zbor.aeroport,zbor.locuri);
                return null;
            })
            .Build();
    }
    
    [HttpPut]
    public IActionResult Update([FromBody] Zbor zbor)
    {
        return new JsonResultBuilder()
            .Initialize(() =>
            {
                _service.buyTicket(zbor.id, "nume", "adresa",2, null);
                return null;
            })
            .Build();
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult Delete([FromRoute] int id)
    {
        return new JsonResultBuilder()
            .Initialize(() =>
            {
                _service.deleteFlight(id);
                return null;
            })
            .Build();
    }
    
   
        
    [HttpGet]
    public IActionResult GetAll([FromQuery] string? destinatie,[FromQuery] DateTime data_ora)
    {
        if (ReferenceEquals(destinatie,null) || data_ora==default)
        {
            return new JsonResultBuilder()
                .Initialize(() => _service.findAllFlights())
                .Build();
        }
        else
        {
            return new JsonResultBuilder()
                .Initialize(() => _service.findFlight(destinatie,data_ora))
                .Build();
        }
    }
}
