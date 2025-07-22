using CredigestorAPI.Models;

namespace CredigestorAPI.DAL.Interfaces
{
    public interface ITipoSexoDAL
    {
        Task<List<Tipo_sexo>> ObtenerCatalogoActivo();
    }
}
