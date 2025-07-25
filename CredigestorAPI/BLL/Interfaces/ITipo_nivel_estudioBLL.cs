using CredigestorAPI.Models;

namespace CredigestorAPI.BLL.Interfaces
{
    public interface ITipo_nivel_estudioBLL
    {
        Task<List<Tipo_nivel_estudio>> ObtenerCatalogoActivo();
    }
}
