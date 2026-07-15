using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DiscapacidadQuerys.Select
{
    public class DiscapacidadesSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Discapacidad> SelectCityApp = new SelectCityApp<Discapacidad>();

        public DiscapacidadesSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<Discapacidad>> SelectDiscapacidades()
        {
            Response<IEnumerable<Discapacidad>> response = new Response<IEnumerable<Discapacidad>>();

            try
            {
                response.Data = CityAppContext.Discapacidades;

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
