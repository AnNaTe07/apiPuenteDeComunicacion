using ApiPuenteDeComunicacion.Data;
using ApiPuenteDeComunicacion.Models;
using ApiPuenteDeComunicacion.utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using System.Linq.Expressions;

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

        // Si el usuario no está registrado
        if (usuario == null)
        {
            return Unauthorized("Credenciales inválidas.");
        }

        // Si el pass es incorrecto
        if (!PasswordUtils.VerifyPassword(login.Password, usuario.Password, usuario.Salt))
        {
            return Unauthorized("Credenciales inválidas.");
        }

        // genero el token JWT
        var token = _tokenUtils.GenerateJwtToken(usuario);

        // decodifico el token para obtener los claims
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token); // decodifico el JWT

        // cast explícito a JwtSecurityToken para acceder a los claims
        if (jwtToken is JwtSecurityToken tokenClaims)
        {
            //extraigo valores de los claims
            var role = tokenClaims?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            var fullName = tokenClaims?.Claims.FirstOrDefault(c => c.Type == "FullName")?.Value;
            var email = tokenClaims?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var id = tokenClaims?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var expirationTime = jwtToken?.ValidTo;
            // Convertir expirationTime (DateTime) a un string con el formato correcto
            var expirationTimeString = expirationTime?.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'", CultureInfo.InvariantCulture);


            // retorno el JSON con todos los datos
            return Ok(new
            {
                Token = token,
                Expiracion = expirationTimeString,
                Rol = role,
                FullName = fullName,
                Email = email,
                Id = id
            });
        }

        return Unauthorized("Token no válido.");
    }

    [HttpGet("profile")]
    [Authorize]
    public async Task<IActionResult> Profile()
    {
        try
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var user = await _context.Usuarios.Include(u => u.Rol).SingleOrDefaultAsync(e => e.Email == email);

            if (user == null)
            {
                return NotFound("No se encontró el perfil de usuario.");
            }

            return Ok(user);
        }
        catch (Exception e)
        {
            return StatusCode(500, "Error al obtener los datos del perfil.");
        }
    }



}