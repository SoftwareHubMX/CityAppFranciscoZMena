using CityApp.Client.Services.ApiRest.EscolaridadPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNuevaPortulacionLogic
{
    public class SelectEscolaridadLogic
    {
        private EscolaridadPeticiones EscolaridadPeticiones;

        public SelectEscolaridadLogic(HttpClient cliente)
        {
            EscolaridadPeticiones = new EscolaridadPeticiones(cliente);
        }

        public async Task<Response<List<Escolaridad>>> SelectAll()
        {
            Response<List<Escolaridad>> response = await EscolaridadPeticiones.consultarEscolaridades();
            return response;
        }
    }
}
