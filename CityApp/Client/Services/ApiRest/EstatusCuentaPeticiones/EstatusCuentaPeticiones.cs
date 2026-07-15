using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.EstatusCuentaPeticiones
{
    public class EstatusCuentaPeticiones
    {
        private VerificarCorreo VerificarCorreo;

        public EstatusCuentaPeticiones(HttpClient cliente)
        {
            VerificarCorreo = new VerificarCorreo(cliente);
        }

        public async Task<Response<object>> verificarCorreo(string token)
        {
            Response<object> response = await VerificarCorreo.VerificarCorreoAsync(token);
            return response;
        }
    }
}
