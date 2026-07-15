using CityApp.Client.Services.ApiRest.PatrullaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNuevaPatrullaLogic
{
    public class InsertPatrullaLogic
    {
        private PatrullaPeticiones PatrullaPeticiones;
        private Codificador Codificador = new Codificador();

        public InsertPatrullaLogic(HttpClient cliente)
        {
            PatrullaPeticiones = new PatrullaPeticiones(cliente);
        }

        public async Task<Response<object>> Insert(string token, Patrulla patrulla)
        {
            patrulla.Placa = Codificador.Encrypt(patrulla.Placa);
            patrulla.NumeroEconomico = Codificador.Encrypt(patrulla.NumeroEconomico);
            Response<object> response = await PatrullaPeticiones.crearPatrulla(token, patrulla);
            if(response.Status.Exito != 1)
            {
                patrulla.Placa = Codificador.Decrypt(patrulla.Placa);
                patrulla.NumeroEconomico = Codificador.Decrypt(patrulla.NumeroEconomico);
            }
            return response;
        }
    }
}
