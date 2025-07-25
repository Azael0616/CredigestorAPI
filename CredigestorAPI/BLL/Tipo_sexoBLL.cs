using CredigestorAPI.BLL.Interfaces;
using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.Models;

namespace CredigestorAPI.BLL
{
    public class Tipo_sexoBLL : ITipo_sexoBLL
    {
        private readonly ITipo_sexoDAL _tipoSexoDAL;
        public Tipo_sexoBLL(ITipo_sexoDAL tipoSexoDAL)
        {
            _tipoSexoDAL = tipoSexoDAL;
        }
        //Obtiene el catalogo de tipo de sexo
        public async Task<List<Tipo_sexo>> ObtenerCatalogoActivo()
        {
            return await _tipoSexoDAL.ObtenerCatalogoActivo();            
        }
    }
}
