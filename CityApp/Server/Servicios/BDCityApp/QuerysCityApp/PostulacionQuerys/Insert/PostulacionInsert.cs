using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PostulacionQuerys.Insert
{
    public class PostulacionInsert
    {
        private InsertCityApp<Postulacion> InsertCityApp;
        public PostulacionInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<Postulacion>(cityAppContext);
        }
        public Response<object> InsertPostulacion(Postulacion postulacion)
        {
            return InsertCityApp.Save(postulacion);
        }
    }
}
