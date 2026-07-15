using CityApp.Client.Services.ApiRest.ArchivoHistoricoPredioPeticioes;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.ModalCargaExcelPredioLogic
{
    public class DeleteArchivoHistoricoPredio
    {
        private ArchivoHistoricoPredioPeticioes ArchivoHistoricoPredioPeticioes;

        public DeleteArchivoHistoricoPredio(HttpClient cliente)
        {
            ArchivoHistoricoPredioPeticioes = new ArchivoHistoricoPredioPeticioes(cliente);
        }

        public async Task<Response<object>> Delete(string token, int idHistoricoPredio)
        {
            Response<object> response = await ArchivoHistoricoPredioPeticioes.eliminraArchivoHistoricoPredioIdHistoricoPredio(token, idHistoricoPredio);
            return response;
        }
    }
}
