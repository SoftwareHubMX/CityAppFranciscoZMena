using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.GeolocalizacionModels
{
    public class geometry
    {
        public bounds bounds { get; set; }
        public location location { get; set; }
        public string location_type { get; set; }
        public viewport viewport { get; set; }
    }
}
