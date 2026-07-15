using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Helpers
{
    public class Fecha
    {
        public static DateTime GetFechaMx()
        {
            return DateTime.UtcNow.AddHours(-5);
        }
    }
}
