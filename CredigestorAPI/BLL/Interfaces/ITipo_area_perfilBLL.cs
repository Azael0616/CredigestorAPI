using CredigestorAPI.Models;

namespace CredigestorAPI.BLL.Interfaces
{
    public interface ITipo_area_perfilBLL
    {
        Task<List<Tipo_area_perfil>> ObtenerCatalogoActivoEstudio();
        Task<List<Tipo_area_perfil>> ObtenerCatalogoActivoOcupacion();
    }
}
