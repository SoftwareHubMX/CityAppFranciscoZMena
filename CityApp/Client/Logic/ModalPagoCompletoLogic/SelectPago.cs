using CityApp.Client.Services.ApiRest.PagoPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.ModalPagoCompletoLogic
{
    public class SelectPago
    {
        private PagoPeticiones PagoPeticiones;
        private Codificador Codificador = new Codificador();

        public SelectPago(HttpClient cliente)
        {
            PagoPeticiones = new PagoPeticiones(cliente);
        }

        public async Task<Response<Pago>> Select(string token, int idPago)
        {
            Response<Pago> response = await PagoPeticiones.consultarPago(token, idPago);
            if(response.Status.Exito == 1)
            {
                response.Data.Cuenta.NombreUsuario = Codificador.Decrypt(response.Data.Cuenta.NombreUsuario);
                response.Data.Cuenta.Contacto.Correo = Codificador.DecryptCorreo(response.Data.Cuenta.Contacto.Correo);
                response.Data.Cuenta.Contacto.TelefonoOpcion1 = (response.Data.Cuenta.Contacto.TelefonoOpcion1 != "NA") ? Codificador.Decrypt(response.Data.Cuenta.Contacto.TelefonoOpcion1) : "NA";
                response.Data.Cuenta.Contacto.TelefonoOpcion2 = (response.Data.Cuenta.Contacto.TelefonoOpcion2 != "NA") ? Codificador.Decrypt(response.Data.Cuenta.Contacto.TelefonoOpcion2) : "NA";
                response.Data.Cuenta.Usuario.Nombre = (response.Data.Cuenta.Usuario.Nombre != "NA") ? Codificador.Decrypt(response.Data.Cuenta.Usuario.Nombre) : "NA";
                response.Data.Cuenta.Usuario.Nombre = (response.Data.Cuenta.Usuario.Apellidos != "NA") ? Codificador.Decrypt(response.Data.Cuenta.Usuario.Apellidos) : "NA";
            }
            return response;
        }
    }
}
