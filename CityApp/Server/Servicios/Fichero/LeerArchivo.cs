using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.Fichero
{
    public class LeerArchivo
    {
        public Response<byte[]> Leer(string ruta)
        {
            Response<byte[]> response = new Response<byte[]>();

            try
            {
                if (File.Exists(ruta))
                {
                    byte[] arrayBytes = System.IO.File.ReadAllBytes(ruta);
                    response.Data = arrayBytes;
                    response.Status.Exito = 1;
                }
                else
                {
                    response.Status.Exito = 2;
                    response.Status.Mensaje = "No se encontro el archivo";
                }
            }
            catch (Exception ex)
            {
                response.Status.Exception = ex.Message;
                response.Status.Mensaje = "Ocurrio un error al leer el fichero: " + ruta;
            }

            return response;
        }
    }
}
