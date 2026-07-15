using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ColoniaRutaRecoleccionQuerys.Select
{
    public class ColoniasRutaRecoleccionSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<ColoniaRutaRecoleccion> SelectCityApp = new SelectCityApp<ColoniaRutaRecoleccion>();
        private Paginado<ColoniaRutaRecoleccion> Paginado = new Paginado<ColoniaRutaRecoleccion>();

        public ColoniasRutaRecoleccionSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<ColoniaRutaRecoleccion>> SelectColoniasRutaRecoleccion(int idRutaRecolecccion)
        {
            Response<IEnumerable<ColoniaRutaRecoleccion>> response = new Response<IEnumerable<ColoniaRutaRecoleccion>>();

            try
            {
                response.Data = CityAppContext.ColoniasRutaRecoleccion.Where(d => d.IdRutaRecoleccion == idRutaRecolecccion);

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
