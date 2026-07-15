using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Helpers.Validaciones
{
    public class MaximoCaracteres
    {
        public bool ValidarMaximoCarcteres(int maximo, string data)
        {
            bool response = false;
            if (data.Length <= maximo)
            {
                response = true;
            }
            else
            {
                response = false;
            }
            return response;
        }
    }
}
