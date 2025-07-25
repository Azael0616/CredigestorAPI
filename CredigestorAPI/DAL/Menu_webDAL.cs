using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.DAL.Mappers;
using CredigestorAPI.Models;
using System.Data;

namespace CredigestorAPI.DAL
{
    public class Menu_webDAL : IMenu_webDAL
    {
        private readonly ISqlAuxiliar _sqlAuxiliar;
        public Menu_webDAL(ISqlAuxiliar sqlAuxiliar) {
            _sqlAuxiliar = sqlAuxiliar;
        }
        //Obtiene los menu web disponible para un usuario según su nivel de usuario
        public async Task<List<Menu_web>> ObtenerMenuWebPorUsuario(int usuarioID)
        {
            List<Menu_web> _lista = new List<Menu_web>();
#nullable disable
            var parameters = new Dictionary<string, object>
            {
                { "@UsuarioID", usuarioID},
            };
#nullable enable
            DataTable dt = await _sqlAuxiliar.EjecutarTablaPA("Sp_MenuWeb_O_PorUsuario", parameters);
            if (dt == null)
                return _lista;
            else
            {
                _lista = Menu_webMapper.ObtenerListaDataTable(dt);
                return _lista;
            }
        }
    }
}
