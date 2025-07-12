using CredigestorAPI.Models;

namespace CredigestorAPI.DAL.Interfaces
{
    public interface INivel_usuarioDAL
    {
        Task<List<Nivel_usuario>> ObtenerCatalogoActivo(int usuarioID);
    }
}
