using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Models.FacebookModels.LoginResponse
{
    public class authResponse
    {
        public string accessToken { get; set; }
        public string userID { get; set; }
        public int expiresIn { get; set; }
        public string signedRequest { get; set; }
        public string graphDomain { get; set; }
        public int data_access_expiration_time { get; set; }
    }
}
