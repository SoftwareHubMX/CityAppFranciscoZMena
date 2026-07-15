using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.RutaRecoleccionEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RutaRecoleccionQuerys.Select
{
    public class RutasRecoleccionSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<RutaRecoleccion> SelectCityApp = new SelectCityApp<RutaRecoleccion>();
        private Paginado<RutaRecoleccion> Paginado = new Paginado<RutaRecoleccion>();

        public RutasRecoleccionSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<IEnumerable<RutaRecoleccion>> SelectRutasRecoleccion()
        {
            Response<IEnumerable<RutaRecoleccion>> response = new Response<IEnumerable<RutaRecoleccion>>();

            try
            {
                response.Data = CityAppContext.RutasRecoleccion;

                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<IEnumerable<RutaRecoleccion>> SelectRutaRecoleccionFirltoRutaRecoleccion(FiltroRutaRecoleccion filtroRutaRecoleccion)
        {
            Response<IEnumerable<RutaRecoleccion>> response = new Response<IEnumerable<RutaRecoleccion>>();

            try
            {
                response.Data = CityAppContext.RutasRecoleccion.Where(
                    d => d.ColoniaRutaRecolecciones.Any(
                        data => (filtroRutaRecoleccion.IdColonia > 0)? data.IdColonia == filtroRutaRecoleccion.IdColonia : true ));
                response.Status = SelectCityApp.ValidarLista(response.Data);
                if (response.Status.Exito == 1)
                {
                    response = Paginado.Paginar(response.Data, filtroRutaRecoleccion.MaximoElementos, filtroRutaRecoleccion.Pagina);
                }
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
