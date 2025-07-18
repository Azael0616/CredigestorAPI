using CredigestorAPI.Models;

namespace CredigestorAPI.DAL.Interfaces
{
    public interface ITipoEstadoCivilDAL
    {
        Task<List<Tipo_estado_civil>> ObtenerCatalogoActivo();
    }
}
