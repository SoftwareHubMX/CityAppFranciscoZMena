using CityApp.Server.Servicios.PeticionesAPI;
using CityApp.Shared.Models.DataValuesModels;
using CityApp.Shared.Models.FacebookModels.Publicacion;

namespace CityApp.Server.Servicios.Facebook
{
    public class PublicarNormal
    {
        private POST<PublicacionNormal, PublicacionResponse> POST = new POST<PublicacionNormal, PublicacionResponse>();

        public async Task<Response<PublicacionResponse>> Publicar(string token, string texto, string idPagina)
        {
            Response<PublicacionResponse> response = new Response<PublicacionResponse>();

            string url = "https://graph.facebook.com/" + idPagina + "/feed";

            PublicacionNormal publicacionNormal = new PublicacionNormal()
            {
                message = texto,
                access_token = token,
            };

            response = await POST.PostData(url, publicacionNormal);

            return response;
        }
    }
} 
