using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AnuncioQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AnuncioQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AnuncioQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AnuncioQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.AnunciaoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.AnuncioQuerys
{
    public class AnuncioQuerys
    {
        private AnuncioInsert AnuncioInsert;
        private AnuncioDelete AnuncioDelete;
        private AnuncioSelect AnuncioSelect;
        private AnunciosSelect AnunciosSelect;
        private AnuncioUpdete AnuncioUpdete;
        private IdAnuncioSelect IdAnuncioSelect;

        public AnuncioQuerys(CityAppContext cityAppContext)
        {
            AnuncioInsert = new AnuncioInsert(cityAppContext);
            AnuncioDelete = new AnuncioDelete(cityAppContext);
            AnuncioSelect = new AnuncioSelect(cityAppContext);
            AnunciosSelect = new AnunciosSelect(cityAppContext);
            AnuncioUpdete = new AnuncioUpdete(cityAppContext);
            IdAnuncioSelect = new IdAnuncioSelect(cityAppContext);
        }

        //Insert
        public Response<object> InsertAnuncio(Anuncio anuncio)
        {
            return AnuncioInsert.InsertAnuncio(anuncio);
        }

        //Delete
        public Response<object> DeleteAnuncio(Anuncio anuncio)
        {
            return AnuncioDelete.DeleteAnuncio(anuncio);
        }

        //Select
        public Response<Anuncio> SelectAnuncioIdAnuncio(int idAnuncio)
        {
            return AnuncioSelect.SelectAnuncioIdAnuncio(idAnuncio);
        }
        public Response<IEnumerable<Anuncio>> SelectAnuncios()
        {
            return AnunciosSelect.SelectAnuncios();
        }
        public Response<IEnumerable<Anuncio>> SelectAnuncioFirltoAnuncio(FiltroAnuncio filtroAnuncio)
        {
            return AnunciosSelect.SelectAnuncioFirltoAnuncio(filtroAnuncio);
        }
        public Response<int> SelectIdAnuncioTitulo(string texto)
        {
            return IdAnuncioSelect.SelectIdAnuncioTitulo(texto);
        }

        //Update
        public Response<object> UpdateAnuncio(Anuncio anuncio)
        {
            return AnuncioUpdete.UpdateAnuncio(anuncio);
        }
    }
}
