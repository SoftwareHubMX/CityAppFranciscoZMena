using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.ConexionCityApp
{
    public class DeleteCityApp<T>
    {
        private CityAppContext CityAppContext;

        public DeleteCityApp(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<object> Save(T data)
        {
            Response<object> response = new Response<object>();

            try
            {
                CityAppContext.Remove(data);
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

        public Response<object> SaveMultiple(IEnumerable<T> data)
        {
            Response<object> response = new Response<object>();

            try
            {
                foreach (var d in data)
                {
                    CityAppContext.Remove(d);
                }
                
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
