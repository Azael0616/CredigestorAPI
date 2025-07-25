using CredigestorAPI.BLL.Interfaces;
using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.Models;

namespace CredigestorAPI.BLL
{
    public class Tipo_area_perfilBLL : ITipo_area_perfilBLL
    {
        private readonly ITipo_area_perfilDAL _tipoAreaPerfilDAL;
        public Tipo_area_perfilBLL(ITipo_area_perfilDAL tipoAreaPerfilDAL)
        {
            _tipoAreaPerfilDAL = tipoAreaPerfilDAL;
        }
        //Obtiene todos los tipo de area de perfil para estudio activos
        public async Task<List<Tipo_area_perfil>> ObtenerCatalogoActivoEstudio()
        {
            return await _tipoAreaPerfilDAL.ObtenerCatalogoActivoEstudio();
        }
        //Obtiene todos los tipo de area de perfil para ocupacion activos
        public async Task<List<Tipo_area_perfil>> ObtenerCatalogoActivoOcupacion()
        {
            return await _tipoAreaPerfilDAL.ObtenerCatalogoActivoOcupacion();   
        }
    }
}
