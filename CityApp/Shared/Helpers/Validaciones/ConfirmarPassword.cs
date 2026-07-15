using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Helpers.Validaciones
{
    public class ConfirmarPassword
    {
        public bool ValidarContraseñas(string pass1, string pass2)
        {
            bool password = false;
            if (pass1 == pass2)
            {
                password = true;
            }
            return password;
        }
    }
}
