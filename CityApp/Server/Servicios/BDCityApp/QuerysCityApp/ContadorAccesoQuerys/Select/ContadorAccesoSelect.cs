using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContadorAccesoQuerys.Select
{
    public class ContadorAccesoSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<ContadorAcceso> SelectCityApp = new SelectCityApp<ContadorAcceso>();

        public ContadorAccesoSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<ContadorAcceso> SelectContadorAccesoIdCuenta(int idCuenta)
        {
            Response<ContadorAcceso> response = new Response<ContadorAcceso>();

            try
            {
                response.Data = CityAppContext.ContadoresAccesos.Where(d => d.IdCuenta == idCuenta).First();

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
