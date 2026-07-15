using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AnuncioQuerys.Delete
{
    public class AnuncioDelete
    {
        private DeleteCityApp<Anuncio> DeleteCityApp;

        public AnuncioDelete(CityAppContext cityAppContext)
        {
            DeleteCityApp = new DeleteCityApp<Anuncio>(cityAppContext);
        }

        public Response<object> DeleteAnuncio(Anuncio anuncio)
        {
            return DeleteCityApp.Save(anuncio);
        }
    }
}
