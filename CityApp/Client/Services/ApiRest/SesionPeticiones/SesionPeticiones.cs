using CityApp.Shared.Models.ControllersModels.SesionEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.SesionPeticiones
{
    public class SesionPeticiones
    {
        private ConsultarSesion ConsultarSesion;

        public SesionPeticiones(HttpClient cliente)
        {
            ConsultarSesion = new ConsultarSesion(cliente);
        }

        public async Task<Response<Sesion>> consultarSesion(LoginData loginData)
        {
            Response<Sesion> response = await ConsultarSesion.ConsultarSesionAsync(loginData);
            return response;
        }
    }
}
