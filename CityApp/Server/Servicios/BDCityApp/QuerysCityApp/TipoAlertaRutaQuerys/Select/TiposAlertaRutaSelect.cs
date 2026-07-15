using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoAlertaRutaQuerys.Select
{
    public class TiposAlertaRutaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<TipoAlertaRuta> SelectCityApp = new SelectCityApp<TipoAlertaRuta>();

        public TiposAlertaRutaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<TipoAlertaRuta>> SelectTiposAlertaRuta()
        {
            Response<IEnumerable<TipoAlertaRuta>> response = new Response<IEnumerable<TipoAlertaRuta>>();

            try
            {
                response.Data = CityAppContext.TiposAlertaRuta;

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
