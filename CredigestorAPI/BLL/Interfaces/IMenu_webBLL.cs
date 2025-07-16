using CredigestorAPI.Models;

namespace CredigestorAPI.BLL.Interfaces
{
    public interface IMenu_webBLL
    {
        Task<List<Menu_web>> ObtenerMenuWebPorUsuario(int usuarioID);
    }
}
