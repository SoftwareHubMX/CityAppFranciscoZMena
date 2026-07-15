using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PredioQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PredioEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.PredioLogic
{
    public class CrearPredioLogic
    {
        private PredioQuerys PredioQuerys;

        private Predio Predio = new Predio();

        public CrearPredioLogic(CityAppContext cityAppContext, Predio predio)
        {
            PredioQuerys = new PredioQuerys(cityAppContext);

            Predio = predio;
        }

        public Response<int> Crear()
        {
            Response<int> response = new Response<int>();

            Response<object> responsePredio = PredioQuerys.InsertPredio(Predio);
            response.Status = responsePredio.Status;
            if (response.Status.Exito == 1)
            {
                response = PredioQuerys.SelectIdPredioClaves(Predio.Clave, Predio.ClaveCatastral);
            }

            return response;
        }
    }
}
