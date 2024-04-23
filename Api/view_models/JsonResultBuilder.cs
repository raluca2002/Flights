using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

using lab_rest.api._interfaces.view_models;
using MPP_Csharp_Server_Client.FlightModel.domain.exceptions;


namespace lab_rest.api.view_models
{
    public class JsonResultBuilder : IJsonResultBuilder
    {
        private readonly JsonResult _jsonResult;
        
        public JsonResultBuilder()
        {
            JsonSerializerOptions settings = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
            };
            _jsonResult = new JsonResult(string.Empty, settings);
        }
        
        public IJsonResultBuilder Initialize(Func<object?> getContent)
        {
            try
            {
                object? content = getContent.Invoke();
                _jsonResult.Value = content;
                _jsonResult.StatusCode = 200;
            }
            catch (AbstractMyHttpException myHttpException)
            {
                _jsonResult.Value = myHttpException.Message;
                _jsonResult.StatusCode = myHttpException.Code;
            }
            catch (Exception)
            {
                _jsonResult.Value = "Severe internal server error";
                _jsonResult.StatusCode = 500;
            }
            return this;
        }
        
        public IActionResult Build()
        {
            return _jsonResult;
        }
    }
}