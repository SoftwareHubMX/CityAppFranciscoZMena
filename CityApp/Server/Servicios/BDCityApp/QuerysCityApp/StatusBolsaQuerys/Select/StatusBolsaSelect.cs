using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.StatusBolsaQuerys.Select
{
    public class StatusBolsaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<StatusBolsa> SelectCityApp = new SelectCityApp<StatusBolsa>();

        public StatusBolsaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<StatusBolsa>> SelectStatusBolsa()
        {
            Response<IEnumerable<StatusBolsa>> response = new Response<IEnumerable<StatusBolsa>>();

            try
            {
                response.Data = CityAppContext.StatusBolsas;

                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
