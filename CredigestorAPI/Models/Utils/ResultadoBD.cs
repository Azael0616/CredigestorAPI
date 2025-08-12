namespace CredigestorAPI.Models.Utils
{
    public class ResultadoBD
    {
        public bool Error { get; set; } = true;
        public string ErrorDesc { get; set; } = "Ocurrió un error";
        public string Icon { get; set; } = "error";
        public int Code { get; set; } = 500;
        public int ValorAuxiliar { get; set; } = 0;
        public string Detalle {  get; set; } = string.Empty;
        public ResultadoBD() { }
        public ResultadoBD(bool error, string errorDesc, string icon, int code, int valorauxiliar, string detalle)
        {
            this.Error = error;
            this.ErrorDesc = errorDesc;
            this.Icon = icon;
            this.Code = code;
            this.ValorAuxiliar = valorauxiliar;
            this.Detalle = detalle;
        }
    }
}
