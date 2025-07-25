using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.DAL.Mappers;
using CredigestorAPI.Models;
using System.Data;

namespace CredigestorAPI.DAL
{
    public class Tipo_area_perfilDAL : ITipo_area_perfilDAL
    {
        private readonly ISqlAuxiliar _sqlAuxiliar;
        public Tipo_area_perfilDAL(ISqlAuxiliar sqlAuxiliar)
        {
            _sqlAuxiliar = sqlAuxiliar;
        }
        //Obtiene todos los tipo de area de perfil para estudio activos
        public async Task<List<Tipo_area_perfil>> ObtenerCatalogoActivoEstudio()
        {
            List<Tipo_area_perfil> _lista = new List<Tipo_area_perfil>();
            DataTable dt = await _sqlAuxiliar.EjecutarTablaPA("Sp_TipoAreaPerfil_O_CAEstudio", null);
            if (dt == null)
                return _lista;
            else
            {
                _lista = Tipo_area_perfilMapper.ObtenerListaDataTable(dt);
                return _lista;
            }
        }
        //Obtiene todos los tipo de area de perfil para ocupacion activos
        public async Task<List<Tipo_area_perfil>> ObtenerCatalogoActivoOcupacion()
        {
            List<Tipo_area_perfil> _lista = new List<Tipo_area_perfil>();
            DataTable dt = await _sqlAuxiliar.EjecutarTablaPA("Sp_TipoAreaPerfil_O_CAOcupacion", null);
            if (dt == null)
                return _lista;
            else
            {
                _lista = Tipo_area_perfilMapper.ObtenerListaDataTable(dt);
                return _lista;
            }
        }
    }
}
