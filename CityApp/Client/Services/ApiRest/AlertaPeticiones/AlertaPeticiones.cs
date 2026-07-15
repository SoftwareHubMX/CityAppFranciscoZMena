using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.AlertaEntradaModel;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.AlertaPeticiones
{
    public class AlertaPeticiones
    {
        private CrearAlertaPeticion CrearAlertaPeticion;
        private ConsultarAlertasUsuario ConsultarAlertasUsuario;
        private ConsultarAlertasAdministrador ConsultarAlertasAdministrador;
        private ConsultarAlertaIdAlerta ConsultarAlertaIdAlerta;
        private ActualizarEstatusAlerta ActualizarEstatusAlerta;

        public AlertaPeticiones(HttpClient cliente)
        {
            CrearAlertaPeticion = new CrearAlertaPeticion(cliente);
            ConsultarAlertasUsuario = new ConsultarAlertasUsuario(cliente);
            ConsultarAlertasAdministrador = new ConsultarAlertasAdministrador(cliente);
            ConsultarAlertaIdAlerta = new ConsultarAlertaIdAlerta(cliente);
            ActualizarEstatusAlerta = new ActualizarEstatusAlerta(cliente);
        }

        public async Task<Response<object>> crearAlertaPeticion(CrearAlerta crearAlerta)
        {
            Response<object> response = await CrearAlertaPeticion.CrearAlertaAsync(crearAlerta);
            return response;
        }

        public async Task<Response<List<Alerta>>> consultarAlertasUsuario(string token, int idEstatusAlerta)
        {
            Response<List<Alerta>> response = await ConsultarAlertasUsuario.ConsultarAlertasUsuarioAsync(token, idEstatusAlerta);
            return response;
        }

        public async Task<Response<List<Alerta>>> consultarAlertasAdministrador(string token, int idEstatusAlerta)
        {
            Response<List<Alerta>> response = await ConsultarAlertasAdministrador.ConsultarAlertasAdministradorAsync(token, idEstatusAlerta);
            return response;
        }

        public async Task<Response<Alerta>> consultarAlertaIdAlerta(int idAlerta)
        {
            Response<Alerta> response = await ConsultarAlertaIdAlerta.ConsultarAlertaIdAlertaAsync(idAlerta);
            return response;
        }

        public async Task<Response<object>> actualizarEstatusAlerta(string token, int idAlerta, int idEstatusAlerta)
        {
            Response<object> response = await ActualizarEstatusAlerta.ActualizarEstatusAlertaAsync(token, idAlerta, idEstatusAlerta);
            return response;
        }
    }
}
