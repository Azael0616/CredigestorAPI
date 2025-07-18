using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.Models;
using System.Data;

namespace CredigestorAPI.DAL
{
    public class TipoEstadoCivilDAL : ITipoEstadoCivilDAL
    {
        private readonly ISqlAuxiliar _sqlAuxiliar;
        public TipoEstadoCivilDAL(ISqlAuxiliar sqlAuxiliar)
        {
            _sqlAuxiliar = sqlAuxiliar;
        }
        //Obtiene el catalogo de tipo de estado civil
        public async Task<List<Tipo_estado_civil>> ObtenerCatalogoActivo()
        {
            List<Tipo_estado_civil> _lista = new List<Tipo_estado_civil>();
            DataTable dt = await _sqlAuxiliar.EjecutarTablaPA("Sp_TipoEstadoCivil_O_Catalogo", null);
            if (dt == null)
                return _lista;
            else
            {
                _lista = Tipo_estado_civil.ObtenerListaDesdeTabla(dt);
                return _lista;
            }
        }
    }
}
