using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.Fichero
{
    public class EliminarArchivo
    {
        public Response<object> Eliminar(string ruta)
        {
            Response<object> response = new Response<object>();

            try
            {
                if (File.Exists(ruta))
                {
                    System.IO.File.Delete(ruta);
                }
                response.Status.Exito = 1;
            }
            catch (Exception ex)
            {
                response.Status.Exception = ex.Message;
                response.Status.Mensaje = "Ocurrio un error al eliminar el archivo";
            }

            return response;
        }
    }
}
