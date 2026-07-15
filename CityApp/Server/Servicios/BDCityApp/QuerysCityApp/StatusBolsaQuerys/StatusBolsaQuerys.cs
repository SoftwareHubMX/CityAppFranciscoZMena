using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.StatusBolsaQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.StatusBolsaQuerys
{
    public class StatusBolsaQuerys
    {
        private StatusBolsaSelect StatusBolsaSelect;
        private StatusBolsasSelect StatusBolsasSelect;

        public StatusBolsaQuerys(CityAppContext cityAppContext)
        {
            StatusBolsaSelect = new StatusBolsaSelect(cityAppContext);
            StatusBolsasSelect = new StatusBolsasSelect(cityAppContext);
        }

        //select
        public Response<IEnumerable<StatusBolsa>> SelectStatusBolsa()
        {
            return StatusBolsaSelect.SelectStatusBolsa();
        }

        public Response<StatusBolsa> StatusBolsasIdStatusBolsaSelect(int idStatusBolsa)
        {
            return StatusBolsasSelect.StatusBolsasIdStatusBolsaSelect(idStatusBolsa);
        }
    }
}
