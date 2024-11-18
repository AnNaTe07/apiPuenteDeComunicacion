using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using ApiPuenteDeComunicacion.Models;
using System.Text;
//using Microsoft.Extensions.Configuration;//para acceder a la configuración

namespace ApiPuenteDeComunicacion.utils
{
    public class TokenUtils
    {
        private readonly IConfiguration _configuration;

        //contructor que recibe la configuracion
        public TokenUtils(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateJwtToken(Usuario usuario)
        {
            //accedo a los valores de configuracion
            var key = _configuration.GetValue<string>("Jwt:Key");
            var issuer = _configuration.GetValue<string>("Jwt:Issuer");
            var audience = _configuration.GetValue<string>("Jwt:Audience");

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.Rol.Nombre),
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim("FullName", usuario.Nombre + " " + usuario.Apellido),
            };

            var keyBytes = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var creds = new SigningCredentials(keyBytes, SecurityAlgorithms.HmacSha256);

            var expirationTime = DateTime.Now.AddMinutes(30);
            //var expirationTime = DateTime.Now.AddDays(15);
            //creo el token
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expirationTime,
                signingCredentials: creds
            );
            //retorno el token como una cadena
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}