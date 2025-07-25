using CredigestorAPI.BLL.Interfaces;
using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.Models;

namespace CredigestorAPI.BLL
{
    public class Tipo_estado_civilBLL : ITipo_estado_civilBLL
    {
        private readonly ITipo_estado_civilDAL _tipoEstadoCivilDAL;
        public Tipo_estado_civilBLL(ITipo_estado_civilDAL tipoEstadoCivilDAL)
        {
            _tipoEstadoCivilDAL = tipoEstadoCivilDAL;
        }
        //Obtiene el catalogo de tipo de sexo
        public async Task<List<Tipo_estado_civil>> ObtenerCatalogoActivo()
        {
            return await _tipoEstadoCivilDAL.ObtenerCatalogoActivo();            
        }
    }
}
