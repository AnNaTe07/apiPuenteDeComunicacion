using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiPuenteDeComunicacion.Data;

[ApiController]
[Route("api/[controller]")]
public class EstadoAsistenciaController : ControllerBase
{
    private readonly DataContext _context;

    public EstadoAsistenciaController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var estados = await _context.EstadosAsistencias.ToListAsync();
        return Ok(estados);
    }
}