using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.HistoricoPredioQuerys.Select
{
    public class IdHistoricoPredioSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<int> SelectCityApp = new SelectCityApp<int>();

        public IdHistoricoPredioSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<int> SelectUltimoIdHistoricoPredioNotaActualizacion(string notaActualizacion, DateTime fechaHistorico)
        {
            Response<int> response = new Response<int>();

            try
            {
                response.Data = (from data in CityAppContext.HistoricosPredios
                                 orderby data.IdHistoricoPredio
                                 where data.NotaActualizacion == notaActualizacion
                                 && data.FechaHistorico == fechaHistorico 
                                 select data.IdHistoricoPredio).LastOrDefault();

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
