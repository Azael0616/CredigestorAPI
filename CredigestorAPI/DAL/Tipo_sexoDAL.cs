using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.DAL.Mappers;
using CredigestorAPI.Models;
using System.Data;

namespace CredigestorAPI.DAL
{
    public class Tipo_sexoDAL : ITipo_sexoDAL
    {
        private readonly ISqlAuxiliar _sqlAuxiliar;
        public Tipo_sexoDAL(ISqlAuxiliar sqlAuxiliar)
        {
            _sqlAuxiliar = sqlAuxiliar;
        }
        //Obtiene el catalogo de tipo de sexo
        public async Task<List<Tipo_sexo>> ObtenerCatalogoActivo()
        {
            List<Tipo_sexo> _lista = new List<Tipo_sexo>();
            DataTable dt = await _sqlAuxiliar.EjecutarTablaPA("Sp_TipoSexo_O_CatalogoActivo", null);
            if (dt == null)
                return _lista;
            else
            {
                _lista = Tipo_sexoMapper.ObtenerListaDataTable(dt);
                return _lista;
            }
        }
    }
}
