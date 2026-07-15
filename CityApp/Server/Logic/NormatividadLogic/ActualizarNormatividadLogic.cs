using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NormatividadQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.NormatividadLogic
{
    public class ActualizarNormatividadLogic
    {
        private NormatividadQuerys NormatividadQuerys;
        private Normatividad Normatividad = new Normatividad();

        public ActualizarNormatividadLogic(CityAppContext cityAppContext, Normatividad normatividad)
        {
            NormatividadQuerys = new NormatividadQuerys(cityAppContext);

            Normatividad = normatividad;
        }

        public Response<object> Actualizar()
        {
            return NormatividadQuerys.UpdatePartulla(Normatividad);
        }
    }
}
