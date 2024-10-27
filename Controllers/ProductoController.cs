using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductoController : ControllerBase
{
    private readonly ProductoRepository _productoRepository;

    public ProductoController()
    {
        _productoRepository = new ProductoRepository(@"Data Source=db\Tienda.db;Cache=Shared");
    }

    [HttpGet]
    public ActionResult GetProductos()
    {
        List<Producto> productos = _productoRepository.GetAll();
        return Ok(productos);
    }

    [HttpPost]
    public ActionResult CreateProduct([FromBody] Producto producto)
    {
        if (string.IsNullOrEmpty(producto.Descripcion) || producto.Precio <= 0)
        {
            return BadRequest("Producto inválido. Verifica que la descripción no esté vacía y el precio sea mayor a 0.");
        }

        _productoRepository.Create(producto);
        return CreatedAtAction(nameof(GetProductoById), new { id = producto.IdProducto }, producto);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateProduct(int id, [FromBody] Producto producto)
    {
        _productoRepository.Update(id, producto);
        return Ok(_productoRepository.GetById(id));
    }

    [HttpGet("{id}")]
    public IActionResult GetProductoById(int id)
    {
        var producto = _productoRepository.GetById(id);
        if (producto == null)
        {
            return NotFound();
        }
        return Ok(producto);
    }
}