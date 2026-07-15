using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PostulacionQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PostulacionQuerys.Select;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PostulacionEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.PostulacionQuerys
{
    public class PostulacionQuerys
    {
        private PostulacionInsert PostulacionInsert;
        private PostulacionSelect PostulacionSelect;
        private PostulacionesSelect PostulacionesSelect;

        public PostulacionQuerys(CityAppContext cityAppContext)
        {
            PostulacionInsert = new PostulacionInsert(cityAppContext);
            PostulacionSelect = new PostulacionSelect(cityAppContext);
            PostulacionesSelect = new PostulacionesSelect(cityAppContext);
        }

        //Insert

        public Response<object> InsertPostulacion(Postulacion postulacion)
        {
            return PostulacionInsert.InsertPostulacion(postulacion);
        }

        //Select 
        public Response<Postulacion> SelectPostulacionIdPostulacion(int idPostulacion)
        {
            return PostulacionSelect.SelectPostulacionIdPostulacion(idPostulacion);
        }
        public Response<IEnumerable<Postulacion>> SelectPostulaciones()
        {
            return PostulacionesSelect.SelectPostulaciones();
        }

        public Response<IEnumerable<Postulacion>> SelectPostulacionesFirltoPostulacion(FiltroPostulacion filtroPostulacion)
        {
            return PostulacionesSelect.SelectPostulacionesFirltoPostulacion(filtroPostulacion);
        }
    }
}
