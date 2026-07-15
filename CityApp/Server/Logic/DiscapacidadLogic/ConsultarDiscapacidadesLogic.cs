using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DiscapacidadQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.DiscapacidadLogic
{
    public class ConsultarDiscapacidadesLogic
    {
        private DiscapacidadQuerys DiscapacidadQuerys;

        public ConsultarDiscapacidadesLogic(CityAppContext cityAppContext)
        {
            DiscapacidadQuerys = new DiscapacidadQuerys(cityAppContext);
        }

        public Response<List<Discapacidad>> Consultar()
        {
            Response<List<Discapacidad>> response = new Response<List<Discapacidad>>();

            Response<IEnumerable<Discapacidad>> responseDiscapacidad = DiscapacidadQuerys.SelectDiscapacidades();
            response.Status = responseDiscapacidad.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = responseDiscapacidad.Data.ToList();
            }
            return response;
        }
    }
}
