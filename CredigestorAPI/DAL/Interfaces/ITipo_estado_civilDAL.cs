using CredigestorAPI.Models;

namespace CredigestorAPI.DAL.Interfaces
{
    public interface ITipo_estado_civilDAL
    {
        Task<List<Tipo_estado_civil>> ObtenerCatalogoActivo();
    }
}
