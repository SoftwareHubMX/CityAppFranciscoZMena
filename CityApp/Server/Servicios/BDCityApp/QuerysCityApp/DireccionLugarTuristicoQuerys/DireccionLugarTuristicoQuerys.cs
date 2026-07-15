using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DireccionLugarTuristicoQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DireccionLugarTuristicoQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DireccionLugarTuristicoQuerys
{
    public class DireccionLugarTuristicoQuerys
    {
        private DireccionLugarTuristicoUpdate DireccionLugarTuristicoUpdate;
        private DireccionLugarTuristicoSelect DireccionLugarTuristicoSelect;

        public DireccionLugarTuristicoQuerys(CityAppContext cityAppContext)
        {
            DireccionLugarTuristicoUpdate = new DireccionLugarTuristicoUpdate(cityAppContext);
            DireccionLugarTuristicoSelect = new DireccionLugarTuristicoSelect(cityAppContext);
        }

        public Response<object> UpdateDireccionLugarTuristico(DireccionLugarTuristico direccionLugarTuristico)
        {
            return DireccionLugarTuristicoUpdate.UpdateDireccionLugarTuristico(direccionLugarTuristico);
        }

        public Response<DireccionLugarTuristico> SelectDireccionLugaTuristicoIdLugarTuristico(int idLugarTuristico)
        {
            return DireccionLugarTuristicoSelect.SelectDireccionLugaTuristicoIdLugarTuristico(idLugarTuristico);
        }
    }
}
