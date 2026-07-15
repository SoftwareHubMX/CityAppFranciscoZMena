using CityApp.Client.Services.ApiRest.TipoCitaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaCitasLogic
{
    public class SelectTipoCitasLogic
    {
        private TipoCitaPeticiones TipoCitaPeticiones;

        public SelectTipoCitasLogic(HttpClient cliente)
        {
            TipoCitaPeticiones = new TipoCitaPeticiones(cliente);
        }

        public async Task<Response<List<TipoCita>>> SelectAll()
        {
            Response<List<TipoCita>> response = await TipoCitaPeticiones.consultaTiposCita();
            return response;
        }
    }
}
