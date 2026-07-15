using CityApp.Server.Servicios.PeticionesAPI;
using CityApp.Shared.Models.DataValuesModels;
using CityApp.Shared.Models.FacebookModels.LoginResponse;

namespace CityApp.Server.Servicios.Facebook
{
    public class ConsultarPerfilFacebook
    {
        private GET<PerfilFacebook> GET = new GET<PerfilFacebook>();

        public Response<PerfilFacebook> Consultar(string token)
        {
            Response<PerfilFacebook> response = new Response<PerfilFacebook>();

            string url = "https://graph.facebook.com/v14.0/me?fields=id%2Cname%2Cemail&access_token=" + token;
            response = GET.GetData(url);

            return response;
        }
    }
}
