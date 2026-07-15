using CityApp.Shared.Models.DataValuesModels;
using Newtonsoft.Json;

namespace CityApp.Server.Servicios.PeticionesAPI
{
    public class POST<I, O>
    {
        public async Task<Response<O>> PostData(string url, I data)
        {
            Response<O> response = new Response<O>();

            try
            {
                HttpClient client = new HttpClient();

                var request = await client.PostAsJsonAsync<I>(url, data);

                if (request.IsSuccessStatusCode)
                {
                    string result = request.Content.ReadAsStringAsync().Result.ToString();

                    response.Data = JsonConvert.DeserializeObject<O>(result);

                    response.Status.Exito = 1;
                }
                else
                {
                    response.Status.Mensaje = "La peticion retorno un status code no valido: \n"
                        + request.Content.ReadAsStringAsync().Result.ToString();

                    response.Status.Exito = 2;
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
