using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.TipoLugarTuisticoPeticiones
{
    public class TipoLugarTuisticoPeticiones
    {
        private ConsultaTiposLugarTuristico ConsultaTiposLugarTuristico;

        public TipoLugarTuisticoPeticiones(HttpClient cliente) 
        {
            ConsultaTiposLugarTuristico = new ConsultaTiposLugarTuristico(cliente);
        }

        public async Task<Response<List<TipoLugarTuristico>>> consultaTiposLugarTuristico()
        {
            Response<List<TipoLugarTuristico>> response = await ConsultaTiposLugarTuristico.ConsultaTiposLugarTuristicoAsync();
            return response;
        }
    }
}
