using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.BolsaTrabajoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.BolsaTrabajoLogic
{
    public class ConsultarBolsasTrabajosLogic
    {
        private BolsaTrabajoQuerys BolsaTrabajoQuerys;
        private List<BolsaTrabajo> BolsaTrabajo;
        
        public ConsultarBolsasTrabajosLogic(CityAppContext cityAppContex)
        {
            BolsaTrabajoQuerys = new BolsaTrabajoQuerys(cityAppContex);
            
        }
        public Response<List<BolsaTrabajo>> Consultar()
        {
            Response<List<BolsaTrabajo>> response = new Response<List<BolsaTrabajo>>();

            Response<IEnumerable<BolsaTrabajo>> responseBolsaTrabajo = BolsaTrabajoQuerys.SelectBolsasTrabajos();
            response.Status = responseBolsaTrabajo.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = new List<BolsaTrabajo>();
                response.Data = responseBolsaTrabajo.Data.ToList();
            }

            return response;
        }
    }
}
