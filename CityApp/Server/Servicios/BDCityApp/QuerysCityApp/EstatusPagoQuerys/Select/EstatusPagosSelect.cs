using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EstatusPagoQuerys.Select
{
    public class EstatusPagosSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<EstatusPago> SelectCityApp = new SelectCityApp<EstatusPago>();

        public EstatusPagosSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<EstatusPago>> SelectEstatusPagos()
        {
            Response<IEnumerable<EstatusPago>> response = new Response<IEnumerable<EstatusPago>>();

            try
            {
                response.Data = CityAppContext.EstatusPago;

                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<EstatusPago> SelectEstatusPagoIdEstatusPago(int idEstatusPago)
        {
            Response<EstatusPago> response = new Response<EstatusPago>();

            try
            {
                response.Data = CityAppContext.EstatusPago.Where(d => d.IdEstatusPago == idEstatusPago).First();

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
