using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NormatividadQuerys.Delete
{
    public class NormatividadDelete
    {
        private DeleteCityApp<Normatividad> DeleteCityApp;

        public NormatividadDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<Normatividad>(cityAppContext);
        }

        public Response<object> DeleteNormatividad(Normatividad Normatividad)
        {
            return DeleteCityApp.Save(Normatividad);
        }
    }
}
