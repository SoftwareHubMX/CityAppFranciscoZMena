using CityApp.Client.Services.ApiRest.ArchivoHistoricoPredioPeticioes;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.ModalCargaExcelPredioLogic
{
    public class UploadExcelPredio
    {
        private ArchivoHistoricoPredioPeticioes ArchivoHistoricoPredioPeticioes;

        public UploadExcelPredio(HttpClient cliente)
        {
            ArchivoHistoricoPredioPeticioes = new ArchivoHistoricoPredioPeticioes(cliente);
        }

        public async Task<Response<string>> Upload(MultipartFormDataContent content, int idHistorico, string token)
        {
            Response<string> response = await ArchivoHistoricoPredioPeticioes.agregarArchivoHistoricoPredio(content, idHistorico, token);
            return response;
        }
    }
}
