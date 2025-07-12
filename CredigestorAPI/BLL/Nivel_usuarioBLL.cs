using CredigestorAPI.BLL.Interfaces;
using CredigestorAPI.BLL.Utils;
using CredigestorAPI.DAL;
using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.Models;
using CredigestorAPI.Models.DTO;
using CredigestorAPI.Models.Utils;

namespace CredigestorAPI.BLL
{
    public class Nivel_usuarioBLL : INivel_usuarioBLL
    {
        private readonly INivel_usuarioDAL _nivelUsuarioDAL;
        public Nivel_usuarioBLL(INivel_usuarioDAL nivelUsuarioDAL)
        {
            _nivelUsuarioDAL = nivelUsuarioDAL;            
        }
        public async Task<List<Nivel_usuario>> ObtenerCatalogoActivo(int usuarioID)
        {
            if(usuarioID <= 0)
            {
                throw new HttpResponseException(400, "Parámetro UsuarioID inválido");
            }
            List<Nivel_usuario> _lista = await _nivelUsuarioDAL.ObtenerCatalogoActivo(usuarioID);
            return _lista;
        }
    }
}
