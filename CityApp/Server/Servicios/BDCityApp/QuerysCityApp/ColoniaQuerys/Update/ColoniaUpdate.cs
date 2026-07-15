using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaQuerys.Update
{
    public class ColoniaUpdate
    {
        private UpdateCityApp<Colonia> UpdateCityApp;

        public ColoniaUpdate(CityAppContext cityAppContext)
        {
            UpdateCityApp = new UpdateCityApp<Colonia>(cityAppContext);
        }
        public Response<object> UpdateColonia(Colonia colonia)
        {
            return UpdateCityApp.Save(colonia);
        }
    }
}
