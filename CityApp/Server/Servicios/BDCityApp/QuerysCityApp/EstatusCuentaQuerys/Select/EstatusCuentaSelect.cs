using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EstatusCuentaQuerys.Select
{
    public class EstatusCuentaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<EstatusCuenta> SelectCityApp = new SelectCityApp<EstatusCuenta>();

        public EstatusCuentaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<EstatusCuenta> SelectEstatusCuentaIdCuenta(int idCuenta)
        {
            Response<EstatusCuenta> response = new Response<EstatusCuenta>();

            try
            {
                response.Data = CityAppContext.EstatusCuentas.Where(d => d.IdCuenta == idCuenta).First();
                
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
