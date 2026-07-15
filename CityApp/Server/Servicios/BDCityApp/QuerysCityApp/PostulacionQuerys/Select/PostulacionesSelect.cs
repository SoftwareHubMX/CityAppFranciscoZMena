using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PostulacionEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PostulacionQuerys.Select
{
    public class PostulacionesSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<Postulacion> SelectCityApp = new SelectCityApp<Postulacion>();

        private Paginado<Postulacion> Paginado = new Paginado<Postulacion>();

        public PostulacionesSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }
        public Response<IEnumerable<Postulacion>> SelectPostulaciones()
        {
            Response<IEnumerable<Postulacion>> response = new Response<IEnumerable<Postulacion>>();

            try
            {
                response.Data = CityAppContext.Postulaciones;

                response.Status = SelectCityApp.ValidarLista(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }
            return response;
        }

        public Response<IEnumerable<Postulacion>> SelectPostulacionesFirltoPostulacion(FiltroPostulacion filtroPostulacion)
        {
            Response<IEnumerable<Postulacion>> response = new Response<IEnumerable<Postulacion>>();

            try
            {
                response.Data = CityAppContext.Postulaciones;

                if (filtroPostulacion.IdBolsaTrabajo != 0)
                {
                    response.Data = response.Data.Where(d => d.IdBolsaTrabajo == filtroPostulacion.IdBolsaTrabajo);
                }
                response.Data = response.Data.OrderByDescending(d => d.IdPostulacion);
                response.Status = SelectCityApp.ValidarLista(response.Data);
                if (response.Status.Exito == 1)
                {
                    response = Paginado.Paginar(response.Data, filtroPostulacion.MaximoElementos, filtroPostulacion.Pagina);
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
