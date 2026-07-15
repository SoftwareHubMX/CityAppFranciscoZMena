using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TramiteQuerys.Select
{
    public class IdTramiteSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<int> SelectCityApp = new SelectCityApp<int>();

        public IdTramiteSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<int> SelectTramiteConceptoDescripcion(string concepto, string descripcion)
        {
            Response<int> response = new Response<int>();

            try
            {
                response.Data = (from data in CityAppContext.Tramites
                                 orderby data.IdTramite
                                 where data.Concepto == concepto
                                 where data.Descripcion == descripcion
                                 select data.IdTramite).LastOrDefault();

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
