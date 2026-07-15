using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Helpers.Validaciones
{
    public class EsNumeroTenefono
    {
        public bool validarTelefono(string data)
        {
            bool telefono = false;
            if (data.Length == 10)
            {
                try
                {
                    double.Parse(data);
                    telefono = true;
                }
                catch (Exception e)
                {
                    telefono = false;
                }
            }
            else
            {
                telefono = false;
            }
            return telefono;
        }
    }
}
