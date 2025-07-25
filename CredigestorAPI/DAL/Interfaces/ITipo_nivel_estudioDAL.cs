using CredigestorAPI.Models;

namespace CredigestorAPI.DAL.Interfaces
{
    public interface ITipo_nivel_estudioDAL
    {
        Task<List<Tipo_nivel_estudio>> ObtenerCatalogoActivo();
    }
}
