using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CaracteristicaLugarTuristicoQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CaracteristicaLugarTuristicoQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CaracteristicaLugarTuristicoQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CaracteristicaLugarTuristicoQuerys
{
    public class CaracteristicaLugarTuristicoQuerys
    {
        private CaracteristicaLugarTuristicoInsert CaracteristicaLugarTuristicoInsert;
        private CaracteristicaLugarTuristicoSelect CaracteristicaLugarTuristicoSelect;
        private CaracteristicasLugarTuristicoSelect CaracteristicasLugarTuristicoSelect;
        private CaracteristicaLugarTuristicoDelete CaracteristicaLugarTuristicoDelete;

        public CaracteristicaLugarTuristicoQuerys(CityAppContext cityAppContext)
        {
            CaracteristicaLugarTuristicoInsert = new CaracteristicaLugarTuristicoInsert(cityAppContext);
            CaracteristicaLugarTuristicoSelect = new CaracteristicaLugarTuristicoSelect(cityAppContext);
            CaracteristicasLugarTuristicoSelect = new CaracteristicasLugarTuristicoSelect(cityAppContext);
            CaracteristicaLugarTuristicoDelete = new CaracteristicaLugarTuristicoDelete(cityAppContext);
        }

        //insert
        public Response<object> InsertCaracteristicaLugarTuristico(CaracteristicaLugarTuristico caracteristicaLugarTuristico)
        {
            return CaracteristicaLugarTuristicoInsert.InsertCaracteristicaLugarTuristico(caracteristicaLugarTuristico);
        }

        //select
        public Response<CaracteristicaLugarTuristico> SelectCatacteristicaLugarTuristicoIdCaracteristicaLugarTuristico(int idCaracteristicaLugarTuristico)
        {
            return CaracteristicaLugarTuristicoSelect.SelectCatacteristicaLugarTuristicoIdCaracteristicaLugarTuristico(idCaracteristicaLugarTuristico);
        }
        public Response<IEnumerable<CaracteristicaLugarTuristico>> SelectCatacteristicasLugarTuristicoIdLugarTuristico(int idLugarTuristico)
        {
            return CaracteristicasLugarTuristicoSelect.SelectCatacteristicasLugarTuristicoIdLugarTuristico(idLugarTuristico);
        }

        //delete
        public Response<object> DeleteCaracteristicaLugarTuristico(CaracteristicaLugarTuristico caracteristicaLugarTuristico)
        {
            return CaracteristicaLugarTuristicoDelete.DeleteCaracteristicaLugarTuristico(caracteristicaLugarTuristico);
        }
    }
}
