using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.GeolocalizacionModels
{
    public class ResponseGeocode
    {
        public plus_code plus_Code { get; set; }
        public List<result> results { get; set; }
        public string status { get; set; }
    }
}
