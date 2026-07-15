using CityApp.Client.Services.ApiRest.DiscapacidadPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNuevaPortulacionLogic
{
    public class SelectDiscapacidadLogic
    {
        private DiscapacidadPeticiones DiscapacidadPeticiones;

        public SelectDiscapacidadLogic(HttpClient cliente)
        {
            DiscapacidadPeticiones = new DiscapacidadPeticiones(cliente);
        }

        public async Task<Response<List<Discapacidad>>> SelectAll()
        {
            Response<List<Discapacidad>> response = await DiscapacidadPeticiones.consultarDiscapacidades();
            return response;
        }
    }
}
