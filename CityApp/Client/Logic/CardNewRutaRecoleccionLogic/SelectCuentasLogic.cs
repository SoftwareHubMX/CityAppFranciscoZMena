using CityApp.Client.Services.ApiRest.CuentaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNewRutaRecoleccionLogic
{
    public class SelectCuentasLogic
    {
        private CuentaPeticiones CuentaPeticiones;
        private Codificador Codificador = new Codificador();

        public SelectCuentasLogic(HttpClient cliente)
        {
            CuentaPeticiones= new CuentaPeticiones(cliente);
        }

        public async Task<Response<List<Cuenta>>> SelectAll(string token)
        {
            Response<List<Cuenta>> response = await CuentaPeticiones.consultarCuentas(token);
            if(response.Status.Exito == 1)
            {
                for (int i = 0; i < response.Data.Count; i++)
                {
                    response.Data[i].NombreUsuario = Codificador.Decrypt(response.Data[i].NombreUsuario);
                }
            }
            return response;
        }
            
    }
}
