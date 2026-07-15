using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.DataValuesModels
{
    public class Status
    {
        public int Exito { get; set; } = 0;
        public string Exception { get; set; } = "";
        public string Mensaje { get; set; } = "";
    }
}
