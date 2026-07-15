using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.StatusAlertaRutaQuerys.Select
{
    public class StatusAlertaRutaIdStatusAlertaRutaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<StatusAlertaRuta> SelectCityApp = new SelectCityApp<StatusAlertaRuta>();

        public StatusAlertaRutaIdStatusAlertaRutaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<StatusAlertaRuta> StatusAletaRutaIdStatusAlertaRuta(int idStatusAlertaRuta)
        {
            Response<StatusAlertaRuta> response = new Response<StatusAlertaRuta>();

            try
            {
                response.Data = (from data in CityAppContext.StatusAlertasRuta
                                 orderby data.IdStatusAlertaRuta
                                 where data.IdStatusAlertaRuta == idStatusAlertaRuta
                                 select new StatusAlertaRuta()
                                 {
                                     IdStatusAlertaRuta = data.IdStatusAlertaRuta,
                                     StatusAlerta = data.StatusAlerta,
                                 }).FirstOrDefault();

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
