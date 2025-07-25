using CredigestorAPI.Models;

namespace CredigestorAPI.BLL.Interfaces
{
    public interface ITipo_sexoBLL
    {
        Task<List<Tipo_sexo>> ObtenerCatalogoActivo();
    }
}
