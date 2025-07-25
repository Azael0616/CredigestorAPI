using CredigestorAPI.DAL.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CredigestorAPI.DAL.Utils
{
    public class SqlAuxiliar : ISqlAuxiliar
    {
        private readonly string? _cadena_de_conexion;
        public SqlAuxiliar(string? cadena_de_conexion)
        {
            _cadena_de_conexion = cadena_de_conexion;
        }
        //Obtiene toda la tabla
        public async Task<DataTable> EjecutarTablaPA(string procedimientoAlmacenado, Dictionary<string, object>? parametros = null)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(_cadena_de_conexion))
            {
                using (SqlCommand cmd = new SqlCommand(procedimientoAlmacenado, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (parametros != null)
                    {
                        foreach (var param in parametros)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    await conn.OpenAsync();

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        dt.Load(reader);
                    }
                }
            }

            return dt;
        }
        //Obtiene varias tablas (Dataset)
        public async Task<DataSet> EjecutarMultiplesTablasPA(string procedimientoAlmacenado, Dictionary<string, object>? parametros = null)
        {
            DataSet ds = new DataSet();

            using (SqlConnection conn = new SqlConnection(_cadena_de_conexion))
            {
                using (SqlCommand cmd = new SqlCommand(procedimientoAlmacenado, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (parametros != null)
                    {
                        foreach (var param in parametros)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        await Task.Run(() => adapter.Fill(ds)); // Task.Run para mantener asincronía
                    }
                }
            }

            return ds;
        }
        //Obtiene la primer fila
#nullable disable
        public async Task<DataRow> EjecutarPrimeraFilaPA(string nombreProcedimiento, Dictionary<string, object> parametros)
        {
            DataTable dt = await EjecutarTablaPA(nombreProcedimiento, parametros);

            if (dt.Rows.Count == 0)
                return null;

            return dt.Rows[0];
        }
#nullable enable
    }
}
