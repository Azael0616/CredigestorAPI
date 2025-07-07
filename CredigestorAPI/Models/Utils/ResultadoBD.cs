namespace CredigestorAPI.Models.Utils
{
    public class ResultadoBD
    {
        public bool Error { get; set; } = true;
        public string ErrorDesc { get; set; } = "Ocurrió un error";
        public string Icon { get; set; } = "error";
        public ResultadoBD() { }
        public ResultadoBD(bool error, string errorDesc, string icon)
        {
            this.Error = error;
            this.ErrorDesc = errorDesc;
            this.Icon = icon;
        }
    }
}
