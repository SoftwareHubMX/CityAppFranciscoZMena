using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PostulacionQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PostulacionEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.PostulacionLogic
{
    public class ConsultarFiltroPostulacionLogic
    {
        private PostulacionQuerys PostulacionQuerys;
        private FiltroPostulacion FiltroPostulacion;
        

        public ConsultarFiltroPostulacionLogic(CityAppContext cityAppContetx, FiltroPostulacion filtroPostulacion)
        {
            PostulacionQuerys = new PostulacionQuerys(cityAppContetx);
            FiltroPostulacion = filtroPostulacion;
        }
        public Response<List<Postulacion>> Consultar()
        {
            Response<List<Postulacion>> response = new Response<List<Postulacion>>();

            Response<IEnumerable<Postulacion>> responsePotulacion = PostulacionQuerys.SelectPostulacionesFirltoPostulacion(FiltroPostulacion);
            response.Status = responsePotulacion.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = new List<Postulacion>();
                response.Data = responsePotulacion.Data.ToList();
                response.Info = new Info();
                response.Info = responsePotulacion.Info;

            }


            return response;
        }
    }
}
