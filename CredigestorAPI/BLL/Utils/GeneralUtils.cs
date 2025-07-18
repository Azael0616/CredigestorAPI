using CredigestorAPI.BLL.Interfaces;
using System.Text.RegularExpressions;

namespace CredigestorAPI.BLL.Utils
{
    public class GeneralUtils : IGeneralUtils
    {
        //Retorna la edad
        public int CalcularEdad(DateTime fechaNacimiento)
        {
            var hoy = DateTime.Today;
            int edad = hoy.Year - fechaNacimiento.Year;
            if (fechaNacimiento > hoy.AddYears(-edad)) edad--;
            return edad;
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
