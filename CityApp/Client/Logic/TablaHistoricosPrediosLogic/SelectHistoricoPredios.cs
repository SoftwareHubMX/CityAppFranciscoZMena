using CityApp.Client.Services.ApiRest.HistoricoPredioPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.ControllersModels.HistoricoPredioEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaHistoricosPrediosLogic
{
    public class SelectHistoricoPredios
    {
        private HistoricoPredioPeticiones HistoricoPredioPeticiones;
        private Codificador Codificador = new Codificador();

        public SelectHistoricoPredios(HttpClient cliente)
        {
            HistoricoPredioPeticiones = new HistoricoPredioPeticiones(cliente);
        }

        public async Task<Response<List<HistoricoPredio>>> SelectAll(string token, FiltroHistoricoPredio filtroHistoricoPredio)
        {
            Response<List<HistoricoPredio>> response = await HistoricoPredioPeticiones.consultarHistoricosPredios(token, filtroHistoricoPredio);
            if(response.Status.Exito == 1)
            {
                for(int i = 0; i < response.Data.Count; i++)
                {
                    if (response.Data[i].Cuenta != null)
                    {
                        response.Data[i].Cuenta.NombreUsuario = Codificador.Decrypt(response.Data[i].Cuenta.NombreUsuario);
                    }
                }
            }
            return response;
        }
    }
}
