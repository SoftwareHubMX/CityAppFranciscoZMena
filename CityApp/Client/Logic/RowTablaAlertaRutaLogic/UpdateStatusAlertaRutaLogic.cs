

using CityApp.Client.Services.ApiRest.AlertaRutaPeticiones;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.RowTablaAlertaRutaLogic
{
    public class UpdateStatusAlertaRutaLogic
    {
        private AlertaRutaPeticiones AlertaRutaPeticiones;

        public UpdateStatusAlertaRutaLogic(HttpClient cliente)
        {
            AlertaRutaPeticiones = new AlertaRutaPeticiones(cliente);
        }

        public async Task<Response<object>> Update(string token, int idAlerta, int idEstausAlerta)
        {
            Response<object> response = await AlertaRutaPeticiones.actualizarStatusAlertaRuta(token, idAlerta, idEstausAlerta);
            return response;
        }
    }
}
