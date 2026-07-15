using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DiaRutaQuerys.Select
{
    public class DiaRutaRecoleccionSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<DiaRuta> SelectCityApp = new SelectCityApp<DiaRuta>();

        public DiaRutaRecoleccionSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<DiaRuta> SelectDiaRuta(int idDiaRuta)
        {
            Response<DiaRuta> response = new Response<DiaRuta>();

            try
            {
                response.Data = CityAppContext.DiasRuta.Where(d => d.IdDiaRuta == idDiaRuta).First();

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
