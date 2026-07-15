using CityApp.Client.Services.ApiRest.NormatividadPeticiones;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Components.Forms;

namespace CityApp.Client.Logic.CardNuevaNormatividadLogic
{
    public class UploadArchivo
    {
        private NormatividadPeticiones NormatividadPeticiones;

        public UploadArchivo(HttpClient cliente)
        {
            NormatividadPeticiones = new NormatividadPeticiones(cliente);
        }

        public async Task<Response<string>> Upload(string token, MultipartFormDataContent content)
        {
            Response<string> response = await NormatividadPeticiones.agregarArchivoNormatividad(content, token);
            return response;
        }
    }
}
