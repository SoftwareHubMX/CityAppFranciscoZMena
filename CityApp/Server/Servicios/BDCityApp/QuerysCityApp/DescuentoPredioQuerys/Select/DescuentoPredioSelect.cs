using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DescuentoPredioQuerys.Select
{
    public class DescuentoPredioSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<DescuentoPredio> SelectCityApp = new SelectCityApp<DescuentoPredio>();

        public DescuentoPredioSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<DescuentoPredio> SelectDescuentoPredioIdDescuentoPredio(int idDescuentoPredio)
        {
            Response<DescuentoPredio> response = new Response<DescuentoPredio>();

            try
            {
                response.Data = CityAppContext.DescuentosPredios.Where(d => d.IdDescuentoPredio == idDescuentoPredio).FirstOrDefault();

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
