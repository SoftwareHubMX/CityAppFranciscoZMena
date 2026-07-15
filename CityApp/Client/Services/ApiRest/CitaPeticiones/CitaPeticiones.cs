using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.CitaEndradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Client.Services.ApiRest.CitaPeticiones
{
    public class CitaPeticiones
    {
        private CrearCita CrearCita;
        private ConsultarCitas ConsultarCitas;


        public CitaPeticiones(HttpClient Cliente)
        {
            CrearCita = new CrearCita(Cliente);
            ConsultarCitas = new ConsultarCitas(Cliente);

        }

        public async Task<Response<object>> crearCita(string token, Cita cita)
        {
            Response<object> response = await CrearCita.CrearCitaAsync(token, cita);
            return response;
        }

        public async Task<Response<List<Cita>>> consultarFiltroCitas(string token, FiltroCitas filtroCitas)
        {
            Response<List<Cita>> response = await ConsultarCitas.ConsultarFiltroCitasAsync(token, filtroCitas);
            return response;
        }
    }
}
