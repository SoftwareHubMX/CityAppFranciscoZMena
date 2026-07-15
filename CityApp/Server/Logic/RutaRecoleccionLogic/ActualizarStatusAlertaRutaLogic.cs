using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AlertaRutaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.StatusAlertaRutaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.RutaRecoleccionLogic
{
    public class ActualizarStatusAlertaRutaLogic
    {
        private AlertaRutaQuerys AlertaRutaQuerys;
        private StatusAlertaRutaQuerys StatusAlertaRutaQuerys;

        private int IdAlertaRuta;
        private int IdStatusAlertaRuta;

        public ActualizarStatusAlertaRutaLogic(CityAppContext cityAppContext, int idAlertaRuta, int idStatusAlertaRuta)
        {
            AlertaRutaQuerys = new AlertaRutaQuerys(cityAppContext);
            StatusAlertaRutaQuerys = new StatusAlertaRutaQuerys(cityAppContext);

            IdAlertaRuta = idAlertaRuta;
            IdStatusAlertaRuta = idStatusAlertaRuta;
        }

        public Response<object> Actualizar()
        {
            Response<object> response = new Response<object>();

            Response<AlertaRuta> responseAlertaRuta = AlertaRutaQuerys.SelectAlertaRutaIdAlertaRuta(IdAlertaRuta);
            response.Status = responseAlertaRuta.Status;
            if (response.Status.Exito == 1)
            {
                Response<StatusAlertaRuta> responseStatusAlerta = StatusAlertaRutaQuerys.SelectStatusAlertaRutaIdStatusAlertaRuta(IdStatusAlertaRuta);
                if (responseStatusAlerta.Status.Exito == 1)
                {
                    responseAlertaRuta.Data.IdStatusAlertaRuta = IdStatusAlertaRuta;
                    responseAlertaRuta.Data.StatusAlertaRuta = responseStatusAlerta.Data;
                    response = AlertaRutaQuerys.UpdateAlertaRuta(responseAlertaRuta.Data);
                }
            }

            return response;
        }
    }
}
