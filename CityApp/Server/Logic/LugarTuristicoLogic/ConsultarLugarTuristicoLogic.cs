using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoLugarTuristicoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CaracteristicaLugarTuristicoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.LugarTuristicoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.LugarTuristicoLogic
{
    public class ConsultarLugarTuristicoLogic
    {
        private LugarTuristicoQuerys LugarTuristicoQuerys;
        private ArchivoLugarTuristicoQuerys ArchivoLugarTuristicoQuerys;
        private CaracteristicaLugarTuristicoQuerys CaracteristicaLugarTuristicoQuerys;

        private int IdLugarTuristico;
        private LugarTuristico LugarTuristico;

        public ConsultarLugarTuristicoLogic(CityAppContext cityAppContetx, int idLugarTuristico)
        {
            LugarTuristicoQuerys = new LugarTuristicoQuerys(cityAppContetx);
            ArchivoLugarTuristicoQuerys = new ArchivoLugarTuristicoQuerys(cityAppContetx);
            CaracteristicaLugarTuristicoQuerys = new CaracteristicaLugarTuristicoQuerys(cityAppContetx);

            IdLugarTuristico = idLugarTuristico;
        }

        public Response<LugarTuristico> Consultar()
        {
            Response<LugarTuristico> response = new Response<LugarTuristico>();

            response = LugarTuristicoQuerys.SelectLugarTuristicoCompletoIdLugarTuristico(IdLugarTuristico);
            if (response.Status.Exito == 1)
            {
                LugarTuristico = response.Data; 
                Response<object> responseCargarCaracteristicas = CargarCaracteristicas();
                response.Status = responseCargarCaracteristicas.Status;
                if (response.Status.Exito == 1)
                {
                    Response<object> responseCargarListas = CargarArchivos();
                    response.Status = responseCargarListas.Status;
                    if (response.Status.Exito == 1)
                    {
                        response.Data = LugarTuristico;
                    }
                }
            }

            return response;
        }

        private Response<object> CargarCaracteristicas()
        {
            Response<object> response = new Response<object>();

            Response<IEnumerable<CaracteristicaLugarTuristico>> responseCaracteristicaLugarTuristico = CaracteristicaLugarTuristicoQuerys.SelectCatacteristicasLugarTuristicoIdLugarTuristico(IdLugarTuristico);
            response.Status = responseCaracteristicaLugarTuristico.Status;
            if (response.Status.Exito == 1)
            {
                LugarTuristico.CaracteristicasLugarTuristico = responseCaracteristicaLugarTuristico.Data.ToList();
            }
            else if (response.Status.Exito == 2)
            {
                response.Status.Exito = 1;
            }

            return response;
        }

        private Response<object> CargarArchivos()
        {
            Response<object> response = new Response<object>();

            Response<IEnumerable<ArchivoLugarTuristico>> responseArchivoLugarTuristico = ArchivoLugarTuristicoQuerys.SelectArchivosLugarTuristicoIdLugarTuristico(IdLugarTuristico);
            response.Status = responseArchivoLugarTuristico.Status;
            if (response.Status.Exito == 1)
            {
                LugarTuristico.ArchivosLugarTuristico = responseArchivoLugarTuristico.Data.ToList();
            }
            else if (response.Status.Exito == 2)
            {
                response.Status.Exito = 1;
            }

            return response;
        }
    }
}
