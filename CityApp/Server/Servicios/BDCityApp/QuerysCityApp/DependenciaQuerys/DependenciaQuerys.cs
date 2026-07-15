using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DependenciaQuerys.Delete;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DependenciaQuerys.Insert;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DependenciaQuerys.Select;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DependenciaQuerys.Update;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.DependenciaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DependenciaQuerys
{
    public class DependenciaQuerys
    {
        private DependenciaDelete DependenciaDelete;
        private DependenciaInsert DependenciaInsert;
        private DependenciaSelect DependenciaSelect;
        private DependenciasSelect DependenciasSelect;
        private IdsDependenciasSelect IdsDependenciasSelect;
        private DependenciaUpdate DependenciaUpdate;

        public DependenciaQuerys(CityAppContext cityAppContext)
        {
            DependenciaDelete = new DependenciaDelete(cityAppContext);
            DependenciaInsert = new DependenciaInsert(cityAppContext);
            DependenciaSelect = new DependenciaSelect(cityAppContext);
            DependenciasSelect = new DependenciasSelect(cityAppContext);
            IdsDependenciasSelect = new IdsDependenciasSelect(cityAppContext);
            DependenciaUpdate = new DependenciaUpdate(cityAppContext);
        }

        //Delete
        public Response<object> DeleteDependencia(Dependencia dependencia)
        {
            return DependenciaDelete.DeleteDependencia(dependencia);
        }

        //Insert
        public Response<object> InsertDependencia(Dependencia dependencia)
        {
            return DependenciaInsert.InsertDependencia(dependencia);
        }

        //Select
        public Response<Dependencia> SelectDependenciaIdDependencia(int idDependencia)
        {
            return DependenciaSelect.SelectDependenciaIdDependencia(idDependencia);
        }
        public Response<IEnumerable<int>> SelectIdsDependenciasIdSecretaria(int idSecretaria)
        {
            return IdsDependenciasSelect.SelectIdsDependenciasIdSecretaria(idSecretaria);
        }
        public Response<IEnumerable<Dependencia>> SelectDependencia(int idSecretaria)
        {
            return DependenciasSelect.SelectDependencias(idSecretaria);
        }
        public Response<IEnumerable<Dependencia>> SelectDependenciaFirltroDependencia(FiltroDependencia filtroDependencia)
        {
            return DependenciasSelect.SelectSecretariasFirltoSecretaria(filtroDependencia);
        }

        //Update
        public Response<object> UpdateDependencia(Dependencia dependencia)
        {
            return DependenciaUpdate.UpdateDependencia(dependencia);    
        }
    }
}
