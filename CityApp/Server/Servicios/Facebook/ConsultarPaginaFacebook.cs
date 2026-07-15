using CityApp.Server.Servicios.PeticionesAPI;
using CityApp.Shared.Models.DataValuesModels;
using CityApp.Shared.Models.FacebookModels.PaginaResponse;

namespace CityApp.Server.Servicios.Facebook
{
    public class ConsultarPaginaFacebook
    {
        private GET<PaginaResponse> GET = new GET<PaginaResponse>();

        public Response<PaginaResponse> Consultar(string token)
        {
            Response<PaginaResponse> response = new Response<PaginaResponse>();

            string url = "https://graph.facebook.com/v14.0/me/accounts?fields=name%2Caccess_token%2Calbums&access_token=" + token;
            response = GET.GetData(url);

            return response;
        }
    }
}
