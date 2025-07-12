using CredigestorAPI.Models;

namespace CredigestorAPI.BLL.Interfaces
{
    public interface INivel_usuarioBLL
    {
        Task<List<Nivel_usuario>> ObtenerCatalogoActivo(int usuarioID);
    }
}
