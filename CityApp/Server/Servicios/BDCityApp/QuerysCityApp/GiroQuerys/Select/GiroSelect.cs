using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.GiroQuerys.Select
{
    public class GiroSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Giro> SelectCityApp = new SelectCityApp<Giro>();

        public GiroSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<Giro> SelectGiro(int idGiro)
        {
            Response<Giro> response = new Response<Giro>();

            try
            {
                response.Data = CityAppContext.Giros.Where(d => d.IdGiro == idGiro).First();

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
