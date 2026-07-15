using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.GiroQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.GiroLogic
{
    public class ConsultarGirosLogic
    {
        private GiroQuerys GiroQuerys;

        public ConsultarGirosLogic(CityAppContext cityAppContext)
        {
            GiroQuerys = new GiroQuerys(cityAppContext);
        }

        public Response<List<Giro>> Consultar()
        {
            Response<List<Giro>> response = new Response<List<Giro>>();

            Response<IEnumerable<Giro>> responseGiros = GiroQuerys.SelectGiros();
            response.Status = responseGiros.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = responseGiros.Data.ToList();
            }
            return response;
        }
    }
}
