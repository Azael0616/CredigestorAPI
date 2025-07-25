using CredigestorAPI.Models;

namespace CredigestorAPI.DAL.Interfaces
{
    public interface ITipo_sexoDAL
    {
        Task<List<Tipo_sexo>> ObtenerCatalogoActivo();
    }
}
