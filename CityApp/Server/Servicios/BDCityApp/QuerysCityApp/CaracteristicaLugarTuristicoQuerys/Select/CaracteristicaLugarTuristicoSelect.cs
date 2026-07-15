using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CaracteristicaLugarTuristicoQuerys.Select
{
    public class CaracteristicaLugarTuristicoSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<CaracteristicaLugarTuristico> SelectCityApp = new SelectCityApp<CaracteristicaLugarTuristico>();

        public CaracteristicaLugarTuristicoSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<CaracteristicaLugarTuristico> SelectCatacteristicaLugarTuristicoIdCaracteristicaLugarTuristico(int idCaracteristicaLugarTuristico)
        {
            Response<CaracteristicaLugarTuristico> response = new Response<CaracteristicaLugarTuristico>();

            try
            {
                response.Data = CityAppContext.CaracteristicasLugaresTuristicos.Where(d => d.IdCaracteristicaLugarTuristico == idCaracteristicaLugarTuristico).First();

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
