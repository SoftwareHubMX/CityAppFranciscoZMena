using CityApp.Client.Services.ApiRest.EstatusCuentaPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardValidarCorreoLogic
{
    public class ValidarCorreo
    {
        private EstatusCuentaPeticiones EstatusCuentaPeticiones;

        public ValidarCorreo(HttpClient cliente)
        {
            EstatusCuentaPeticiones = new EstatusCuentaPeticiones(cliente);
        }

        public async Task<Response<object>> Validar(string Token)
        {
            Response<object> response = await EstatusCuentaPeticiones.verificarCorreo(Token);
            return response;
        }
    }
}
