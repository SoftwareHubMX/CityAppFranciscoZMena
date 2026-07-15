using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NoticiaQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NoticiaQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NoticiaQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NoticiaQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.NoticiaEntradaModels;
using CityApp.Shared.Models.DashBoardModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NoticiaQuerys
{
    public class NoticiaQuerys
    {
        private NoticiaInsert NoticiaInsert;
        private NoticiaSelect NoticiaSelect;
        private NoticiasSelect NoticiasSelect;
        private IdNoticiaSelect IdNoticiaSelect;
        private NoticiaUpdate NoticiaUpdate;
        private NoticiaDelete NoticiaDelete;

        public NoticiaQuerys(CityAppContext cityAppContext)
        {
            NoticiaInsert = new NoticiaInsert(cityAppContext);
            NoticiaSelect = new NoticiaSelect(cityAppContext);
            NoticiasSelect = new NoticiasSelect(cityAppContext);
            IdNoticiaSelect = new IdNoticiaSelect(cityAppContext);
            NoticiaUpdate = new NoticiaUpdate(cityAppContext);
            NoticiaDelete = new NoticiaDelete(cityAppContext);
        }

        //insert
        public Response<object> InsertNoticia(Noticia noticia)
        {
            return NoticiaInsert.InsertNoticia(noticia);
        }

        //select
        public Response<Noticia> SelectNoticiaIdNoticia(int idNoticia)
        {
            return NoticiaSelect.SelectNoticiaIdNoticia(idNoticia);
        }
        public Response<IEnumerable<Noticia>> SelectNoticiasFiltroNoticias(FiltroNoticias filtroNoticias)
        {
            return NoticiasSelect.SelectNoticiasFiltroNoticias(filtroNoticias);
        }
        public Response<int> SelectUltimoIdNoticiaTexto(string texto)
        {
            return IdNoticiaSelect.SelectUltimoIdNoticiaTexto(texto);
        }

        public Response<int> SelectNoticiasFechasDashBoard(FechasDashBoard fechasDashBoard)
        {
            return NoticiasSelect.SelectNoticiasFechasDashBoard(fechasDashBoard);
        }

        //update
        public Response<object> UpdateNoticia(Noticia noticia)
        {
            return NoticiaUpdate.UpdateNoticia(noticia);
        }

        //delete
        public Response<object> DeleteNoticia(Noticia Noticia)
        {
            return NoticiaDelete.DeleteNoticia(Noticia);
        }
    }
}
