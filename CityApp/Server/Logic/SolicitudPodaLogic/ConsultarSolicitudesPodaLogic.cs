using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitudPodaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.SolicitudPodaLogic
{
    public class ConsultarSolicitudesPodaLogic
    {
        private SolicitudPodaQuerys SolicitudPodaQuerys;
        private List<SolicitudPoda> SolicitudPoda;

        public ConsultarSolicitudesPodaLogic(CityAppContext cityAppContex)
        {
            SolicitudPodaQuerys = new SolicitudPodaQuerys(cityAppContex);

        }
        public Response<List<SolicitudPoda>> Consultar()
        {
            Response<List<SolicitudPoda>> response = new Response<List<SolicitudPoda>>();

            Response<IEnumerable<SolicitudPoda>> responseRuta = SolicitudPodaQuerys.SelectSolicitudesPoda();
            response.Status = responseRuta.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = new List<SolicitudPoda>();
                response.Data = responseRuta.Data.ToList();
            }

            return response;
        }
    }
}
