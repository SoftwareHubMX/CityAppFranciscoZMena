using CityApp.Server.Servicios.PeticionesAPI;
using CityApp.Shared.Models.DataValuesModels;
using CityApp.Shared.Models.FacebookModels.Publicacion;

namespace CityApp.Server.Servicios.Facebook
{
    public class PublicarImagen
    {
        private POST<PublicacionImagen, PublicacionResponse> POST = new POST<PublicacionImagen, PublicacionResponse>();

        public async Task<Response<PublicacionResponse>> Publicar(string token, string texto, string imagen, string idAlbum)
        {
            Response<PublicacionResponse> response = new Response<PublicacionResponse>();

            string url = "https://graph.facebook.com/" + idAlbum + "/photos";

            PublicacionImagen publicacionImagen = new PublicacionImagen()
            {
                url = "https://www.cityapp.mx/TemporalFiles/" + imagen,
                caption = texto,
                access_token = token,
            };

            response = await POST.PostData(url, publicacionImagen);

            return response;
        }
    }
}
