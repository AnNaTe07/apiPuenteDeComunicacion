using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiPuenteDeComunicacion.Data;

[ApiController]
[Route("api/[controller]")]
public class RolController : ControllerBase
{
    private readonly DataContext _context;

    public RolController(DataContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var roles = await _context.Roles.ToListAsync();

        // Imprime los roles en la consola para verificar que se están recuperando correctamente
        Console.WriteLine("Roles encontrados: ");
        foreach (var rol in roles)
        {
            Console.WriteLine($"ID: {rol.Id}, Nombre: {rol.Nombre}");
        }
        return Ok(roles);
    }
}