using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.Models;
using CredigestorAPI.Models.DTO;
using System.Data;

namespace CredigestorAPI.DAL
{
    public class Nivel_usuarioDAL : INivel_usuarioDAL
    {
        private readonly ISqlAuxiliar _sqlAuxiliar;
        public Nivel_usuarioDAL(ISqlAuxiliar sqlAuxiliar)
        {
            _sqlAuxiliar = sqlAuxiliar;
        }
        //Obtiene todos los niveles de usuario activo
        public async Task<List<Nivel_usuario>> ObtenerCatalogoActivo(int usuarioID)
        {
            List<Nivel_usuario> _lista = new List<Nivel_usuario>();
            var parameters = new Dictionary<string, object>
            {
                { "@UsuarioID", usuarioID },
            };
            DataTable dt = await _sqlAuxiliar.EjecutarTablaPA("Sp_NivelUsuario_O_CatalogoActivo", parameters);
            if (dt == null)
                return _lista;
            else
            {
                _lista = Nivel_usuario.ObtenerListaDesdeTabla(dt);
                return _lista;
            }
        }
    }
}
