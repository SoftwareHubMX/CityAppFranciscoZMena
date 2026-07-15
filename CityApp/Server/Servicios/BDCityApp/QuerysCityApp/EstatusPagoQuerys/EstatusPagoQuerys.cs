using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EstatusPagoQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EstatusPagoQuerys
{
    public class EstatusPagoQuerys
    {
        private EstatusPagosSelect EstatusPagoSelect;

        public EstatusPagoQuerys(CityAppContext cityAppContext)
        {
            EstatusPagoSelect = new EstatusPagosSelect(cityAppContext);
        }

        public Response<IEnumerable<EstatusPago>> SelectEstatusPagos()
        {
            return EstatusPagoSelect.SelectEstatusPagos();
        }

        public Response<EstatusPago> SelectEstatusPagoIdEstatusPago(int idEstatusPago)
        {
            return EstatusPagoSelect.SelectEstatusPagoIdEstatusPago(idEstatusPago);
        }
    }
}
