using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DireccionLugarTuristicoQuerys.Update
{
    public class DireccionLugarTuristicoUpdate
    {
        private UpdateCityApp<DireccionLugarTuristico> UpdateCityApp;

        public DireccionLugarTuristicoUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<DireccionLugarTuristico>(cityAppContext);
        }

        public Response<object> UpdateDireccionLugarTuristico(DireccionLugarTuristico direccionLugarTuristico)
        {
            return UpdateCityApp.Save(direccionLugarTuristico);
        }
    }
}
