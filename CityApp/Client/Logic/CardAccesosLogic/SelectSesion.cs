using CityApp.Client.Services.ApiRest.SesionPeticiones;
using CityApp.Shared.Helpers;
using CityApp.Shared.Helpers.Validaciones;
using CityApp.Shared.Models.ControllersModels.SesionEntradaModels;
using CityApp.Shared.Models.ControllersModels.SesionSalidaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardAccesosLogic
{
    public class SelectSesion
    {
        private SesionPeticiones SesionPeticiones;
        private Codificador Codificador = new Codificador();
        private Validaciones Validaciones = new Validaciones();

        public SelectSesion(HttpClient cliente)
        {
            SesionPeticiones = new SesionPeticiones(cliente);
        }

        public async Task<Response<Sesion>> Select(LoginData loginData)
        {
            LoginData loginDataEncrypt = new LoginData();
            if(loginData.Usuario != "NA" && loginData.Usuario != "")
            {
                if (Validaciones.ValidarCorreo(loginData.Usuario))
                {
                    loginDataEncrypt.Usuario = Codificador.EncryptCorreo(loginData.Usuario.ToLower());
                }
                else
                {
                    loginDataEncrypt.Usuario = Codificador.Encrypt(loginData.Usuario.ToLower());
                }
            }
            if(loginData.Password != "NA" && loginData.Password != "")
            {
                loginDataEncrypt.Password = Codificador.EncryptKey(loginData.Password);
            }
            loginDataEncrypt.IdTipoTokenLogin = 1;
            Response<Sesion> response = await SesionPeticiones.consultarSesion(loginDataEncrypt);
            if (response.Status.Exito == 1)
            {
                if (Validaciones.ValidarCorreo(loginData.Usuario))
                {
                    response.Data.NombreUsuario = Codificador.DecryptCorreo(response.Data.NombreUsuario);
                }
                else
                {
                    response.Data.NombreUsuario = Codificador.Decrypt(response.Data.NombreUsuario);
                }
            }
            return response;
        }

    }
}
