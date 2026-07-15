using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DirectorioQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DirectorioQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DirectorioQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DirectorioQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.DirectorioEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DirectorioQuerys
{
    public class DirectorioQuerys
    {
        
            private DirectorioInsert DirectorioInsert;
            private DirectorioDelete DirectorioDelete;
            private DirectorioSelect DirectorioSelect;
            private DirectoriosSelect DirectoriosSelect;
            private DirectorioUpdate DirectorioUpdate;
            private IdDirectorioSelect IdDirectorioSelect;

            public DirectorioQuerys(CityAppContext cityAppContext)
            {
                DirectorioInsert = new DirectorioInsert(cityAppContext);
                DirectorioDelete = new DirectorioDelete(cityAppContext);
                DirectorioSelect = new DirectorioSelect(cityAppContext);
                DirectoriosSelect = new DirectoriosSelect(cityAppContext);
                DirectorioUpdate = new DirectorioUpdate(cityAppContext);
                IdDirectorioSelect = new IdDirectorioSelect(cityAppContext);
            }

            //Insert
            public Response<object> InsertDirectorio(Directorio directorio)
            {
                return DirectorioInsert.InsertDirectorio(directorio);
            }

            //Delete
            public Response<object> DeletetDirectorio(Directorio directorio)
            {
                return DirectorioDelete.DeleteDirectorio(directorio);
            }

            //Select
            public Response<Directorio> SelectDirectorioIdDirectorio(int idDirectorio)
            {
                return DirectorioSelect.SelectDirectorioIdDirectorio(idDirectorio);
            }
            public Response<IEnumerable<Directorio>> SelectDirectorios()
            {
                return DirectoriosSelect.SelectDirectorios();
            }
            public Response<IEnumerable<Directorio>> SelectDirectoriosFirltoDirectorio(FiltroDirectorio filtroDirectorio)
            {
                return DirectoriosSelect.SelectDirectoriosFirltoDirectorio(filtroDirectorio);
            }
            public Response<int> SelectIdDirectorioNombre(string texto)
            {
                return IdDirectorioSelect.SelectIdDirectorioNombre(texto);
            }

            //Update
            public Response<object> UpdateDirectorio(Directorio directorio)
            {
                return DirectorioUpdate.UpdateDirectorio(directorio);
            } 
    }
}
