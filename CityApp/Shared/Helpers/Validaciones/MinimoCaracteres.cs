using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Helpers.Validaciones
{
    public class MinimoCaracteres
    {
        public bool ValidarMinimoCarcteres(int minimo, string data)
        {
            bool response = false;
            if (data.Length >= minimo)
            {
                response = true;
            }
            return response;
        }
    }
}
