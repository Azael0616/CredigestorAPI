using CredigestorAPI.BLL.Interfaces;
using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.Models;

namespace CredigestorAPI.BLL
{
    public class Tipo_nivel_estudioBLL : ITipo_nivel_estudioBLL
    {
        private readonly ITipo_nivel_estudioDAL _tipoNivelEstudioDAL;
        public Tipo_nivel_estudioBLL(ITipo_nivel_estudioDAL tipoNivelEstudioDAL)
        {
            _tipoNivelEstudioDAL = tipoNivelEstudioDAL;
        }
        public async Task<List<Tipo_nivel_estudio>> ObtenerCatalogoActivo()
        {
            return await _tipoNivelEstudioDAL.ObtenerCatalogoActivo();
        }
    }
}
