using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.Fichero
{
    public class CopiarArchivo
    {
        public Response<object> Copiar(string rutaI, string rutaO)
        {
            Response<object> response = new Response<object>();

            try
            {
                if (File.Exists(rutaI))
                {
                    File.Copy(rutaI, rutaO, true);
                }
                response.Status.Exito = 1;
            }
            catch (Exception ex)
            {
                response.Status.Exception = ex.Message;
                response.Status.Mensaje = "Ocurrio un error al copiar el archivo";
            }

            return response;
        }
    }
}
