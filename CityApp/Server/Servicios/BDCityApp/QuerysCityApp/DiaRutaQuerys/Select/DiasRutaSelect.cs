using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DiaRutaQuerys.Select
{
    public class DiasRutaSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<DiaRuta> SelectCityApp = new SelectCityApp<DiaRuta>();

        

        public DiasRutaSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }
        public Response<IEnumerable<DiaRuta>> SelectDiasRuta(int idRutaRecoleccion)
        {
            Response<IEnumerable<DiaRuta>> response = new Response<IEnumerable<DiaRuta>>();

            try
            {
                response.Data = CityAppContext.DiasRuta.Where(d => d.IdRutaRecoleccion == idRutaRecoleccion);
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
