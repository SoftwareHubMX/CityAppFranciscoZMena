using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.CuentaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.CuentaPeticiones
{
    public class CuentaPeticiones
    {
        private CrearCuentaPeticiones CrearCuentaPeticiones;
        private CrearCuentaChofer CrearCuentaChofer;
        private ActualizarNombreUsuario ActualizarNombreUsuario;
        private ActualizarPasswordPeticiones ActualizarPasswordPeticiones;
        private RecuperarPasswordPeticiones RecuperarPasswordPeticiones;
        private ConsultarCuentas ConsultarCuentas;
        private ConsultarCuentasFiltroCuentas ConsultarCuentasFiltroCuentas;

        public CuentaPeticiones(HttpClient cliente)
        {
            CrearCuentaPeticiones = new CrearCuentaPeticiones(cliente);
            CrearCuentaChofer = new CrearCuentaChofer(cliente); 
            ActualizarNombreUsuario = new ActualizarNombreUsuario(cliente);
            ActualizarPasswordPeticiones = new ActualizarPasswordPeticiones(cliente);
            RecuperarPasswordPeticiones = new RecuperarPasswordPeticiones(cliente);
            ConsultarCuentas = new ConsultarCuentas(cliente);
            ConsultarCuentasFiltroCuentas = new ConsultarCuentasFiltroCuentas(cliente);

        }

        public async Task<Response<object>> crearCuenta(CrearCuenta crearCuenta)
        {
            Response<object> response = await CrearCuentaPeticiones.CrearCuentaAsync(crearCuenta);
            return response;
        }
        public async Task<Response<object>> crearCuentaChofer(CrearCuenta crearCuenta)
        {
            Response<object> response = await CrearCuentaChofer.CrearCuentaChoferAsync(crearCuenta);
            return response;
        }

        public async Task<Response<object>> recuperarPassword(RecuperacionPassword recuperacionPassword)
        {
            Response<object> response = await RecuperarPasswordPeticiones.RecuperarPasswordAsync(recuperacionPassword);
            return response;
        }

        public async Task<Response<object>> actualizarNombreUsuario(string nombreUsuario)
        {
            Response<object> response = await ActualizarNombreUsuario.ActualizarNombreUsuarioAsync(nombreUsuario);
            return response;
        }

        public async Task<Response<object>> actualizarPassword(ActualizarPassword actualizarPassword)
        {
            Response<object> response = await ActualizarPasswordPeticiones.ActualizarPasswordAsync(actualizarPassword);
            return response;
        }
        public async Task<Response<List<Cuenta>>> consultarCuentas(string token)
        {
            Response<List<Cuenta>> response = await ConsultarCuentas.ConsultarCuentaAsync(token);
            return response; 
        }
        public async Task<Response<List<Cuenta>>> consultarCuentasFiltroCuentas(FiltroCuentas filtroCuentas)
        {
            Response<List<Cuenta>> response = await ConsultarCuentasFiltroCuentas.ConsultarCuentasFiltroCuentasAsync(filtroCuentas);   
            return response;
        }
    }
}
