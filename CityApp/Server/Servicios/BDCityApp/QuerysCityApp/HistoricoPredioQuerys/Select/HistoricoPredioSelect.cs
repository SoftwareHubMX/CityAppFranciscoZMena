using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.HistoricoPredioQuerys.Select
{
    public class HistoricoPredioSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<HistoricoPredio> SelectCityApp = new SelectCityApp<HistoricoPredio>();

        public HistoricoPredioSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<HistoricoPredio> SelectHistoricoPredioIdHistoricoPredio(int idHistoricoPredio)
        {
            Response<HistoricoPredio> response = new Response<HistoricoPredio>();

            try
            {
                response.Data = CityAppContext.HistoricosPredios.Where(d => d.IdHistoricoPredio == idHistoricoPredio).First();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
