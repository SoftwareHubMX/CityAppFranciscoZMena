using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CitaQuerys.Insert
{
    public class CitaInsert
    {
        private InsertCityApp<Cita> InsertCityApp;
        public CitaInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<Cita>(cityAppContext);
        }
        public Response<object> InsertCita(Cita cita)
        {
            return InsertCityApp.Save(cita);
        }
    }
}
