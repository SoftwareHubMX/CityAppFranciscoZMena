using CityApp.Client.Services.ApiRest.HistoricoPredioPeticiones;
using CityApp.Shared.Models.DataValuesModels;
using CityApp.Shared.Models.FacebookModels.Publicacion;
using Microsoft.IdentityModel.Tokens;

namespace CityApp.Client.Logic.ModalCargaExcelPredioLogic
{
    public class DeleteHistoricoPredio
    {
        private HistoricoPredioPeticiones HistoricoPredioPeticiones;

        public DeleteHistoricoPredio(HttpClient cliente)
        {
            HistoricoPredioPeticiones = new HistoricoPredioPeticiones(cliente);
        }

        public async Task<Response<object>> Delete(string token, int idHistoricoPredio)
        {
            Response<object> response = await HistoricoPredioPeticiones.eliminarHistoricoPredio(token, idHistoricoPredio);
            return response;
        }
    }
}
