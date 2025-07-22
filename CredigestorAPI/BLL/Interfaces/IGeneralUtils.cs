namespace CredigestorAPI.BLL.Interfaces
{
    public interface IGeneralUtils
    {
        int CalcularEdad(DateTime fechaNacimiento);
        bool ValidarCorreo(string correo);
    }
}
