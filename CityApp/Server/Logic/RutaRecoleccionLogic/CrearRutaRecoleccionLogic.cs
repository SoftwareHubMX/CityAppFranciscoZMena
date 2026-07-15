using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RutaRecoleccionQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.RutaRecoleccionLogic
{
    public class CrearRutaRecoleccionLogic
    {
        private RutaRecoleccionQuerys RutaRecoleccionQuerys;

        private RutaRecoleccion RutaRecoleccion = new RutaRecoleccion();

        public CrearRutaRecoleccionLogic(CityAppContext cityAppContext, RutaRecoleccion rutaRecoleccion)
        {
            RutaRecoleccionQuerys = new RutaRecoleccionQuerys(cityAppContext);

            RutaRecoleccion = rutaRecoleccion;
        }

        public Response<int> Crear()
        {
            Response<int> response = new Response<int>();

            Response<object> responseInsert = new Response<object>();
            responseInsert = RutaRecoleccionQuerys.InsertRutaRecoleccion(RutaRecoleccion);
            response.Status = responseInsert.Status;
            if (response.Status.Exito == 1)
            {
                Response<RutaRecoleccion> responseColonia = new Response<RutaRecoleccion>();
                responseColonia = RutaRecoleccionQuerys.SelectLastIdRutaRecoleccion();
                response.Status = responseColonia.Status;
                if (response.Status.Exito == 1)
                {
                    response.Data = responseColonia.Data.IdRutaRecoleccion;
                }

            }
            return response;
        }
    }
}
