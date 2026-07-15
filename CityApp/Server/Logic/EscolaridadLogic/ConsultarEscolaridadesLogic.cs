using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EscolaridadQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.EscolaridadLogic
{
    public class ConsultarEscolaridadesLogic
    {
        private EscolaridadQuerys EscolaridadQuerys;

        public ConsultarEscolaridadesLogic(CityAppContext cityAppContext)
        {
            EscolaridadQuerys = new EscolaridadQuerys(cityAppContext);
        }

        public Response<List<Escolaridad>> Consultar()
        {
            Response<List<Escolaridad>> response = new Response<List<Escolaridad>>();

            Response<IEnumerable<Escolaridad>> responseEscolaridad = EscolaridadQuerys.SelectEscolaridades();
            response.Status = responseEscolaridad.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = responseEscolaridad.Data.ToList();
            }
            return response;
        }
    }
}
