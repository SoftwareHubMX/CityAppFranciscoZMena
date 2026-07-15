using CityApp.Client.Services.ApiRest.AlertaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaAlertaLogic
{
    public class SelectAlertas
    {
        private AlertaPeticiones AlertaPeticiones;
        private Codificador Codificador = new Codificador();

        public SelectAlertas(HttpClient cliente)
        {
            AlertaPeticiones = new AlertaPeticiones(cliente);
        }

        public async Task<Response<List<Alerta>>> SelectAll(string token, int idEstatusAlerta)
        {
            Response<List<Alerta>> response = await AlertaPeticiones.consultarAlertasAdministrador(token, idEstatusAlerta);
            if(response.Status.Exito == 1)
            {
                for(int i = 0; i < response.Data.Count; i++)
                {
                    if(response.Data[i].Cuenta != null)
                    {
                        response.Data[i].Cuenta.NombreUsuario = Codificador.Decrypt(response.Data[i].Cuenta.NombreUsuario);
                    }
                }
            }
            return response;
        }
    }
}
