using Microsoft.AspNetCore.Mvc;

using RulerHub.Api.Application.DTOs.Products;
using RulerHub.Api.Application.Interfaces.Services;

namespace RulerHub.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _service;
    public ProductController(IProductService service)
    {
        _service = service;
    }

    /// <summary>
    /// Obtiene una lista de productos con filtrado, ordenado y paginado.
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Get([FromQuery] ProductQueryParams query)
    {
        var (items, count) = await _service.GetFilteredAsync(query);
        return Ok(new { items, count });
    }

    /// <summary>
    /// Obtiene una lista de productos con filtrado, ordenado y paginado.
    /// </summary>
    [HttpGet]
    [Route("/gets")]
    [Obsolete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Get(/*[FromQuery] ProductQueryParams query*/)
    {
        var items = await _service.GetAllAsync();
        return Ok(new { items });
    }

    /// <summary>
    /// Obtiene un producto por su Id.
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductDto>> GetById(Guid id)
    {
        var product = await _service.GetByIdAsync(id);
        return product is null ? NotFound() : Ok(product);
    }

    /// <summary>
    /// Crea un nuevo producto.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<ProductDto>> Create([FromBody] ProductCreateDto dto)
    {
        var created = await _service.CreateAsync(dto);
        return Ok(created);
    }

    /// <summary>
    /// Actualiza un producto existente.
    /// </summary>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] ProductCreateDto dto)
    {
        await _service.UpdateAsync(id, dto);
        var result = await _service.GetByIdAsync(id);
        return Ok(result);
    }

    /// <summary>
    /// Elimina un producto por Id.
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}

