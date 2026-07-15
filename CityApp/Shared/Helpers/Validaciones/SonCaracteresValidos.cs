using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Helpers.Validaciones
{
    public class SonCaracteresValidos
    {
        public bool ValidarCaracteres(string data)
        {
            bool validar = false;
            bool validacionroptura = true;
            foreach (char c in data)
            {
                if (c == ';')
                {
                    validar = false;
                    validacionroptura = false;
                }
                else if (c == '\u0022')
                {
                    validar = false;
                    validacionroptura |= false;
                }
                else if (validacionroptura)
                {
                    validar = true;
                }
            }
            return validar;
        }
    }
}
