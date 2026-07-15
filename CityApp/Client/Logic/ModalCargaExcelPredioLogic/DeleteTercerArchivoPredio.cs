using CityApp.Client.Services.ApiRest.ArchivoHistoricoPredioPeticioes;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.ModalCargaExcelPredioLogic
{
    public class DeleteTercerArchivoPredio
    {
        private ArchivoHistoricoPredioPeticioes ArchivoHistoricoPredioPeticioes;

        public DeleteTercerArchivoPredio(HttpClient cliente)
        {
            ArchivoHistoricoPredioPeticioes = new ArchivoHistoricoPredioPeticioes(cliente);
        }

        public async Task<Response<object>> Delete(string token)
        {
            Response<object> response = await ArchivoHistoricoPredioPeticioes.eliminarArchivoHistoricoPredioTercero(token);
            return response;
        }
    }
}
