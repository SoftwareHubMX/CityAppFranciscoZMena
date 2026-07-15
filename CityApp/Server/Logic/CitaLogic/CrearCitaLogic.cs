using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CitaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.CitaLogic
{
    public class CrearCitaLogic
    {
        private CitaQuerys CitaQuerys;

        private Cita Cita;

        public CrearCitaLogic(CityAppContext cityAppContext, Cita cita)
        {
            CitaQuerys = new CitaQuerys(cityAppContext);

            Cita = cita;
        }

        public Response<object> Crear()
        {
            return CitaQuerys.InsertCita(Cita);
        }
    }
}
