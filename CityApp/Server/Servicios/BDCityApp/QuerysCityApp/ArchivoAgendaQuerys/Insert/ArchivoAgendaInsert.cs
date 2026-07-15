using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoAgendaQuerys.Insert
{
    public class ArchivoAgendaInsert
    {
        private InsertCityApp<ArchivoAgenda> InsertCityApp;

        public ArchivoAgendaInsert(CityAppContext cityAppContext)
        {
            InsertCityApp = new InsertCityApp<ArchivoAgenda>(cityAppContext);
        }

        public Response<object> InsertArchivoAgenda(ArchivoAgenda archivoAgenda)
        {
            return InsertCityApp.Save(archivoAgenda);
        }
    }
}
