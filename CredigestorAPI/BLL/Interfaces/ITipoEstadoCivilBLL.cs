using CredigestorAPI.Models;

namespace CredigestorAPI.BLL.Interfaces
{
    public interface ITipoEstadoCivilBLL
    {
        Task<List<Tipo_estado_civil>> ObtenerCatalogoActivo();
    }
}
