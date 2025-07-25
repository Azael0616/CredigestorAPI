using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.DAL.Mappers;
using CredigestorAPI.Models;
using System.Data;

namespace CredigestorAPI.DAL
{
    public class EstadoDAL : IEstadoDAL
    {
        private readonly ISqlAuxiliar _sqlAuxiliar;
        public EstadoDAL(ISqlAuxiliar sqlAuxiliar)
        {
            _sqlAuxiliar = sqlAuxiliar;
        }
        //Obtiene todos los estados activos
        public async Task<List<Estado>> ObtenerCatalogoActivo(int paisID)
        {
            List<Estado> _lista = new List<Estado>();
            var parameters = new Dictionary<string, object>
            {
                { "@PaisID", paisID },
            };
            DataTable dt = await _sqlAuxiliar.EjecutarTablaPA("Sp_Estado_O_CatalogoActivo", parameters);
            if (dt == null)
                return _lista;
            else
            {
                _lista = EstadoMapper.ObtenerListaDataTable(dt);
                return _lista;
            }
        }
    }
}
