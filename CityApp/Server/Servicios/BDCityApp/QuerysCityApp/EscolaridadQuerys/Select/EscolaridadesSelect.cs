using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EscolaridadQuerys.Select
{
    public class EscolaridadesSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Escolaridad> SelectCityApp = new SelectCityApp<Escolaridad>();

        public EscolaridadesSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<Escolaridad>> SelectEscolaridades()
        {
            Response<IEnumerable<Escolaridad>> response = new Response<IEnumerable<Escolaridad>>();

            try
            {
                response.Data = CityAppContext.Escolaridades;

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
