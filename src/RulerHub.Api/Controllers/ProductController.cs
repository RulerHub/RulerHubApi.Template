using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using RulerHub.Api.Application.DTOs.Products;
using RulerHub.Api.Application.Interfaces.Services;
using RulerHub.Api.Domain.Interfaces;

namespace RulerHub.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;
    private readonly IUnitOfWork _unit;

    public ProductController(IProductService service, IUnitOfWork unit)
    {
        _service = service;
        _unit = unit;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Get([FromQuery] ProductQueryParams query)
    {
        var (items, total) = await _service.GetFilteredAsync(query);
        return Ok(new { items, total });
    }
}
