using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DescuentoPredioQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.DescuentoPredioLogic
{
    public class CrearDescuentoPredioLogic
    {
        private DescuentoPredioQuerys DescuentoPredioQuerys;

        private DescuentoPredio DescuentoPredio = new DescuentoPredio();


        public CrearDescuentoPredioLogic(CityAppContext cityAppContext, DescuentoPredio descuentoPredio)
        {
            DescuentoPredioQuerys = new DescuentoPredioQuerys(cityAppContext);

            DescuentoPredio = descuentoPredio;
        }

        public Response<object> Crear()
        {
            return DescuentoPredioQuerys.InsertDescuentoPredio(DescuentoPredio);
        }
    }
}
