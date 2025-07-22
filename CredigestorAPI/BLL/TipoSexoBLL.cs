using CredigestorAPI.BLL.Interfaces;
using CredigestorAPI.DAL;
using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.Models;
using CredigestorAPI.Models.Utils;

namespace CredigestorAPI.BLL
{
    public class TipoSexoBLL : ITipoSexoBLL
    {
        private readonly ITipoSexoDAL _tipoSexoDAL;
        public TipoSexoBLL(ITipoSexoDAL tipoSexoDAL)
        {
            _tipoSexoDAL = tipoSexoDAL;
        }
        //Obtiene el catalogo de tipo de sexo
        public async Task<List<Tipo_sexo>> ObtenerCatalogoActivo()
        {
            List<Tipo_sexo> _lista = await _tipoSexoDAL.ObtenerCatalogoActivo();
            return _lista;
        }
    }
}
