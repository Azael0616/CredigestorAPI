using CredigestorAPI.Models;

namespace CredigestorAPI.DAL.Interfaces
{
    public interface IMenu_webDAL
    {
        Task<List<Menu_web>> ObtenerMenuWebPorUsuario(int usuarioID);
    }
}
