using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoHistoricoPredioQuerys.Select
{
    public class ArchivoHistoricoPredioSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<ArchivoHistoricoPredio> SelectCityApp = new SelectCityApp<ArchivoHistoricoPredio>();

        public ArchivoHistoricoPredioSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<ArchivoHistoricoPredio> SelectArchivoHistoricoPredioIdArchivoHistoricoPredio(int idArchivoHistoricoPredio)
        {
            Response<ArchivoHistoricoPredio> response = new Response<ArchivoHistoricoPredio>();

            try
            {
                response.Data = CityAppContext.ArchivoHistoricoPredio.Where(d => d.IdArchivoHistoricoPredio == idArchivoHistoricoPredio).First();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<ArchivoHistoricoPredio> SelectArchivoHistoricoPredioIdHistoricoPredioPrincipal(int idHistoricoPredio)
        {
            Response<ArchivoHistoricoPredio> response = new Response<ArchivoHistoricoPredio>();

            try
            {
                response.Data = (from data in CityAppContext.ArchivoHistoricoPredio
                                 where data.IdHistoricoPredio == idHistoricoPredio
                                 && data.Principal == true
                                 select new ArchivoHistoricoPredio()
                                 {
                                     IdArchivoHistoricoPredio = data.IdHistoricoPredio,
                                     Ruta = data.Ruta,
                                     Formato = data.Formato,
                                     Principal = data.Principal,
                                     IdHistoricoPredio = data.IdHistoricoPredio,
                                     HistoricoPredio = null,
                                 }).First();


                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<ArchivoHistoricoPredio> SelectArchivoHistoricoPredioIdHistoricoPredioFirst(int idHistoricoPredio)
        {
            Response<ArchivoHistoricoPredio> response = new Response<ArchivoHistoricoPredio>();

            try
            {
                response.Data = (from data in CityAppContext.ArchivoHistoricoPredio
                                 where data.IdHistoricoPredio == idHistoricoPredio
                                 select new ArchivoHistoricoPredio()
                                 {
                                     IdArchivoHistoricoPredio = data.IdArchivoHistoricoPredio,
                                     Ruta = data.Ruta,
                                     Formato = data.Formato,
                                     Principal = data.Principal,
                                     IdHistoricoPredio = data.IdHistoricoPredio,
                                     HistoricoPredio = null,
                                 }).First();

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
