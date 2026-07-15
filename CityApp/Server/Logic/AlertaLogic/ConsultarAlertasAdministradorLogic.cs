using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AlertaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.AlertaLogic
{
    public class ConsultarAlertasAdministradorLogic
    {
        private AlertaQuerys AlertaQuerys;
        private List<Alerta> Alertas;
        private int idEstatusAlerta = 0;

        public ConsultarAlertasAdministradorLogic(CityAppContext cityAppContex, int IdEstatusAlerta)
        {
            AlertaQuerys = new AlertaQuerys(cityAppContex);
            idEstatusAlerta = IdEstatusAlerta;
        }

        public Response<List<Alerta>> Consultar()
        {
            Response<List<Alerta>> response = new Response<List<Alerta>>();

            Response<IEnumerable<Alerta>> responseReportesCiudadanos = AlertaQuerys.SelectAlertas(idEstatusAlerta);
            response.Status = responseReportesCiudadanos.Status;
            if (response.Status.Exito == 1)
            {
                Alertas = responseReportesCiudadanos.Data.ToList();
                response.Data = Alertas;
                response.Info = responseReportesCiudadanos.Info;
            }

            return response;
        }
    }
}
