using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AlertaQuerys;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.AlertaLogic
{
    public class ConsultarAlertasUsuarioLogic
    {
        private AlertaQuerys AlertaQuerys;

        private int IdCuenta;

        private int IdEstatusAlerta;
        private List<Alerta> Alertas;

        public ConsultarAlertasUsuarioLogic(CityAppContext cityAppContex, int idCuenta, int idEstatusAlerta)
        {
            AlertaQuerys = new AlertaQuerys(cityAppContex);

            IdCuenta = idCuenta;

            idEstatusAlerta = idEstatusAlerta;
        }

        public Response<List<Alerta>> Consultar()
        {
            Response<List<Alerta>> response = new Response<List<Alerta>>();

            Response<IEnumerable<Alerta>> responseReportesCiudadanos = AlertaQuerys.SelectAlertasIdCuenta(IdCuenta, IdEstatusAlerta);
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
