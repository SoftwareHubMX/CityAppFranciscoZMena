using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.ArchivoHistoricoPredioPeticioes
{
    public class ArchivoHistoricoPredioPeticioes
    {
        private AgregarArchivoHistoricoPredio AgregarArchivoHistoricoPredio;
        private DescargarArchivoHistoricoPredio DescargarArchivoHistoricoPredio;
        private EliminarArchivoHistoricoPredio EliminarArchivoHistoricoPredio;
        private EliminarArchivoHistoricoPredioTercero EliminarArchivoHistoricoPredioTercero;
        private EliminraArchivoHistoricoPredioIdHistoricoPredio EliminraArchivoHistoricoPredioIdHistoricoPredio;

        public ArchivoHistoricoPredioPeticioes(HttpClient cliente)
        {
            AgregarArchivoHistoricoPredio = new AgregarArchivoHistoricoPredio(cliente);
            DescargarArchivoHistoricoPredio = new DescargarArchivoHistoricoPredio(cliente);
            EliminarArchivoHistoricoPredio = new EliminarArchivoHistoricoPredio(cliente);
            EliminarArchivoHistoricoPredioTercero = new EliminarArchivoHistoricoPredioTercero(cliente);
            EliminraArchivoHistoricoPredioIdHistoricoPredio = new EliminraArchivoHistoricoPredioIdHistoricoPredio(cliente);
        }

        public async Task<Response<string>> agregarArchivoHistoricoPredio(MultipartFormDataContent content, int idHistoricoPredio, string token)
        {
            Response<string> response = await AgregarArchivoHistoricoPredio.AgregarArchivoHistoricoPredioAsync(content, idHistoricoPredio, token);
            return response;
        }

        public async Task<Response<byte[]>> descargarArchivoHistoricoPredio(string imagen, int idNotocia)
        {
            Response<byte[]> response = await DescargarArchivoHistoricoPredio.DescargarArchivoHistoricoPredioAsync(imagen, idNotocia);
            return response;
        }

        public async Task<Response<object>> eliminarArchivoHistoricoPredio(string token, int idArchivoHistoricoPredio)
        {
            Response<object> response = await EliminarArchivoHistoricoPredio.EliminarArchivoHistoricoPredioAsync(token, idArchivoHistoricoPredio);
            return response;
        }

        public async Task<Response<object>> eliminraArchivoHistoricoPredioIdHistoricoPredio(string token, int idHistoricoPredio)
        {
            Response<object> response = await EliminraArchivoHistoricoPredioIdHistoricoPredio.EliminraArchivoHistoricoPredioIdHistoricoPredioAsync(token, idHistoricoPredio);
            return response;
        }

        public async Task<Response<object>> eliminarArchivoHistoricoPredioTercero(string token)
        {
            Response<object> response = await EliminarArchivoHistoricoPredioTercero.EliminarArchivoHistoricoPredioTerceroAsync(token);
            return response;
        }
    }
}
