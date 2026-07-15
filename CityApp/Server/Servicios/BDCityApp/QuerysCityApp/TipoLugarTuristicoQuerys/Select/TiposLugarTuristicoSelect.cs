using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoLugarTuristicoQuerys.Select
{
    public class TiposLugarTuristicoSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<TipoLugarTuristico> SelectCityApp = new SelectCityApp<TipoLugarTuristico>();

        public TiposLugarTuristicoSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<TipoLugarTuristico>> SelectTiposLugarTuristico()
        {
            Response<IEnumerable<TipoLugarTuristico>> response = new Response<IEnumerable<TipoLugarTuristico>>();

            try
            {
                response.Data = CityAppContext.TiposLugarTuristico;

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
