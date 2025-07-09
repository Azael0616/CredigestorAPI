using CredigestorAPI.BLL.Interfaces;
using CredigestorAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

namespace CredigestorAPI.BLL.Utils
{
    public class UsuarioUtils : IUsuarioUtils
    {
        private readonly PasswordHasher<object> _hasher = new();
#nullable disable
        public string HashPassword(string password)
        {
            return _hasher.HashPassword(null, password);
        }

        public bool ValidarPasswordLogin(string password, string hashedPassword)
        {
            var result = _hasher.VerifyHashedPassword(null, hashedPassword, password);
            return result == PasswordVerificationResult.Success;
        }
#nullable enable
        public bool ValidarPasswordSegura(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            if (password.Length < 8 || password.Length > 12)
                return false;

            bool tieneMayuscula = false;
            bool tieneMinuscula = false;
            bool tieneNumero = false;
            bool tieneEspecial = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                    tieneMayuscula = true;
                else if (char.IsLower(c))
                    tieneMinuscula = true;
                else if (char.IsDigit(c))
                    tieneNumero = true;
                else if ("!@#$%^&*()_-+=[]{}|\\;:'\",.<>?/`~".Contains(c))
                    tieneEspecial = true;
            }

            return tieneMayuscula && tieneMinuscula && tieneNumero && tieneEspecial;
        }
        //Retorna la edad
        public int CalcularEdad(DateTime fechaNacimiento)
        {
            var hoy = DateTime.Today;
            int edad = hoy.Year - fechaNacimiento.Year;
            if (fechaNacimiento > hoy.AddYears(-edad)) edad--;
            return edad;
        }
        //Valida si la fecha de ingreso no es mayor a 50 años atrás y no es mayor a 1 mes hacia adelante
        public bool ValidarFechaIngreso(DateTime fechaIngreso)
        {
            DateTime hoy = DateTime.Today;

            DateTime limiteMinimo = hoy.AddYears(-50);
            DateTime limiteMaximo = hoy.AddMonths(1);

            return fechaIngreso >= limiteMinimo && fechaIngreso <= limiteMaximo;
        }
        //Valida el correo
        public bool ValidarCorreo(string correo)
        {
            if (string.IsNullOrWhiteSpace(correo))
                return false;

            // Expresión regular para formato básico de email
            string patron = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            return Regex.IsMatch(correo, patron, RegexOptions.IgnoreCase);
        }
        //Genera un token JWT
        public string GenerarToken(string usuario,IConfiguration _config)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, usuario)
        };
#nullable disable
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(2);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );
#nullable enable
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
