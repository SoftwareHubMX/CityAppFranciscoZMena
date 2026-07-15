using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.BolsaTrabajoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.BolsaTrabajoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.BolsaTrabajoLogic
{
    public class ConsultarFiltroBolsaTrabajoLogic
    {
        private BolsaTrabajoQuerys BolsaTrabajoQuerys;
        private FiltroBolsaTrabajo FiltroBolsaTrabajo;
        private List<BolsaTrabajo> BolsaTrabajo;

        public ConsultarFiltroBolsaTrabajoLogic(CityAppContext cityAppContetx, FiltroBolsaTrabajo filtroBolsaTrabajo)
        {
            BolsaTrabajoQuerys = new BolsaTrabajoQuerys(cityAppContetx);
            FiltroBolsaTrabajo = filtroBolsaTrabajo;
        }
        public Response<List<BolsaTrabajo>> Consultar()
        {
            Response<List<BolsaTrabajo>> response = new Response<List<BolsaTrabajo>>();

            Response<IEnumerable<BolsaTrabajo>> responseBolsaTrabajo = BolsaTrabajoQuerys.SelectBolsaTrabajoFiltroBolsaTrabajo(FiltroBolsaTrabajo);
            response.Status = responseBolsaTrabajo.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = new List<BolsaTrabajo>();
                response.Data = responseBolsaTrabajo.Data.ToList();
                response.Info = new Info();
                response.Info = responseBolsaTrabajo.Info;

            }


            return response;
        }
    }
}
