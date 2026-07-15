using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PredioQuerys.Select
{
    public class IdPredioSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<int> SelectCityApp = new SelectCityApp<int>();

        public IdPredioSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<int> SelectIdPredioClaves(string clave, string claveCatastral)
        {
            Response<int> response = new Response<int>();

            try
            {
                response.Data = (from data in CityAppContext.Predios
                                 orderby data.IdPredio
                                 where data.Clave == clave 
                                 && data.ClaveCatastral == claveCatastral 
                                 select data.IdPredio).Last();

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
