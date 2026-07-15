using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DescuentoPredioQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.DescuentoPredioLogic
{
    public class EliminarDescuentoPredioLogic
    {
        private DescuentoPredioQuerys DescuentoPredioQuerys;

        private int IdDescuentoPredio = 0;

        public EliminarDescuentoPredioLogic(CityAppContext cityAppContext, int idDescuentoPredio)
        {
            DescuentoPredioQuerys = new DescuentoPredioQuerys(cityAppContext);

            IdDescuentoPredio = idDescuentoPredio;
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();

            Response<DescuentoPredio> responseDescuentoPredio = new Response<DescuentoPredio>();
            responseDescuentoPredio = DescuentoPredioQuerys.SelectDescuentoPredioIdDescuentoPredio(IdDescuentoPredio);
            response.Status = responseDescuentoPredio.Status;
            if(response.Status.Exito == 1)
            {
                response = DescuentoPredioQuerys.DeleteDescuentoPredio(responseDescuentoPredio.Data);
            }

            return response;
        }
    }
}
