using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.DAL.Mappers;
using CredigestorAPI.Models;
using System.Data;

namespace CredigestorAPI.DAL
{
    public class PaisDAL : IPaisDAL
    {
        private readonly ISqlAuxiliar _sqlAuxiliar;
        public PaisDAL(ISqlAuxiliar sqlAuxiliar)
        {
            _sqlAuxiliar = sqlAuxiliar;
        }
        //Obtiene todos los paises activos
        public async Task<List<Pais>> ObtenerCatalogoActivo()
        {
            List<Pais> _lista = new List<Pais>();
            DataTable dt = await _sqlAuxiliar.EjecutarTablaPA("Sp_Pais_O_CatalogoActivo", null);
            if (dt == null)
                return _lista;
            else
            {
                _lista = PaisMapper.ObtenerListaDataTable(dt);
                return _lista;
            }
        }
    }
}
