using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.TokenActualizarPasswordPeticiones
{
    public class TokenActualizarPasswordPeticiones
    {
        private CrearTokenActualizarPassword CrearTokenActualizarPassword;

        public TokenActualizarPasswordPeticiones(HttpClient cliente)
        {
            CrearTokenActualizarPassword = new CrearTokenActualizarPassword(cliente);
        }

        public async Task<Response<object>> crearTokenActualizarPassword(string correo)
        {
            Response<object> response = await CrearTokenActualizarPassword.CrearTokenActualizarPasswordAsync(correo);
            return response;
        }
    }
}
