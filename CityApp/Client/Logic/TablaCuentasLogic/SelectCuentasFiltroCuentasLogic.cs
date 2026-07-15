using CityApp.Client.Services.ApiRest.CuentaPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.ControllersModels.CuentaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.TablaCuentasLogic
{
    public class SelectCuentasFiltroCuentasLogic
    {
        private CuentaPeticiones CuentaPeticiones;
        private Codificador Codificador = new Codificador();

        public SelectCuentasFiltroCuentasLogic(HttpClient cliente)
        {
            CuentaPeticiones = new CuentaPeticiones(cliente);
        }

        public async Task<Response<List<Cuenta>>> SelectAll(FiltroCuentas filtroCuentas)
        {
            Response<List<Cuenta>> response = await CuentaPeticiones.consultarCuentasFiltroCuentas(filtroCuentas);
            if(response.Status.Exito == 1)
            {
                for(int i = 0; i < response.Data.Count; i++)
                {
                    response.Data[i].NombreUsuario = Codificador.Decrypt(response.Data[i].NombreUsuario);
                    if (response.Data[i].Contacto != null)
                    {
                        response.Data[i].Contacto.Correo = Codificador.DecryptCorreo(response.Data[i].Contacto.Correo);
                    }
                }
            }
            return response;    
        }
    }
}
