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
        public DataTable EjecutarTablaPA(string procedimientoAlmacenado, Dictionary<string, object>? parametros = null)
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

                    conn.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }
        //Obtiene la primer fila
#nullable disable
        public DataRow EjecutarPrimeraFilaPA(string nombreProcedimiento, Dictionary<string, object> parametros)
        {
            DataTable dt = EjecutarTablaPA(nombreProcedimiento, parametros);

            if (dt.Rows.Count == 0)
                return null;

            return dt.Rows[0];
        }
#nullable enable
    }
}
