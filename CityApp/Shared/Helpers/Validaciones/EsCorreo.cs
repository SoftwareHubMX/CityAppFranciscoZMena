using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CityApp.Shared.Helpers.Validaciones
{
    public class EsCorreo
    {
        public bool validarCorreo(string correo)
        {
            string expresionCorreo = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(correo, expresionCorreo))
            {
                if (Regex.Replace(correo, expresionCorreo, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else return false;
        }
    }
}
