using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.Fichero
{
    public class RenombrarCarpeta
    {
        public Response<object> Renombrar(string ruta, string nuevaRuta)
        {
            Response<object> response = new Response<object>();

            try
            {
                if (Directory.Exists(ruta))
                {
                    Directory.Move(ruta, nuevaRuta);


                    if (Directory.Exists(nuevaRuta))
                    {
                        response.Status.Exito = 1;
                    }
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
