using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.DAL.Mappers;
using CredigestorAPI.Models;
using System.Data;

namespace CredigestorAPI.DAL
{
    public class Tipo_archivoDAL : ITipo_archivoDAL
    {
        private readonly ISqlAuxiliar _sqlAuxiliar;
        public Tipo_archivoDAL(ISqlAuxiliar sqlAuxiliar)
        {
            _sqlAuxiliar = sqlAuxiliar;
        }
        //Obtiene todos los tipo de area de perfil para estudio activos
        public async Task<List<Tipo_archivo>> ObtenerCatalogoActivo()
        {
            List<Tipo_archivo> _lista = new List<Tipo_archivo>();
            DataTable dt = await _sqlAuxiliar.EjecutarTablaPA("Sp_TipoArchivo_O_CatalogoActivo", null);
            if (dt == null)
                return _lista;
            else
            {
                _lista = Tipo_archivoMapper.ObtenerListaDataTable(dt);
                return _lista;
            }
        }
    }
}
