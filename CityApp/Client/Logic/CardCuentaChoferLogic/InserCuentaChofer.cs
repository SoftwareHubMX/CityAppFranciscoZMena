using CityApp.Client.Services.ApiRest.CuentaPeticiones;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.ControllersModels.CuentaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardCuentaChoferLogic
{
    public class InserCuentaChofer
    {
        private CuentaPeticiones CuentaPeticiones;
        private Codificador Codificador = new Codificador();

        public InserCuentaChofer(HttpClient cliente)
        {
            CuentaPeticiones = new CuentaPeticiones(cliente);
        }

        public async Task<Response<object>> Insert(CrearCuenta crearCuenta)
        {
            CrearCuenta crearCuentaEncrypt = new CrearCuenta();
            if (crearCuenta.Usuario != "NA" && crearCuenta.Usuario != "")
            {
                crearCuentaEncrypt.Usuario = Codificador.Encrypt(crearCuenta.Usuario.ToLower());
            }
            if (crearCuenta.Password != "NA" && crearCuenta.Password != "")
            {
                crearCuentaEncrypt.Password = Codificador.EncryptKey(crearCuenta.Password);
            }
            Response<object> response = await CuentaPeticiones.crearCuentaChofer(crearCuentaEncrypt);
            return response;
        }
    }
}
