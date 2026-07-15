using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CaracteristicaLugarTuristicoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CuentaQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.CaracteristicaLugarTuristicoEntredaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.CaracteristicaLugarTuristicoLogic
{
    public class AgregarCaracteristicaLugarTuristicoLogic
    {
        private CaracteristicaLugarTuristicoQuerys CaracteristicaLugarTuristicoQuerys;

        private CaracteristicaLugarTuristico CaracteristicaLugarTuristico;

        public AgregarCaracteristicaLugarTuristicoLogic(CityAppContext cityAppContext, AgregarCaracteristicaLugarTuristico agregarCaracteristicaLugarTuristico)
        {
            CaracteristicaLugarTuristicoQuerys = new CaracteristicaLugarTuristicoQuerys(cityAppContext);

            CaracteristicaLugarTuristico = new CaracteristicaLugarTuristico()
            {
               NombreCaracteristica = agregarCaracteristicaLugarTuristico.NombreCaracteristica,
               Caracteristica = agregarCaracteristicaLugarTuristico.Caracteristica,
               IdLugarTuristico = agregarCaracteristicaLugarTuristico.IdLugarTuristico,
            };
        }

        public Response<object> Agregar()
        {
            Response<object> response = new Response<object>();

            response = CaracteristicaLugarTuristicoQuerys.InsertCaracteristicaLugarTuristico(CaracteristicaLugarTuristico);

            return response;
        }
    }
}
