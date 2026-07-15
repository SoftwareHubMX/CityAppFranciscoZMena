using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoHistoricoPredioQuerys.Select
{
    public class ArchivoHistoricosPrediosSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<ArchivoHistoricoPredio> SelectCityApp = new SelectCityApp<ArchivoHistoricoPredio>();

        public ArchivoHistoricosPrediosSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<ArchivoHistoricoPredio>> SelectArchivosHistoricosPredios()
        {
            Response<IEnumerable<ArchivoHistoricoPredio>> response = new Response<IEnumerable<ArchivoHistoricoPredio>>();

            try
            {
                response.Data = CityAppContext.ArchivoHistoricoPredio.OrderByDescending(d => d.IdArchivoHistoricoPredio);

                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
