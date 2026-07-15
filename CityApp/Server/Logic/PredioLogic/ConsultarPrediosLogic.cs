using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PredioQuerys;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PredioEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.PredioLogic
{
    public class ConsultarPrediosLogic
    {
        private PredioQuerys PredioQuerys;

        private Paginado<Predio> Paginado = new Paginado<Predio>();

        private FiltroPredios FiltroPredios;

        public ConsultarPrediosLogic(CityAppContext cityAppContext, FiltroPredios filtroPredios)
        {
            PredioQuerys = new PredioQuerys(cityAppContext);

            FiltroPredios = filtroPredios;
        }

        public Response<List<Predio>> Consultar()
        {
            Response<List<Predio>> response = new Response<List<Predio>>();

            Response<IEnumerable<Predio>> responsePredios = PredioQuerys.SelectPrediosFiltros(FiltroPredios);
            response.Status = responsePredios.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = responsePredios.Data.ToList();
                response.Info = responsePredios.Info;
            }

            return response;
        }
    }
}
