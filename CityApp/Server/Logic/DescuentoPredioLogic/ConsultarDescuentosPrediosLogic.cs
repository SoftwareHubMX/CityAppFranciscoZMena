using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DescuentoPredioQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.DescuentoPredioEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.DescuentoPredioLogic
{
    public class ConsultarDescuentosPrediosLogic
    {
        private DescuentoPredioQuerys DescuentoPredioQuerys;

        private FiltroDescuentoPredios FiltroDescuentoPredios = new FiltroDescuentoPredios();

        public ConsultarDescuentosPrediosLogic(CityAppContext cityAppContext, FiltroDescuentoPredios filtroDescuentoPredios)
        {
            DescuentoPredioQuerys = new DescuentoPredioQuerys(cityAppContext);

            FiltroDescuentoPredios = filtroDescuentoPredios;
        }

        public Response<List<DescuentoPredio>> Consultar()
        {
            Response<List<DescuentoPredio>> response = new Response<List<DescuentoPredio>>();

            Response<IEnumerable<DescuentoPredio>> responseList = new Response<IEnumerable<DescuentoPredio>>();
            responseList = DescuentoPredioQuerys.SelectDescuentosPredios(FiltroDescuentoPredios);
            response.Status = responseList.Status;
            if(response.Status.Exito == 1)
            {
                response.Data = new List<DescuentoPredio>();
                response.Data = responseList.Data.ToList();
                response.Info = responseList.Info;
            }
            return response;
        }
    }
}
