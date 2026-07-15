using CityApp.Client.Services.ApiRest.PredioPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.ModalCargaExcelPredioLogic
{
    public class UpdatePrediosExcel
    {
        private PredioPeticiones PredioPeticiones;

        public UpdatePrediosExcel(HttpClient cliente)
        {
            PredioPeticiones = new PredioPeticiones(cliente);
        }

        public async Task<Response<object>> Update(string token, string nombreArchivo)
        {
            Response<object> response = await PredioPeticiones.actualizarPrediosExcel(token, nombreArchivo);
            return response;
        }
    }
}
