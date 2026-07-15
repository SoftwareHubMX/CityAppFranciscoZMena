using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.DataValuesModels
{
    public class Peticion<T>
    {
        public string Token { get; set; } = "Tokenqwerty";
        public string? Identificador { get; set; }
        public T? Data { get; set; }
    }
}
