using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AlertaRutaQuerys.Select
{
    public class AlertaRutaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<AlertaRuta> SelectCityApp = new SelectCityApp<AlertaRuta>();

        public AlertaRutaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<AlertaRuta> SelectAlertaRutaIdAlertaRuta(int idAlertaRuta)
        {
            Response<AlertaRuta> response = new Response<AlertaRuta>();

            try
            {
                response.Data = (from data in CityAppContext.AlertasRutas
                                 orderby data.IdAlertaRuta
                                 where data.IdAlertaRuta == idAlertaRuta
                                 select new AlertaRuta()
                                 {
                                     IdAlertaRuta = data.IdAlertaRuta,
                                     FechaAlerta = data.FechaAlerta,
                                     IdTipoAlertaRuta = data.IdTipoAlertaRuta,
                                     TiposAlertaRuta = data.TiposAlertaRuta,
                                     IdStatusAlertaRuta = data.IdStatusAlertaRuta,
                                     StatusAlertaRuta = data.StatusAlertaRuta,
                                     IdRutaRecoleccion = data.IdRutaRecoleccion,
                                     RutaRecoleccion = data.RutaRecoleccion

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
