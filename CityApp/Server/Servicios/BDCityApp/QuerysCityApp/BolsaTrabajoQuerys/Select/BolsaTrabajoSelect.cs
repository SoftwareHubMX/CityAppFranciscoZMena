using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.BolsaTrabajoQuerys.Select
{
    public class BolsaTrabajoSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<BolsaTrabajo> SelectCityApp = new SelectCityApp<BolsaTrabajo>();

        public BolsaTrabajoSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }
        public Response<BolsaTrabajo> SelectBolsaTrabajoIdBolsaTrabajo(int idBolsaTrabajo)
        {
            Response<BolsaTrabajo> response = new Response<BolsaTrabajo>();

            try
            {
                response.Data = CityAppContext.BolsasTrabajos.Where(d => d.IdBolsaTrabajo == idBolsaTrabajo).First();
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
