using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.Fichero
{
    public class GuardarArchivo
    {
        public async Task<Response<object>> Guardar(IFormFile file, string ruta)
        {
            Response<object> response = new Response<object>();

            try
            {
                if (file != null)
                {
                    using var stream = System.IO.File.Create(ruta);

                    file.CopyToAsync(stream).Wait();
                    stream.Close();
                    stream.Dispose();

                    response.Status.Exito = 1;
                }
                else
                {
                    response.Status.Exito = 2;
                    response.Status.Mensaje = "El archivo es nulo";
                }
            }
            catch (Exception ex)
            {
                response.Status.Exception = ex.Message;
                response.Status.Mensaje = "Ocurrió un error al cargar el archivo";
            }

            return response;
        }
    }
}
