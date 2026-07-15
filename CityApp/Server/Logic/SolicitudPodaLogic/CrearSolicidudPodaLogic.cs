using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SolicitudPodaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.SolicitudPodaLogic
{
    public class CrearSolicidudPodaLogic
    {
        private SolicitudPodaQuerys SolicitudPodaQuerys;

        private SolicitudPoda SolicitudPoda = new SolicitudPoda();

        public CrearSolicidudPodaLogic(CityAppContext cityAppContext, SolicitudPoda solicitudPoda)
        {
            SolicitudPodaQuerys = new SolicitudPodaQuerys(cityAppContext);

            SolicitudPoda = solicitudPoda;
        }

        public Response<int> Crear()
        {
            Response<int> response = new Response<int>();

            Response<object> responseInsert = new Response<object>();
            responseInsert = SolicitudPodaQuerys.InsertSolicitudPoda(SolicitudPoda);
            response.Status = responseInsert.Status;
            if (response.Status.Exito == 1)
            {
                Response<SolicitudPoda> responseColonia = new Response<SolicitudPoda>();
                responseColonia = SolicitudPodaQuerys.SelectLastIdSolicitudPoda();
                response.Status = responseColonia.Status;
                if (response.Status.Exito == 1)
                {
                    response.Data = responseColonia.Data.IdSolicitudPoda;
                }

            }
            return response;
        }
    }
}
