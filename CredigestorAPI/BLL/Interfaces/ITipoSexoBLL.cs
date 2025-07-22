using CredigestorAPI.Models;

namespace CredigestorAPI.BLL.Interfaces
{
    public interface ITipoSexoBLL
    {
        Task<List<Tipo_sexo>> ObtenerCatalogoActivo();
    }
}
