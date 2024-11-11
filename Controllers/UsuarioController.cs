using ApiPuenteDeComunicacion.Data;
using ApiPuenteDeComunicacion.Models;
using ApiPuenteDeComunicacion.utils;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly DataContext _context;
    private readonly TokenUtils _tokenUtils;

    public UsuarioController(DataContext context, TokenUtils tokenUtils)
    {
        _context = context;
        _tokenUtils = tokenUtils;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] Usuario usuario)
    {
        if (string.IsNullOrEmpty(usuario.Password))
            return BadRequest("El password es obligatorio.");

        if (_context.Usuarios.Any(u => u.Email == usuario.Email))
            return BadRequest("El email ya está en uso.");

        var hashResult = PasswordUtils.HashPassword(usuario.Password);
        usuario.Password = hashResult.hashedPassword;
        usuario.Salt = hashResult.salt;

        try
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return Ok("Usuario registrado correctamente.");
        }
        catch (Exception e)
        {
            return StatusCode(500, "Error interno del servidor:" + e.Message);
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] Login login)
    {
        var usuario = _context.Usuarios.Include(u => u.Rol).FirstOrDefault(u => u.Email == login.Email);

        //si usuario no está registrado
        if (usuario == null)
        {
            return Unauthorized("Credenciales inválidas.");
        }

        //si el pass es incorrecto
        if (!PasswordUtils.VerifyPassword(login.Password, usuario.Password, usuario.Salt))
        {
            return Unauthorized("Credenciales inválidas.");
        }

        //genero el token jwt usando la clase TokenUtils
        var token = _tokenUtils.GenerateJwtToken(usuario);
        return Ok(token);
    }


}