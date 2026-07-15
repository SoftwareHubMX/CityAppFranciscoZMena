using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoAlertaRutaQuerys.Select
{
    public class TipoAlertaRutaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<TipoAlertaRuta> SelectCityApp = new SelectCityApp<TipoAlertaRuta>();

        public TipoAlertaRutaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<TipoAlertaRuta> SelectTipoAlertaRuta(int idTipoAlertaRuta)
        {
            Response<TipoAlertaRuta> response = new Response<TipoAlertaRuta>();

            try
            {
                response.Data = CityAppContext.TiposAlertaRuta.Where(d => d.IdTipoAlertaRuta == idTipoAlertaRuta).First();

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
