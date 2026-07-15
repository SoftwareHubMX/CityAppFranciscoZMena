using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CitaQuerys.Select
{
    public class CitaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Cita> SelectCityApp = new SelectCityApp<Cita>();

        public CitaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }
        public Response<Cita> SelectCitaIdCita(int idCita)
        {
            Response<Cita> response = new Response<Cita>();

            try
            {
                response.Data = CityAppContext.Citas.Where(d => d.IdCita == idCita).First();
                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }
            return response;
        }
    }
}
