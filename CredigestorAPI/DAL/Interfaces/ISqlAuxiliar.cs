using System.Data;

namespace CredigestorAPI.DAL.Interfaces
{
    public interface ISqlAuxiliar
    {
        public DataTable EjecutarTablaPA(string procedimientoAlmacenado, Dictionary<string, object>? parametros = null);
        public DataRow EjecutarPrimeraFilaPA(string procedimientoAlmacenado, Dictionary<string, object>? parametros = null);
    }
}
