using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.DAL.Mappers;
using CredigestorAPI.Models;
using System.Data;

namespace CredigestorAPI.DAL
{
    public class Tipo_nivel_estudioDAL : ITipo_nivel_estudioDAL
    {
        private readonly ISqlAuxiliar _sqlAuxiliar;
        public Tipo_nivel_estudioDAL(ISqlAuxiliar sqlAuxiliar)
        {
            _sqlAuxiliar = sqlAuxiliar;
        }
        //Obtiene todos los niveles de estudio activo
        public async Task<List<Tipo_nivel_estudio>> ObtenerCatalogoActivo()
        {
            List<Tipo_nivel_estudio> _lista = new List<Tipo_nivel_estudio>();
            DataTable dt = await _sqlAuxiliar.EjecutarTablaPA("Sp_TipoNivelEstudio_O_CatalogoActivo", null);
            if (dt == null)
                return _lista;
            else
            {
                _lista = Tipo_nivel_estudioMapper.ObtenerListaDataTable(dt);
                return _lista;
            }
        }
    }
}
