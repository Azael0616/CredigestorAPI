using System.Data;

namespace CredigestorAPI.DAL.Interfaces
{
    public interface ISqlAuxiliar
    {
        Task<DataTable> EjecutarTablaPA(string procedimientoAlmacenado, Dictionary<string, object>? parametros = null);
        Task<DataSet> EjecutarMultiplesTablasPA(string procedimientoAlmacenado, Dictionary<string, object>? parametros = null);
        Task<DataRow> EjecutarPrimeraFilaPA(string procedimientoAlmacenado, Dictionary<string, object>? parametros = null);
    }
}
