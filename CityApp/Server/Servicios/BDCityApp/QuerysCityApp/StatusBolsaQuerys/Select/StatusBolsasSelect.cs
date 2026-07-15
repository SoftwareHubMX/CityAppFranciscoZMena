using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.StatusBolsaQuerys.Select
{
    public class StatusBolsasSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<StatusBolsa> SelectCityApp = new SelectCityApp<StatusBolsa>();

        public StatusBolsasSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<StatusBolsa> StatusBolsasIdStatusBolsaSelect(int idStatusBolsa)
        {
            Response<StatusBolsa> response = new Response<StatusBolsa>();

            try
            {
                response.Data = (from data in CityAppContext.StatusBolsas
                                 orderby data.IdStatusBolsa
                                 where data.IdStatusBolsa == idStatusBolsa
                                 select new StatusBolsa()
                                 {
                                     IdStatusBolsa = data.IdStatusBolsa,
                                     StatusBolsaTrabajo = data.StatusBolsaTrabajo,
                                 }).FirstOrDefault();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
