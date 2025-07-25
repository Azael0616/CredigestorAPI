using CredigestorAPI.BLL.Interfaces;
using CredigestorAPI.DAL;
using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.Models;
using CredigestorAPI.Models.Utils;

namespace CredigestorAPI.BLL
{
    public class MunicipioBLL : IMunicipioBLL
    {
        private readonly IMunicipioDAL _municipioDAL;
        public MunicipioBLL(IMunicipioDAL municipioDAL)
        {
            _municipioDAL = municipioDAL;   
        }
        //Obtiene todos los municipios activos
        public async Task<List<Municipio>> ObtenerCatalogoActivo(int estadoID)
        {
            //Validación
            if (estadoID <= 0)
            {
                throw new HttpResponseException(400, "Parámetro inválido");
            }
            return await _municipioDAL.ObtenerCatalogoActivo(estadoID);
        }
    }
}
