using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CitaQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.CitaEndradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.CitaLogic
{
    public class ConsultarFiltroCitasLogic
    {
        private CitaQuerys CitaQuerys;
        private FiltroCitas FiltroCitas;


        public ConsultarFiltroCitasLogic(CityAppContext cityAppContetx, FiltroCitas filtroCitas)
        {
            CitaQuerys = new CitaQuerys(cityAppContetx);
            FiltroCitas = filtroCitas;


        }
        public Response<List<Cita>> Consultar()
        {
            Response<List<Cita>> response = new Response<List<Cita>>();

            Response<IEnumerable<Cita>> responsePotulacion = CitaQuerys.SelectCitasFirltoCitas(FiltroCitas);
            response.Status = responsePotulacion.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = new List<Cita>();
                response.Data = responsePotulacion.Data.ToList();
                response.Info = new Info();
                response.Info = responsePotulacion.Info;

            }


            return response;
        }
    }
}
