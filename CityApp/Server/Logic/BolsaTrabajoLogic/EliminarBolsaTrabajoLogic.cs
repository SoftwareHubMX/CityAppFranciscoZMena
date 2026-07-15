using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.BolsaTrabajoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.BolsaTrabajoLogic
{
    public class EliminarBolsaTrabajoLogic
    {
        private BolsaTrabajoQuerys BolsaTrabajoQuerys;

        private int IdBolsaTrabajo;

        public EliminarBolsaTrabajoLogic(CityAppContext cityAppContext, int idBolsaTrabajo)
        {
            BolsaTrabajoQuerys = new BolsaTrabajoQuerys(cityAppContext);

            IdBolsaTrabajo = idBolsaTrabajo;
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();

            Response<BolsaTrabajo> responseBolsaTrabajo = BolsaTrabajoQuerys.SelectBolsaTrabajoIdBolsaTrabajo(IdBolsaTrabajo);
            response.Status = responseBolsaTrabajo.Status;
            if (response.Status.Exito == 1)
            {
                response = BolsaTrabajoQuerys.DeleteBolsaTrabajo(responseBolsaTrabajo.Data);
            }

            return response;
        }
    }
}
