using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.FacebookModels.LoginResponse
{
    public class LoginResponseClient
    {
        public authResponse authResponse { get; set; }
        public string status { get; set; }
        public double expiresAt { get; set; }
    }
}
