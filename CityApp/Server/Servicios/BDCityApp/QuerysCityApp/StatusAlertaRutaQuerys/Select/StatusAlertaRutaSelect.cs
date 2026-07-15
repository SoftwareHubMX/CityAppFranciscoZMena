using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.StatusAlertaRutaQuerys.Select
{
    public class StatusAlertaRutaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<StatusAlertaRuta> SelectCityApp = new SelectCityApp<StatusAlertaRuta>();

        public StatusAlertaRutaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<StatusAlertaRuta>> SelectStatusAlertaRuta()
        {
            Response<IEnumerable<StatusAlertaRuta>> response = new Response<IEnumerable<StatusAlertaRuta>>();

            try
            {
                response.Data = CityAppContext.StatusAlertasRuta;

                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
