using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AnuncioQuerys.Insert
{
    public class AnuncioInsert
    {
        private InsertCityApp<Anuncio> InsertCityApp;

        public AnuncioInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<Anuncio>(cityAppContext);
        }

        public Response<object> InsertAnuncio(Anuncio anuncio)
        {
            return InsertCityApp.Save(anuncio);
        }
    }
}
