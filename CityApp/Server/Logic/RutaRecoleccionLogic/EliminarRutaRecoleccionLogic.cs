using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RutaRecoleccionQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.RutaRecoleccionLogic
{
    public class EliminarRutaRecoleccionLogic
    {
        private RutaRecoleccionQuerys RutaRecoleccionQuerys;

        private int IdRutaRecoleccion;

        public EliminarRutaRecoleccionLogic(CityAppContext cityAppContext, int idRutaRecoleccion)
        {
            RutaRecoleccionQuerys = new RutaRecoleccionQuerys(cityAppContext);

            IdRutaRecoleccion = idRutaRecoleccion;
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();

            Response<RutaRecoleccion> responseRutaRecoleccion = RutaRecoleccionQuerys.SelectRutaRecoleccionIdRutaRecoleccion(IdRutaRecoleccion);
            response.Status = responseRutaRecoleccion.Status;
            if (response.Status.Exito == 1)
            {
                response = RutaRecoleccionQuerys.DeleteRutaRecoleccion(responseRutaRecoleccion.Data);
            }

            return response;
        }
    }
}
