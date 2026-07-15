using CityApp.Client.Services.ApiRest.DescuentoPredioPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaDescuentosPrediosLogic
{
    public class DeleteDescuentoPredio
    {
        private DescuentoPredioPeticiones DescuentoPredioPeticiones;

        public DeleteDescuentoPredio(HttpClient cliente)
        {
            DescuentoPredioPeticiones = new DescuentoPredioPeticiones(cliente);
        }

        public async Task<Response<object>> Delete(string token, int idDescuentoPredio)
        {
            Response<object> response = await DescuentoPredioPeticiones.eliminarDescuentoPredio(token, idDescuentoPredio);
            return response;
        }
    }
}
