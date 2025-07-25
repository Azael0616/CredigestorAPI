using CredigestorAPI.Models;

namespace CredigestorAPI.DAL.Interfaces
{
    public interface ITipo_area_perfilDAL
    {
        Task<List<Tipo_area_perfil>> ObtenerCatalogoActivoEstudio();
        Task<List<Tipo_area_perfil>> ObtenerCatalogoActivoOcupacion();
    }
}
