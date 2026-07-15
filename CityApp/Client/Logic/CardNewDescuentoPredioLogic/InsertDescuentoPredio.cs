using CityApp.Client.Services.ApiRest.DescuentoPredioPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardNewDescuentoPredioLogic
{
    public class InsertDescuentoPredio
    {
        private DescuentoPredioPeticiones DescuentoPredioPeticiones;

        public InsertDescuentoPredio(HttpClient cliente)
        {
            DescuentoPredioPeticiones = new DescuentoPredioPeticiones(cliente);
        }

        public async Task<Response<object>> Insert(string token, DescuentoPredio descuentoPredio)
        {
            Response<object> response = await DescuentoPredioPeticiones.crearDescuentoPredio(token, descuentoPredio);
            return response;
        }
    }
}
