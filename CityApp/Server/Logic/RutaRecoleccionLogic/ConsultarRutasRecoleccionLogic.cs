using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RutaRecoleccionQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.RutaRecoleccionLogic
{
    public class ConsultarRutasRecoleccionLogic
    {
        private RutaRecoleccionQuerys RutaRecoleccionQuerys;
        private List<RutaRecoleccion> RutaRecoleccion;

        public ConsultarRutasRecoleccionLogic(CityAppContext cityAppContex)
        {
            RutaRecoleccionQuerys = new RutaRecoleccionQuerys(cityAppContex);

        }
        public Response<List<RutaRecoleccion>> Consultar()
        {
            Response<List<RutaRecoleccion>> response = new Response<List<RutaRecoleccion>>();

            Response<IEnumerable<RutaRecoleccion>> responseRuta = RutaRecoleccionQuerys.SelectRutasRecoleccion();
            response.Status = responseRuta.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = new List<RutaRecoleccion>();
                response.Data = responseRuta.Data.ToList();
            }

            return response;
        }
    }
}
