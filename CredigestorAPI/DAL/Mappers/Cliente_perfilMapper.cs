using CredigestorAPI.Models;
using System.Data;

namespace CredigestorAPI.DAL.Mappers
{
    public static class Cliente_perfilMapper
    {
        //Este metodo retornará un objeto creado a partir de un DataRow
        public static Cliente_perfil ObtenerObjetoDataRow(DataRow dt)
        {
#nullable disable
            return new Cliente_perfil
            {
                ClienteID = (dt.Table.Columns.Contains("ClienteID") && dt["ClienteID"] != DBNull.Value) ? int.Parse(dt["ClienteID"].ToString()) : 0,
                Nivel_estudio = (dt.Table.Columns.Contains("Nivel_estudio") && dt["Nivel_estudio"] != DBNull.Value) ? int.Parse(dt["Nivel_estudio"].ToString()) : 0,
                Area_estudio = (dt.Table.Columns.Contains("Area_estudio") && dt["Area_estudio"] != DBNull.Value) ? int.Parse(dt["Area_estudio"].ToString()) : 0,
                Carrera_estudio = (dt.Table.Columns.Contains("Carrera_estudio") && dt["Carrera_estudio"] != DBNull.Value) ? dt["Carrera_estudio"].ToString() : "",
                Area_ocupacion = (dt.Table.Columns.Contains("Area_ocupacion") && dt["Area_ocupacion"] != DBNull.Value) ? int.Parse(dt["Area_ocupacion"].ToString()) : 0,
                Puesto = (dt.Table.Columns.Contains("Puesto") && dt["Puesto"] != DBNull.Value) ? dt["Puesto"].ToString() : "",
                Empresa = (dt.Table.Columns.Contains("Empresa") && dt["Empresa"] != DBNull.Value) ? dt["Empresa"].ToString() : "",
                Tiempo_empresa = (dt.Table.Columns.Contains("Tiempo_empresa") && dt["Tiempo_empresa"] != DBNull.Value) ? int.Parse(dt["Tiempo_empresa"].ToString()) : 0,
                Ingreso_mensual = (dt.Table.Columns.Contains("Ingreso_mensual") && dt["Ingreso_mensual"] != DBNull.Value) ? decimal.Parse(dt["Ingreso_mensual"].ToString()) : 0,
                Gasto_mensual = (dt.Table.Columns.Contains("Gasto_mensual") && dt["Gasto_mensual"] != DBNull.Value) ? decimal.Parse(dt["Gasto_mensual"].ToString()) : 0,
            };            
#nullable restore
        }
        //Este metodo retornará una lista de objetos creada a partir de un DataTable
        public static List<Cliente_perfil> ObtenerListaDesdeTabla(DataTable dt)
        {
            List<Cliente_perfil> _lista = new List<Cliente_perfil>();
            if (dt != null && dt?.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cliente_perfil _cliente = ObtenerObjetoDataRow(dr);
                    _lista.Add(_cliente);
                }
            }
            return _lista;
        }
    }
}
