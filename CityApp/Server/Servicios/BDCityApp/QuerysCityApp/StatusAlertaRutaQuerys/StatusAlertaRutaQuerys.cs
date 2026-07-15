using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.StatusAlertaRutaQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.StatusAlertaRutaQuerys
{
    public class StatusAlertaRutaQuerys
    {
        private StatusAlertaRutaSelect StatusAlertaRutaSelect;
        private StatusAlertaRutaIdStatusAlertaRutaSelect StatusAlertaRutaIdStatusAlertaRutaSelect;

        public StatusAlertaRutaQuerys(CityAppContext cityAppContext)
        {
            StatusAlertaRutaSelect = new StatusAlertaRutaSelect(cityAppContext);
            StatusAlertaRutaIdStatusAlertaRutaSelect = new StatusAlertaRutaIdStatusAlertaRutaSelect(cityAppContext);
        }

        //select
        public Response<IEnumerable<StatusAlertaRuta>> SelectStatusAlertaRuta()
        {
            return StatusAlertaRutaSelect.SelectStatusAlertaRuta();
        }

        public Response<StatusAlertaRuta> SelectStatusAlertaRutaIdStatusAlertaRuta(int idStatusAlertaRuta)
        {
            return StatusAlertaRutaIdStatusAlertaRutaSelect.StatusAletaRutaIdStatusAlertaRuta(idStatusAlertaRuta);
        }
    }
}
