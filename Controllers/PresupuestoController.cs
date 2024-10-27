using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PresupuestoController : ControllerBase
{
    private readonly PresupuestoRepository _presupuestoRepository;
    private readonly ProductoRepository _productoRepository;

    public PresupuestoController()
    {
        _presupuestoRepository = new PresupuestoRepository(@"Data Source=db\Tienda.db;Cache=Shared");
        _productoRepository = new ProductoRepository(@"Data Source=db\Tienda.db;Cache=Shared");
    }

    [HttpGet]
    public ActionResult GetPresupuestos()
    {
        List<Presupuesto> presupuestos = _presupuestoRepository.GetAll();
        return Ok(presupuestos);
    }

    [HttpGet("{id}")]
    public ActionResult GetPresupuesto(int id)
    {
        Presupuesto presupuesto = _presupuestoRepository.GetById(id);
        if (presupuesto == null) NotFound($"No fue encontrado el presupuesto {id}.");
        return Ok(presupuesto);
    }

    [HttpPost]
    public ActionResult CreatePresupuesto([FromBody] Presupuesto presupuesto)
    {
        if (presupuesto.NombreDestinario == "")
        {
            return BadRequest("No se paso el nombre del destinario.");
        }
        _presupuestoRepository.Create(presupuesto);
        return CreatedAtAction(nameof(GetPresupuesto), new { id = presupuesto.IdPresupuesto }, presupuesto);
    }

    [HttpPut("{id}/ProductoDetalle")]
    public ActionResult AddProduct(int id, [FromForm] int idP, [FromForm] int cantidad)
    {
        Producto producto = _productoRepository.GetById(idP);
        if (producto == null)
        {
            return NotFound($"Producto {idP} no encontrado.");
        }

        _presupuestoRepository.Update(id, producto, cantidad);
        return Ok(_presupuestoRepository.GetById(id));
    }


}