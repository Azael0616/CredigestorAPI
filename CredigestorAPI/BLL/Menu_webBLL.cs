using CredigestorAPI.BLL.Interfaces;
using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.DAL.Utils;
using CredigestorAPI.Models;
using System.Data;
namespace CredigestorAPI.BLL
{
    public class Menu_webBLL : IMenu_webBLL
    {
        private readonly IMenu_webDAL _menuWebDAL;
        public Menu_webBLL(IMenu_webDAL menuWebDAL)
        {
            _menuWebDAL = menuWebDAL;
        }
        //Obtiene los menu web disponible para un usuario según su nivel de usuario
        public async Task<List<Menu_web>> ObtenerMenuWebPorUsuario(int usuarioID)
        {
            List<Menu_web> _lista = await _menuWebDAL.ObtenerMenuWebPorUsuario(usuarioID);
            return _lista;
        }
    }
}
