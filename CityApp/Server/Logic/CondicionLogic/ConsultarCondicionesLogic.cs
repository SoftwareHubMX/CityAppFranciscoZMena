using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CondicionQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.CondicionLogic
{
    public class ConsultarCondicionesLogic
    {
        private CondicionQuerys CondicionQuerys;

        public ConsultarCondicionesLogic(CityAppContext cityAppContext)
        {
            CondicionQuerys = new CondicionQuerys(cityAppContext);
        }

        public Response<List<Condicion>> Consultar()
        {
            Response<List<Condicion>> response = new Response<List<Condicion>>();

            Response<IEnumerable<Condicion>> responseCondicion = CondicionQuerys.SelectCondiciones();
            response.Status = responseCondicion.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = responseCondicion.Data.ToList();
            }
            return response;
        }
    }
}
