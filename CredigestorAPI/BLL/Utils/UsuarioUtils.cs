using CredigestorAPI.BLL.Interfaces;
using CredigestorAPI.Models;
using Microsoft.AspNetCore.Identity;
using System.Text.RegularExpressions;

namespace CredigestorAPI.BLL.Utils
{
    public class UsuarioUtils : IUsuarioUtils
    {
        private readonly PasswordHasher<Usuario> _hasher = new();

        public string HashPassword(Usuario _usuario, string password)
        {
            return _hasher.HashPassword(_usuario, password);
        }

        public bool ValidarPasswordLogin(Usuario _usuario,string password, string hashedPassword)
        {
            var result = _hasher.VerifyHashedPassword(_usuario, hashedPassword, password);
            return result == PasswordVerificationResult.Success;
        }
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
    }
}
