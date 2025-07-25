using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.DAL.Mappers;
using CredigestorAPI.Models;
using System.Data;

namespace CredigestorAPI.DAL
{
    public class Tipo_documentoDAL : ITipo_documentoDAL
    {
        private readonly ISqlAuxiliar _sqlAuxiliar;
        public Tipo_documentoDAL(ISqlAuxiliar sqlAuxiliar)
        {
            _sqlAuxiliar = sqlAuxiliar;
        }
        //Obtiene todos los tipo de documento activo
        public async Task<List<Tipo_documento>> ObtenerCatalogoActivo(int formularioID)
        {
            List<Tipo_documento> _lista = new List<Tipo_documento>();
            var parameters = new Dictionary<string, object>
            {
                { "@TipoFormularioID", formularioID },
            };
            DataTable dt = await _sqlAuxiliar.EjecutarTablaPA("Sp_TipoDocumento_O_PorFormulario", parameters);
            if (dt == null)
                return _lista;
            else
            {
                _lista = Tipo_documentoMapper.ObtenerListaDataTable(dt);
                return _lista;
            }
        }
    }
}
