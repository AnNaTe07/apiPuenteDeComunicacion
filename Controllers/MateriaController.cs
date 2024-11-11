using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiPuenteDeComunicacion.Data;

[ApiController]
[Route("api/[controller]")]
public class MateriaController : ControllerBase
{
    private readonly DataContext _context;
    public MateriaController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var materias = await _context.Materias.ToListAsync();
        return Ok(materias);
    }
}