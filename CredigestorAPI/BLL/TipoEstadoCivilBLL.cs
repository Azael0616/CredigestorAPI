using CredigestorAPI.BLL.Interfaces;
using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.Models;

namespace CredigestorAPI.BLL
{
    public class TipoEstadoCivilBLL : ITipoEstadoCivilBLL
    {
        private readonly ITipoEstadoCivilDAL _tipoEstadoCivilDAL;
        public TipoEstadoCivilBLL(ITipoEstadoCivilDAL tipoEstadoCivilDAL)
        {
            _tipoEstadoCivilDAL = tipoEstadoCivilDAL;
        }
        //Obtiene el catalogo de tipo de sexo
        public async Task<List<Tipo_estado_civil>> ObtenerCatalogoActivo()
        {
            List<Tipo_estado_civil> _lista = await _tipoEstadoCivilDAL.ObtenerCatalogoActivo();
            return _lista;
        }
    }
}
