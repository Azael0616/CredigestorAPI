using System.Data;

namespace CredigestorAPI.Models
{
    public class Cliente_perfil
    {
        public int ClienteID { get; set; } = 0;
        public int Nivel_estudio { get; set; } = 0;
        public int Area_estudio { get; set; } = 0;
        public string Carrera_estudio { get; set; } = string.Empty;
        public int Area_ocupacion { get; set; } = 0;
        public string Puesto {  get; set; } = string.Empty;
        public string Empresa {  get; set; } = string.Empty;
        public int Tiempo_empresa { get; set; } = 0;
        public decimal Ingreso_mensual { get; set; } = 0;
        public decimal Gasto_mensual { get; set; } = 0;
        public Cliente_perfil() { }
        public Cliente_perfil(int clienteid, int nivel_estudio, int area_estudio, string carrera_estudio, int area_ocupacion, string puesto, string empresa, int tiempo_empresa, decimal ingreso_mensual, decimal gasto_mensual)
        {
            this.ClienteID = clienteid;
            this.Nivel_estudio = nivel_estudio;
            this.Area_estudio = area_estudio;
            this.Carrera_estudio = carrera_estudio;
            this.Area_ocupacion = area_ocupacion;
            this.Puesto = puesto;
            this.Empresa = empresa;
            this.Tiempo_empresa = tiempo_empresa;
            this.Ingreso_mensual = ingreso_mensual;
            this.Gasto_mensual = gasto_mensual;
        }        
    }
}
