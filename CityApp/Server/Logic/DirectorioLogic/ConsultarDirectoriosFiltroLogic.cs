using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoDirectorioQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.DirectorioQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.DirectorioEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.DirectorioLogic
{
    public class ConsultarDirectoriosFiltroLogic
    {
        private DirectorioQuerys DirectorioQuerys;
        private ArchivoDirectorioQuerys ArchivoDirectorioQuerys;
        private List<Directorio> Directorio = new List<Directorio>();
        private FiltroDirectorio FiltroDirectorio = new FiltroDirectorio();


        public ConsultarDirectoriosFiltroLogic(CityAppContext cityAppContex, FiltroDirectorio filtroDirectorio)
        {
            DirectorioQuerys = new DirectorioQuerys(cityAppContex);
            ArchivoDirectorioQuerys = new ArchivoDirectorioQuerys(cityAppContex);
            FiltroDirectorio = filtroDirectorio;
        }

        public Response<List<Directorio>> Consultar()
        {
            Response<List<Directorio>> response = new Response<List<Directorio>>();

            Response<IEnumerable<Directorio>> responseDirectorio = DirectorioQuerys.SelectDirectoriosFirltoDirectorio(FiltroDirectorio);
            response.Status = responseDirectorio.Status;
            if (response.Status.Exito == 1)
            {
                response.Data = new List<Directorio>();
                response.Data = responseDirectorio.Data.ToList();
                response.Info = new Info();
                response.Info = responseDirectorio.Info;
                for(int i = 0; i < response.Data.Count; i++)
                {
                    Response<IEnumerable<ArchivoDirectorio>> responseArchivos = new Response<IEnumerable<ArchivoDirectorio>>();
                    responseArchivos = ArchivoDirectorioQuerys.SelectArchivosDirectorioIdDirectorio(response.Data[i].IdDirectorio);
                    if(responseArchivos.Status.Exito == 1)
                    {
                        response.Data[i].ArchivosDirectorio = new List<ArchivoDirectorio>();
                        response.Data[i].ArchivosDirectorio = responseArchivos.Data.ToList();
                    }
                }
            }

            return response;
        }
    }
}
