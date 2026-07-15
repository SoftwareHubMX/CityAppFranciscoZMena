using CityApp.Client.Services.ApiRest.PagoPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.ModalPagoCompletoLogic
{
    public class DeletePago
    {
        private PagoPeticiones PagoPeticiones;

        public DeletePago(HttpClient cliente)
        {
            PagoPeticiones = new PagoPeticiones(cliente);
        }

        public async Task<Response<object>> Delete(string token, int idPago)
        {
            Response<object> response = await PagoPeticiones.eliminarPago(token, idPago);
            return response;
        }
    }
}
