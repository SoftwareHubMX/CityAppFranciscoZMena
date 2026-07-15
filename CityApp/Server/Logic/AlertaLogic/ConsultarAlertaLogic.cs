using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AlertaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.AlertaLogic
{
    public class ConsultarAlertaLogic
    {
        private AlertaQuerys AlertaQuerys;
        private int IdAlerta;

        public ConsultarAlertaLogic(CityAppContext cityAppContex, int idAlerta)
        {
            AlertaQuerys = new AlertaQuerys(cityAppContex);

            IdAlerta = idAlerta;
        }

        public Response<Alerta> Consultar()
        {
            Response<Alerta> response = new Response<Alerta>();

            response = AlertaQuerys.SelectAlertaIdAlerta(IdAlerta);

            return response;
        }
    }
}
