using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaQuerys.Delete
{
    public class ColoniaDelete
    {
        private DeleteCityApp<Colonia> DeleteCityApp;

        public ColoniaDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<Colonia>(cityAppContext);
        }

        public Response<object> DeleteColonia(Colonia colonia)
        {
            return DeleteCityApp.Save(colonia);
        }
    }
}
