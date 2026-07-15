using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.ConexionCityApp
{
    public class InsertCityApp<T>
    {
        private CityAppContext CityAppContext;

        public InsertCityApp(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<object> Save(T data)
        {
            Response<object> response = new Response<object>();

            try
            {
                CityAppContext.Add(data);
                CityAppContext.SaveChanges();

                response.Status.Exito = 1;
                response.Status.Mensaje = "Ok";
            }
            catch (Exception ex)
            {
                response.Status.Exception = ex.Message;
                response.Status.Mensaje = "Ocurrio un error";
            }

            return response;
        }
    }
}
