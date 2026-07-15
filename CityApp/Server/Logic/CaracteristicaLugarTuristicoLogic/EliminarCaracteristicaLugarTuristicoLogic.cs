using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CaracteristicaLugarTuristicoQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.CaracteristicaLugarTuristicoLogic
{
    public class EliminarCaracteristicaLugarTuristicoLogic
    {
        private CaracteristicaLugarTuristicoQuerys CaracteristicaLugarTuristicoQuerys;

        private int IdCaracteristicaLugarTuristico;

        public EliminarCaracteristicaLugarTuristicoLogic(CityAppContext cityAppContext, int idCaracteristicaLugarTuristico)
        {
            CaracteristicaLugarTuristicoQuerys = new CaracteristicaLugarTuristicoQuerys(cityAppContext);

            IdCaracteristicaLugarTuristico = idCaracteristicaLugarTuristico;
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();

            Response<CaracteristicaLugarTuristico> responseCaracteristicaLugarTuristico = CaracteristicaLugarTuristicoQuerys.SelectCatacteristicaLugarTuristicoIdCaracteristicaLugarTuristico(IdCaracteristicaLugarTuristico);
            response.Status = responseCaracteristicaLugarTuristico.Status;
            if (response.Status.Exito == 1)
            {
                response = CaracteristicaLugarTuristicoQuerys.DeleteCaracteristicaLugarTuristico(responseCaracteristicaLugarTuristico.Data);            }

            return response;
        }
    }
}
