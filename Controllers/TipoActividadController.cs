using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiPuenteDeComunicacion.Data;
using System.Runtime.CompilerServices;

[ApiController]
[Route("api/[controller]")]

public class TipoActividadController : ControllerBase
{
    private readonly DataContext _context;

    public TipoActividadController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var tipos = await _context.TiposActividades.ToListAsync();
        return Ok(tipos);
    }
}