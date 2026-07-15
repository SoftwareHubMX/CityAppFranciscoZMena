using CityApp.Client.Services.ApiRest.ReporteCiudadanoPeticiones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Logic.ModalDetallesReporteCiudadanoLogic
{
    public class SelectReporteCiudadanoCompleto
    {
        private ReporteCiudadanoPeticiones ReporteCiudadanoPeticiones;
        private Codificador Codificador = new Codificador();

        public SelectReporteCiudadanoCompleto(HttpClient cliente)
        {
            ReporteCiudadanoPeticiones = new ReporteCiudadanoPeticiones(cliente);
        }

        public async Task<Response<ReporteCiudadano>> Select(string token, int idReporteCiudadano)
        {
            Response<ReporteCiudadano> response = await ReporteCiudadanoPeticiones.consultarReporteCiudadanoCompletoAdministrador(token, idReporteCiudadano);
            if(response.Status.Exito == 1)
            {
                for(int i = 0; i < response.Data.VercionesReporteCiudadano.Count; i++)
                {
                    response.Data.VercionesReporteCiudadano[i].Cuenta.NombreUsuario = Codificador.Decrypt(response.Data.VercionesReporteCiudadano[i].Cuenta.NombreUsuario);

                    if (response.Data.VercionesReporteCiudadano[i].Cuenta.Contacto != null)
                    {
                        response.Data.VercionesReporteCiudadano[i].Cuenta.Contacto.Correo =
                            Codificador.DecryptCorreo(response.Data.VercionesReporteCiudadano[i].Cuenta.Contacto.Correo);
                    }
                }
            }
            return response;
        }
    }
}
