using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DiscapacidadQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DiscapacidadQuerys
{
    public class DiscapacidadQuerys
    {
        private DiscapacidadSelect DiscapacidadSelect;
        private DiscapacidadesSelect DiscapacidadesSelect;

        public DiscapacidadQuerys(CityAppContext cityAppContex)
        {
            DiscapacidadSelect = new DiscapacidadSelect(cityAppContex);
            DiscapacidadesSelect = new DiscapacidadesSelect(cityAppContex);
        }

        public Response<Discapacidad> SelectDiscapacidad(int idDiscapacidad)
        {
            return DiscapacidadSelect.SelectDiscapacidad(idDiscapacidad);
        }
        public Response<IEnumerable<Discapacidad>> SelectDiscapacidades()
        {
            return DiscapacidadesSelect.SelectDiscapacidades();
        }
    }
}
