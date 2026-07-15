using CityApp.Client.Services.ApiRest.TokenActualizarPasswordPeticiones;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardEnvioCorreoRestaurarPassLogic
{
    public class SendMail
    {
        private TokenActualizarPasswordPeticiones TokenActualizarPasswordPeticiones;
        private Codificador Codificador = new Codificador();

        public SendMail(HttpClient cliente)
        {
            TokenActualizarPasswordPeticiones = new TokenActualizarPasswordPeticiones(cliente);
        }

        public async Task<Response<object>> Send(string correo)
        {
            string correoEncrypt = Codificador.EncryptCorreo(correo);
            Response<object> response = await TokenActualizarPasswordPeticiones.crearTokenActualizarPassword(correoEncrypt);
            return response;
        }
    }
}
