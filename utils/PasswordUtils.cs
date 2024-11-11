using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace ApiPuenteDeComunicacion.utils
{
    public static class PasswordUtils
    {
        // Hashea el pass usando un sal generado, recibe una contraseña y devuelve una tupla que contiene el pass hasheado y el sal usado
        public static (string hashedPassword, string salt) HashPassword(string password)
        {
            // Generar una sal aleatoria de 16 bytes
            var saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);//generador de numeros aleatorios para llenar el arreglo de bytes
            }
            var salt = Convert.ToBase64String(saltBytes);//convierte la sal a cadena Base64 para almacenarla

            //hashea el pass con la sal
            var hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000, //n° de iteraciones para hacer el hashing mas lento y seguro
                numBytesRequested: 32));
            return (hashedPassword, salt);
        }

        //para verificar el pass y su hash
        public static bool VerifyPassword(string pass, string hashedPass, string salt)
        {
            var saltBytes = Convert.FromBase64String(salt);
            var hashToVerify = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: pass,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 32));
            return hashToVerify == hashedPass;

        }
    }
}