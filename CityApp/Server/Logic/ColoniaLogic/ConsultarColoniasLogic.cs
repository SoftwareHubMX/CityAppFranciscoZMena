using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ColoniaLogic
{
    public class ConsultarColoniasLogic
    {
        private ColoniaQuerys ColoniaQuerys;
        private List<Colonia> Colonia;

        public ConsultarColoniasLogic(CityAppContext cityAppContex)
        {
            ColoniaQuerys = new ColoniaQuerys(cityAppContex);
        }

        public Response<List<Colonia>> Consultar()
        {
            Response<List<Colonia>> response = new Response<List<Colonia>>();

            Response<IEnumerable<Colonia>> responseColonia = ColoniaQuerys.SelectColonias();
            response.Status = responseColonia.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = new List<Colonia>();
                response.Data = responseColonia.Data.ToList();
            }

            return response;
        }
    }
}
