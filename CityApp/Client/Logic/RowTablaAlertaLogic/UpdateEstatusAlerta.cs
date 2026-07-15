using CityApp.Client.Services.ApiRest.AlertaPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.RowTablaAlertaLogic
{
    public class UpdateEstatusAlerta
    {
        private AlertaPeticiones AlertaPeticiones;

        public UpdateEstatusAlerta(HttpClient cliente)
        {
            AlertaPeticiones = new AlertaPeticiones(cliente);
        }

        public async Task<Response<object>> Update(string token, int idAlerta, int idEstausAlerta)
        {
            Response<object> response = await AlertaPeticiones.actualizarEstatusAlerta(token, idAlerta, idEstausAlerta);
            return response;
        }
    }
}
