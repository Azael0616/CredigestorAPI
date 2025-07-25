using CredigestorAPI.Models;

namespace CredigestorAPI.BLL.Interfaces
{
    public interface ITipo_estado_civilBLL
    {
        Task<List<Tipo_estado_civil>> ObtenerCatalogoActivo();
    }
}
