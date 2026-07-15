using CityApp.Client.Services.ApiRest.CuentaPeticiones;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.ControllersModels.CuentaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardRestaurarPassLogic
{
    public class UpdataPassword
    {
        private CuentaPeticiones CuentaPeticiones;
        private Codificador Codificador = new Codificador();

        public UpdataPassword(HttpClient cliente)
        {
            CuentaPeticiones = new CuentaPeticiones(cliente);
        }

        public async Task<Response<object>> Updata(RecuperacionPassword recuperacionPassword)
        {
            RecuperacionPassword RecuperacionPasswordEncrypt = new RecuperacionPassword() 
            { 
                Token = recuperacionPassword.Token,
                Password = Codificador.EncryptKey(recuperacionPassword.Password),
                CerrarSesiones = true
            };
            Response<object> response = await CuentaPeticiones.recuperarPassword(RecuperacionPasswordEncrypt);
            return response;
        }
    }
}
