using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.DAL.Mappers;
using CredigestorAPI.Models;
using System.Data;

namespace CredigestorAPI.DAL
{
    public class Tipo_estado_civilDAL : ITipo_estado_civilDAL
    {
        private readonly ISqlAuxiliar _sqlAuxiliar;
        public Tipo_estado_civilDAL(ISqlAuxiliar sqlAuxiliar)
        {
            _sqlAuxiliar = sqlAuxiliar;
        }
        //Obtiene el catalogo de tipo de estado civil
        public async Task<List<Tipo_estado_civil>> ObtenerCatalogoActivo()
        {
            List<Tipo_estado_civil> _lista = new List<Tipo_estado_civil>();
            DataTable dt = await _sqlAuxiliar.EjecutarTablaPA("Sp_TipoEstadoCivil_O_CatalogoActivo", null);
            if (dt == null)
                return _lista;
            else
            {
                _lista = Tipo_estado_civilMapper.ObtenerListaDataTable(dt);
                return _lista;
            }
        }
    }
}
