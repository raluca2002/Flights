using lab_rest.api.view_models;
using Microsoft.AspNetCore.Mvc;

namespace lab_rest.api._interfaces.view_models
{
    public interface IJsonResultBuilder
    {
        IJsonResultBuilder Initialize(Func<object?> getContent);
        IActionResult Build();
    }
}