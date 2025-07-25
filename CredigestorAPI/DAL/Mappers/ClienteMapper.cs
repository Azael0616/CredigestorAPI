using CredigestorAPI.Models;
using System.Data;

namespace CredigestorAPI.DAL.Mappers
{
    public static class ClienteMapper
    {
        //Este metodo retornará un objeto creado a partir de un DataRow
        public static Cliente ObtenerObjetoDataRow(DataRow dt)
        {
            return new Cliente
            {
#nullable disable
                ClienteID = (dt.Table.Columns.Contains("ClienteID") && dt["ClienteID"] != DBNull.Value) ? int.Parse(dt["ClienteID"].ToString()) : 0,
                Nombre = (dt.Table.Columns.Contains("Nombre") && dt["Nombre"] != DBNull.Value) ? dt["Nombre"].ToString() : "",
                Segundo_nombre = (dt.Table.Columns.Contains("Segundo_nombre") && dt["Segundo_nombre"] != DBNull.Value) ? dt["Segundo_nombre"].ToString() : "",
                Apellido_paterno = (dt.Table.Columns.Contains("Apellido_paterno") && dt["Apellido_paterno"] != DBNull.Value) ? dt["Apellido_paterno"].ToString() : "",
                Apellido_materno = (dt.Table.Columns.Contains("Apellido_materno") && dt["Apellido_materno"] != DBNull.Value) ? dt["Apellido_materno"].ToString() : "",
                Fecha_nacimiento = (dt.Table.Columns.Contains("Fecha_nacimiento") && dt["Fecha_nacimiento"] != DBNull.Value) ? DateTime.Parse(dt["Fecha_nacimiento"].ToString()) : DateTime.Now,
                TipoSexoID = (dt.Table.Columns.Contains("TipoSexoID") && dt["TipoSexoID"] != DBNull.Value) ? int.Parse(dt["TipoSexoID"].ToString()) : 0,
                TipoEstadoCivilID = (dt.Table.Columns.Contains("TipoEstadoCivilID") && dt["TipoEstadoCivilID"] != DBNull.Value) ? int.Parse(dt["TipoEstadoCivilID"].ToString()) : 0,
                CURP = (dt.Table.Columns.Contains("CURP") && dt["CURP"] != DBNull.Value) ? dt["CURP"].ToString() : "",
                RFC = (dt.Table.Columns.Contains("RFC") && dt["RFC"] != DBNull.Value) ? dt["RFC"].ToString() : "",
                Clave_elector = (dt.Table.Columns.Contains("Clave_elector") && dt["Clave_elector"] != DBNull.Value) ? dt["Clave_elector"].ToString() : "",
                Telefono = (dt.Table.Columns.Contains("Telefono") && dt["Telefono"] != DBNull.Value) ? dt["Telefono"].ToString() : "",
                Telefono_prefijo = (dt.Table.Columns.Contains("Telefono_prefijo") && dt["Telefono_prefijo"] != DBNull.Value) ? dt["Telefono_prefijo"].ToString() : "",
                Correo_electronico = (dt.Table.Columns.Contains("Correo_electronico") && dt["Correo_electronico"] != DBNull.Value) ? dt["Correo_electronico"].ToString() : "",
                Activo = (dt.Table.Columns.Contains("Activo") && dt["Activo"] != DBNull.Value) ? (bool)dt["Activo"] : false
#nullable restore
            };
        }
        //Este metodo retornará una lista de objetos creada a partir de un DataTable
        public static List<Cliente> ObtenerListaDesdeTabla(DataTable dt)
        {
            List<Cliente> _lista = new List<Cliente>();
            if (dt != null && dt?.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cliente _cliente = ObtenerObjetoDataRow(dr);
                    _lista.Add(_cliente);
                }
            }
            return _lista;
        }
    }
}
