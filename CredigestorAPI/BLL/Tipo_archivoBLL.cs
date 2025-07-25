using CredigestorAPI.BLL.Interfaces;
using CredigestorAPI.DAL;
using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.Models;
using CredigestorAPI.Models.Utils;

namespace CredigestorAPI.BLL
{
    public class Tipo_archivoBLL : ITipo_archivoBLL
    {
        private readonly ITipo_archivoDAL _tipoArchivoDAL;
        public Tipo_archivoBLL(ITipo_archivoDAL tipoArchivoDAL)
        {
            _tipoArchivoDAL = tipoArchivoDAL;
        }
        //Obtiene todos los tipos de archivos activos
        public async Task<List<Tipo_archivo>> ObtenerCatalogoActivo()
        {
            return await _tipoArchivoDAL.ObtenerCatalogoActivo();
        }
    }
}
