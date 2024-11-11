using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiPuenteDeComunicacion.Data;

[ApiController]
[Route("api/[controller]")]
public class NivelController : ControllerBase
{
    private readonly DataContext _context;

    public NivelController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var niveles = await _context.Niveles.ToListAsync();
        return Ok(niveles);
    }
}