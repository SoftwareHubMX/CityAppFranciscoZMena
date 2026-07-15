using CityApp.Client.Services.ApiRest.CuentaPeticiones;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.ControllersModels.CuentaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.CardAccesosLogic
{
    public class InsertCuenta
    {
        private CuentaPeticiones CuentaPeticiones;
        private Codificador Codificador = new Codificador();

        public InsertCuenta(HttpClient cliente)
        {
            CuentaPeticiones = new CuentaPeticiones(cliente);
        }

        public async Task<Response<object>> Insert(CrearCuenta crearCuenta)
        {
            CrearCuenta crearCuentaEncrypt = new CrearCuenta();
            if(crearCuenta.Usuario != "NA" && crearCuenta.Usuario != "")
            {
                crearCuentaEncrypt.Usuario = Codificador.Encrypt(crearCuenta.Usuario.ToLower());
            }
            //if (crearCuenta.Correo != "NA" && crearCuenta.Correo != "")
            //{
            //    crearCuentaEncrypt.Correo = crearCuenta.Correo.ToLower();
            //}
            if (crearCuenta.Correo != "NA" && crearCuenta.Correo != "")
            {
                crearCuentaEncrypt.Correo = Codificador.EncryptCorreo(crearCuenta.Correo.ToLower());
            }
            if (crearCuenta.Password != "NA" && crearCuenta.Password != "")
            {
                crearCuentaEncrypt.Password = Codificador.EncryptKey(crearCuenta.Password);
            }
            Response<object> response = await CuentaPeticiones.crearCuenta(crearCuentaEncrypt);
            return response;
        }
    }
}
