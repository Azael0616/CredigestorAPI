using CredigestorAPI.BLL.Interfaces;
using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.Models;
using CredigestorAPI.Models.Utils;

namespace CredigestorAPI.BLL
{
    public class Tipo_documentoBLL : ITipo_documentoBLL
    {
        private readonly ITipo_documentoDAL _tipoDocumentoDAL;
        public Tipo_documentoBLL(ITipo_documentoDAL tipoDocumentoDAL)
        {
            _tipoDocumentoDAL = tipoDocumentoDAL;
        }
        //Obtiene todos los tipos de documentos activos
        public async Task<List<Tipo_documento>> ObtenerCatalogoActivo(int formularioID)
        {
            //Validación
            if (formularioID <= 0)
            {
                throw new HttpResponseException(400, "Parámetro inválido");
            }
            return await _tipoDocumentoDAL.ObtenerCatalogoActivo(formularioID);
        }
    }
}
