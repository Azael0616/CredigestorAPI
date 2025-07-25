using CredigestorAPI.BLL.Interfaces;
using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.DAL.Mappers;
using CredigestorAPI.DAL.Utils;
using CredigestorAPI.Models;
using System.Data;

namespace CredigestorAPI.BLL
{
    public class PaisBLL : IPaisBLL
    {
        private readonly IPaisDAL _paisDAL;
        public PaisBLL(IPaisDAL paisDAL)
        {
            _paisDAL = paisDAL;
        }
        //Obtiene todos los paises activos
        public async Task<List<Pais>> ObtenerCatalogoActivo()
        {            
            return await _paisDAL.ObtenerCatalogoActivo();            
        }
    }
}
