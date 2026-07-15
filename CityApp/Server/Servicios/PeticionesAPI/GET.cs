using CityApp.Shared.Models.DataValuesModels;
using Newtonsoft.Json;

namespace CityApp.Server.Servicios.PeticionesAPI
{
    public class GET<T>
    {
        public Response<T> GetData(string url)
        {
            Response<T> response = new Response<T>();

            try
            {
                HttpClient client = new HttpClient();

                var request = client.GetAsync(url).Result;

                if (request.IsSuccessStatusCode)
                {
                    string result = request.Content.ReadAsStringAsync().Result.ToString();

                    response.Data = JsonConvert.DeserializeObject<T>(result);

                    response.Status.Exito = 1;
                }
                else
                {
                    response.Status.Exito = 2;
                    response.Status.Mensaje = "Ocurrio un error al realizar la peticion a " + url;
                }

                client.Dispose();
            }
            catch (Exception ex)
            {
                response.Status.Exception = ex.Message;
                response.Status.Mensaje = "Ocurrio un error al realizar la peticion a " + url;
            }

            return response;
        }
    }
}
