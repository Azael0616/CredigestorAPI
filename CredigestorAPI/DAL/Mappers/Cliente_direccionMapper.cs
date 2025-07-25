using CredigestorAPI.Models;
using System.Data;

namespace CredigestorAPI.DAL.Mappers
{
    public static class Cliente_direccionMapper
    {
        //Este metodo retornará un objeto creado a partir de un DataRow
        public static Cliente_direccion ObtenerObjetoDataRow(DataRow dt)
        {
#nullable disable
            return new Cliente_direccion{
                ClienteID = (dt.Table.Columns.Contains("ClienteID") && dt["ClienteID"] != DBNull.Value) ? int.Parse(dt["ClienteID"].ToString()) : 0,
                Calle = (dt.Table.Columns.Contains("Calle") && dt["Calle"] != DBNull.Value) ? dt["Calle"].ToString() : "",
                Numero_exterior = (dt.Table.Columns.Contains("Numero_exterior") && dt["Numero_exterior"] != DBNull.Value) ? dt["Numero_exterior"].ToString() : "",
                Numero_interior = (dt.Table.Columns.Contains("Numero_interior") && dt["Numero_interior"] != DBNull.Value) ? dt["Numero_interior"].ToString() : "",
                Entre_calle1 = (dt.Table.Columns.Contains("Entre_calle1") && dt["Entre_calle1"] != DBNull.Value) ? dt["Entre_calle1"].ToString() : "",
                Entre_calle2 = (dt.Table.Columns.Contains("Entre_calle2") && dt["Entre_calle2"] != DBNull.Value) ? dt["Entre_calle2"].ToString() : "",
                Colonia = (dt.Table.Columns.Contains("Colonia") && dt["Colonia"] != DBNull.Value) ? dt["Colonia"].ToString() : "",
                PaisID = (dt.Table.Columns.Contains("PaisID") && dt["PaisID"] != DBNull.Value) ? int.Parse(dt["PaisID"].ToString()) : 0,
                EstadoID = (dt.Table.Columns.Contains("EstadoID") && dt["EstadoID"] != DBNull.Value) ? int.Parse(dt["EstadoID"].ToString()) : 0,
                MunicipioID = (dt.Table.Columns.Contains("MunicipioID") && dt["MunicipioID"] != DBNull.Value) ? int.Parse(dt["MunicipioID"].ToString()) : 0
            };            
#nullable restore
        }
        //Este metodo retornará una lista de objetos creada a partir de un DataTable
        public static List<Cliente_direccion> ObtenerListaDataTable(DataTable dt)
        {
            List<Cliente_direccion> _lista = new List<Cliente_direccion>();
            if (dt != null && dt?.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cliente_direccion _cliente = ObtenerObjetoDataRow(dr);
                    _lista.Add(_cliente);
                }
            }
            return _lista;
        }
    }
}
