using CredigestorAPI.BLL.Interfaces;
using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.Models;
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
        //Obtiene el catalogo activo de nivel de usuario
        public async Task<List<Nivel_usuario>> ObtenerCatalogoActivo(int usuarioID)
        {
            if(usuarioID <= 0)
            {
                throw new HttpResponseException(400, "Parámetro UsuarioID inválido");
            }
            return await _nivelUsuarioDAL.ObtenerCatalogoActivo(usuarioID);            
        }
    }
}
