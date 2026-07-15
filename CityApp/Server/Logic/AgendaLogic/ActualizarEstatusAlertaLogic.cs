using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AlertaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EstatusAlertaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.AgendaLogic
{
    public class ActualizarEstatusAlertaLogic
    {
        private AlertaQuerys AlertaQuerys;
        private EstatusAlertaQuerys EstatusAlertaQuerys;

        private int IdAlerta;
        private int IdEstatusAlerta;

        public ActualizarEstatusAlertaLogic(CityAppContext cityAppContext, int idAlerta, int idEstatusAlerta)
        {
            AlertaQuerys = new AlertaQuerys(cityAppContext);
            EstatusAlertaQuerys = new EstatusAlertaQuerys(cityAppContext);

            IdAlerta = idAlerta;
            IdEstatusAlerta = idEstatusAlerta;
        }

        public Response<object> Actualizar()
        {
            Response<object> response = new Response<object>();

            Response<Alerta> responseAlerta = AlertaQuerys.SelectAlertaIdAlerta(IdAlerta);
            response.Status = responseAlerta.Status;
            if (response.Status.Exito == 1)
            {
                Response<EstatusAlerta> responseEstatusAlerta = EstatusAlertaQuerys.SelectEstatusAlertaIdEstatusAlerta(IdEstatusAlerta);
                if(responseEstatusAlerta.Status.Exito == 1)
                {
                    responseAlerta.Data.IdEstatusAlerta = IdEstatusAlerta;
                    responseAlerta.Data.EstatusAlerta = responseEstatusAlerta.Data;
                    response = AlertaQuerys.UpdateAlerta(responseAlerta.Data);
                }
            }

            return response;
        }
    }
}
