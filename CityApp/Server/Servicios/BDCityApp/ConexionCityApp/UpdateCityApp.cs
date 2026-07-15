using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.ConexionCityApp
{
    public class UpdateCityApp<T>
    {
        private CityAppContext CityAppContext;

        public UpdateCityApp(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<object> Save(T data)
        {
            Response<object> response = new Response<object>();

            try
            {
                CityAppContext.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
