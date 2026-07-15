using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EscolaridadQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EscolaridadQuerys
{
    public class EscolaridadQuerys
    {
        private EscolaridadSelect EscolaridadSelect;
        private EscolaridadesSelect EscolaridadesSelect;

        public EscolaridadQuerys(CityAppContext cityAppContex)
        {
            EscolaridadSelect = new EscolaridadSelect(cityAppContex);
            EscolaridadesSelect = new EscolaridadesSelect(cityAppContex);
        }

        public Response<Escolaridad> SelectEscolaridad(int idEscolaridad)
        {
            return EscolaridadSelect.SelectEscolaridad(idEscolaridad);
        }
        public Response<IEnumerable<Escolaridad>> SelectEscolaridades()
        {
            return EscolaridadesSelect.SelectEscolaridades();
        }
    }
}
