using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.DAL.Mappers;
using CredigestorAPI.Models;
using System.Data;

namespace CredigestorAPI.DAL
{
    public class MunicipioDAL : IMunicipioDAL
    {
        private readonly ISqlAuxiliar _sqlAuxiliar;
        public MunicipioDAL(ISqlAuxiliar sqlAuxiliar)
        {
            _sqlAuxiliar = sqlAuxiliar;
        }
        //Obtiene todos los municipios activos
        public async Task<List<Municipio>> ObtenerCatalogoActivo(int estadoID)
        {
            List<Municipio> _lista = new List<Municipio>();
            var parameters = new Dictionary<string, object>
            {
                { "@EstadoID", estadoID },
            };
            DataTable dt = await _sqlAuxiliar.EjecutarTablaPA("Sp_Municipio_O_CatalogoActivo", parameters);
            if (dt == null)
                return _lista;
            else
            {
                _lista = MunicipioMapper.ObtenerListaDataTable(dt);
                return _lista;
            }
        }
    }
}
