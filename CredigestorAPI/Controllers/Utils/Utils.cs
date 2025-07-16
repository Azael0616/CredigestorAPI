using CredigestorAPI.Models;

namespace CredigestorAPI.Controllers.Utils
{
    public static class Utils
    {
        //Permite crear una jerarquia padre-hijo para el menuweb
        public static List<Menu_web> ConstruirJerarquia(List<Menu_web> menus)
        {
            var lookup = menus.ToDictionary(m => m.MenuWebID); // acceso rápido por ID
            var resultado = new List<Menu_web>();

            foreach (var menu in menus)
            {
                if (menu.MenuPadreID.HasValue && lookup.ContainsKey(menu.MenuPadreID.Value))
                {
                    // Es submenú → lo agregamos al padre
                    lookup[menu.MenuPadreID.Value].Hijos.Add(menu);
                }
                else
                {
                    // Es menú raíz → lo agregamos al resultado
                    resultado.Add(menu);
                }
            }

            return resultado;
        }
    }
}
