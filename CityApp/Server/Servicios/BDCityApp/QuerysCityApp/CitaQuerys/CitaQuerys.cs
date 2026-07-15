using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CitaQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CitaQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PostulacionQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.CitaEndradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CitaQuerys
{
    public class CitaQuerys
    {
        private CitaInsert CitaInsert;
        private CitaSelect CitaSelect;
        private CitasSelect CitasSelect;

        public CitaQuerys(CityAppContext cityAppContext)
        {
            CitaInsert = new CitaInsert(cityAppContext);
            CitaSelect = new CitaSelect(cityAppContext);
            CitasSelect = new CitasSelect(cityAppContext);
        }

        //Insert

        public Response<object> InsertCita(Cita cita)
        {
            return CitaInsert.InsertCita(cita);
        }

        //Select 
        public Response<Cita> SelectCitaIdCita(int idCita)
        {
            return CitaSelect.SelectCitaIdCita(idCita);
        }
        public Response<IEnumerable<Cita>> SelectCitas()
        {
            return CitasSelect.SelectCitas();
        }

        public Response<IEnumerable<Cita>> SelectCitasFirltoCitas(FiltroCitas filtroCitas)
        {
            return CitasSelect.SelectCitasFirltoCitas(filtroCitas);
        }
    }
}
