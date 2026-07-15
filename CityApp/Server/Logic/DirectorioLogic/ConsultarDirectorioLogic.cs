using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoDirectorioQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DirectorioQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.DirectorioLogic
{
    public class ConsultarDirectorioLogic
    {
        private DirectorioQuerys DirectorioQuerys;
        private ArchivoDirectorioQuerys ArchivoDirectorioQuerys;

        private int IdDirectorio= 0;
        private Directorio directorio = new Directorio();

        public ConsultarDirectorioLogic(CityAppContext cityAppContetx, int idDirectorio)
        {
            DirectorioQuerys = new DirectorioQuerys(cityAppContetx);
            ArchivoDirectorioQuerys = new ArchivoDirectorioQuerys(cityAppContetx);

            IdDirectorio = idDirectorio;
        }

        public Response<Directorio> Consultar()
        {
            Response<Directorio> response = new Response<Directorio>();

            response = DirectorioQuerys.SelectDirectorioIdDirectorio(IdDirectorio);
            if (response.Status.Exito == 1)
            {
                directorio = response.Data;
                Response<object> responseCargarListas = CargarArchivos();
                response.Status = responseCargarListas.Status;
                if (response.Status.Exito == 1)
                {
                    response.Data = directorio;
                }
            }

            return response;
        }

        private Response<object> CargarArchivos()
        {
            Response<object> response = new Response<object>();

            Response<IEnumerable<ArchivoDirectorio>> responseArchivoDirectorio = ArchivoDirectorioQuerys.SelectArchivosDirectorioIdDirectorio(IdDirectorio);
            response.Status = responseArchivoDirectorio.Status;
            if (response.Status.Exito == 1)
            {
                directorio.ArchivosDirectorio = new List<ArchivoDirectorio>();
                directorio.ArchivosDirectorio = responseArchivoDirectorio.Data.ToList();
            }
            else if (response.Status.Exito == 2)
            {
                response.Status.Exito = 1;
            }

            return response;
        }
    }
}
