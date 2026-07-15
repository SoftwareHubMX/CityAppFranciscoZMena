using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NormatividadQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.NormatividadLogic
{
    public class EliminarNormatividadLogic
    {
        private NormatividadQuerys NormatividadQuerys;
        private int IdNormatividad = 0;

        public EliminarNormatividadLogic(CityAppContext cityAppContext, int idNormatividad)
        {
            NormatividadQuerys = new NormatividadQuerys(cityAppContext);

            IdNormatividad = idNormatividad;
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();

            Response<Normatividad> responseNormatividad = new Response<Normatividad>();
            responseNormatividad = NormatividadQuerys.SelectNormatividad(IdNormatividad);
            response.Status = responseNormatividad.Status;
            if (response.Status.Exito == 1)
            {
                response = NormatividadQuerys.DeleteNormatividad(responseNormatividad.Data);
            }
            return response;
        }
    }
}
