using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NormatividadQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.NormatividadLogic
{
    public class CrearNormatividadLogic
    {
        private NormatividadQuerys NormatividadQuerys;
        private Normatividad Normatividad = new Normatividad();

        public CrearNormatividadLogic(CityAppContext cityAppContext, Normatividad normatividad)
        {
            NormatividadQuerys = new NormatividadQuerys(cityAppContext);

            Normatividad = normatividad;
        }

        public Response<object> Crear()
        {
            return NormatividadQuerys.InsertNormatividad(Normatividad);
        }
    }
}
