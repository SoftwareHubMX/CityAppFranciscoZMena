using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PostulacionQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.PostulacionLogic
{
    public class CrearPostulacionLogic
    {
        private PostulacionQuerys PostulacionQuerys;

        private Postulacion Postulacion;

        public CrearPostulacionLogic(CityAppContext cityAppContext, Postulacion postulacion)
        {
            PostulacionQuerys = new PostulacionQuerys(cityAppContext);

            Postulacion = postulacion;
        }

        public Response<object> Crear()
        {
            return PostulacionQuerys.InsertPostulacion(Postulacion);
        }
    }
}
