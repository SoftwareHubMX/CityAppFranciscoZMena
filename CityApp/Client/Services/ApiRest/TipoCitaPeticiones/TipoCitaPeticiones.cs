using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.TipoCitaPeticiones
{
    public class TipoCitaPeticiones
    {
        private ConsultarTiposCita ConsultarTiposCita;

        public TipoCitaPeticiones(HttpClient cliente)
        {
            ConsultarTiposCita = new ConsultarTiposCita(cliente);
        }

        public async Task<Response<List<TipoCita>>> consultaTiposCita()
        {
            Response<List<TipoCita>> response = await ConsultarTiposCita.ConsultaTiposCitaAsync();
            return response;
        }
    }
}
