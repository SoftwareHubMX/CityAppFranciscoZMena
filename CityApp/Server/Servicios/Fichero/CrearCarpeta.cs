using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.Fichero
{
    public class CrearCarpeta
    {
        public Response<object> Crear(string ruta)
        {
            Response<object> response = new Response<object>();

            try
            {
                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }
                response.Status.Exito = 1;
            }
            catch (Exception ex)
            {
                response.Status.Exception = ex.Message;
                response.Status.Mensaje = "Ocurio un error al crear la carpeta";
            }

            return response;
        }
    }
}
