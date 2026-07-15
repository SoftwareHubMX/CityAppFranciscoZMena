using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NormatividadQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.NormatividadLogic
{
    public class ConsultarNormatividadLogic
    {
        private NormatividadQuerys NormatividadQuerys;
        private int IdNormatividad = 0;

        public ConsultarNormatividadLogic(CityAppContext cityAppContext, int idNormatividad)
        {
            NormatividadQuerys = new NormatividadQuerys(cityAppContext);

            IdNormatividad = idNormatividad;
        }

        public Response<Normatividad> Consultar()
        {
            return NormatividadQuerys.SelectNormatividad(IdNormatividad);
        }
    }
}
