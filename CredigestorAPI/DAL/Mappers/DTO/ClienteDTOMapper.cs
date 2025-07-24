using CredigestorAPI.Models.DTO;
using System.Data;

namespace CredigestorAPI.DAL.Mappers.DTO
{
    public static class ClienteDTOMapper
    {
        //Este metodo retornará un objeto creado a partir de un DataRow
        public static ClienteDTO ObtenerObjetoDataRow(DataRow dt)
        {
#nullable disable
            return new ClienteDTO
            {
                ClienteID = (dt.Table.Columns.Contains("ClienteID") && dt["ClienteID"] != DBNull.Value) ? int.Parse(dt["ClienteID"].ToString()) : 0,
                Nombre = (dt.Table.Columns.Contains("Nombre") && dt["Nombre"] != DBNull.Value) ? dt["Nombre"].ToString() : "",
                Segundo_nombre = (dt.Table.Columns.Contains("Segundo_nombre") && dt["Segundo_nombre"] != DBNull.Value) ? dt["Segundo_nombre"].ToString() : "",
                Apellido_paterno = (dt.Table.Columns.Contains("Apellido_paterno") && dt["Apellido_paterno"] != DBNull.Value) ? dt["Apellido_paterno"].ToString() : "",
                Apellido_materno = (dt.Table.Columns.Contains("Apellido_materno") && dt["Apellido_materno"] != DBNull.Value) ? dt["Apellido_materno"].ToString() : "",
                Fecha_nacimiento = (dt.Table.Columns.Contains("Fecha_nacimiento") && dt["Fecha_nacimiento"] != DBNull.Value) ? dt["Fecha_nacimiento"].ToString() : "",
                Sexo = (dt.Table.Columns.Contains("Sexo") && dt["Sexo"] != DBNull.Value) ? dt["Sexo"].ToString() : "",
                Estado_civil = (dt.Table.Columns.Contains("Estado_civil") && dt["Estado_civil"] != DBNull.Value) ? dt["Estado_civil"].ToString() : "",
                CURP = (dt.Table.Columns.Contains("CURP") && dt["CURP"] != DBNull.Value) ? dt["CURP"].ToString() : "",
                RFC = (dt.Table.Columns.Contains("RFC") && dt["RFC"] != DBNull.Value) ? dt["RFC"].ToString() : "",
                Clave_elector = (dt.Table.Columns.Contains("Clave_elector") && dt["Clave_elector"] != DBNull.Value) ? dt["Clave_elector"].ToString() : "",
                Telefono = (dt.Table.Columns.Contains("Telefono") && dt["Telefono"] != DBNull.Value) ? dt["Telefono"].ToString() : "",
                Correo_electronico = (dt.Table.Columns.Contains("Correo_electronico") && dt["Correo_electronico"] != DBNull.Value) ? dt["Correo_electronico"].ToString() : "",
                Activo = (dt.Table.Columns.Contains("Activo") && dt["Activo"] != DBNull.Value) ? (bool)dt["Activo"] : false
            };            
#nullable restore
        }
        //Este metodo retornará una lista de objetos creada a partir de un DataTable
        public static List<ClienteDTO> ObtenerListaDataTable(DataTable dt)
        {
            List<ClienteDTO> _lista = new List<ClienteDTO>();
            if (dt != null && dt?.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ClienteDTO _cliente = ObtenerObjetoDataRow(dr);
                    _lista.Add(_cliente);
                }
            }
            return _lista;
        }
    }
}
