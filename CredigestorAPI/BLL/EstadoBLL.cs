using CredigestorAPI.BLL.Interfaces;
using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.Models;
using CredigestorAPI.Models.Utils;

namespace CredigestorAPI.BLL
{
    public class EstadoBLL : IEstadoBLL
    {
        private readonly IEstadoDAL _estadoDAL;
        public EstadoBLL(IEstadoDAL estadoDAL)
        {
            _estadoDAL = estadoDAL; 
        }
        //Obtiene todos los estados activos
        public async Task<List<Estado>> ObtenerCatalogoActivo(int paisID)
        {            
            //Validación
            if(paisID <= 0)
            {
                throw new HttpResponseException(400, "Parámetro inválido");
            }
            return await _estadoDAL.ObtenerCatalogoActivo(paisID);            
        }
    }
}
