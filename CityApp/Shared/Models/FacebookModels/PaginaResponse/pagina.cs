using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.FacebookModels.PaginaResponse
{
    public class pagina
    {
        public string name { get; set; }
        public string access_token { get; set; }
        public albums albums { get; set; }
        public string id { get; set; }
    }
}
