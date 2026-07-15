using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoLugarTuristicoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.LugarTuristicoQuerys;
using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.LugarTuristicoLogic
{
    public class EliminaLugarTuristicoLogic
    {
        private LugarTuristicoQuerys LugarTuristicoQuerys;
        private ArchivoLugarTuristicoQuerys ArchivoLugarTuristicoQuerys;

        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private LugarTuristico LugarTuristico;

        public EliminaLugarTuristicoLogic(CityAppContext cityAppContext, int idLugarTuristico)
        {
            LugarTuristicoQuerys = new LugarTuristicoQuerys(cityAppContext);
            ArchivoLugarTuristicoQuerys = new ArchivoLugarTuristicoQuerys(cityAppContext);

            LugarTuristico = new LugarTuristico()
            {
                IdLugarTuristico = idLugarTuristico,
            };
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();

            Response<LugarTuristico> responseNotica = LugarTuristicoQuerys.SelectLugarTuristicoIdLugarTuristico(LugarTuristico.IdLugarTuristico);
            response.Status = responseNotica.Status;
            if (response.Status.Exito == 1)
            {
                LugarTuristico = responseNotica.Data;
                response = EliminarListaArchivos();
                if (response.Status.Exito == 1)
                {
                    response = LugarTuristicoQuerys.DeleteLugarTuristico(responseNotica.Data);
                }
            }

            return response;
        }

        private Response<object> EliminarListaArchivos()
        {
            Response<object> response = new Response<object>();

            Response<IEnumerable<ArchivoLugarTuristico>> responseArchivosLugarTuristico = ArchivoLugarTuristicoQuerys.SelectArchivosLugarTuristicoIdLugarTuristico(LugarTuristico.IdLugarTuristico);
            response.Status = responseArchivosLugarTuristico.Status;
            if (response.Status.Exito == 1)
            {
                LugarTuristico.ArchivosLugarTuristico = responseArchivosLugarTuristico.Data.ToList();
                response = EliminarFicheros();
                if (response.Status.Exito == 1)
                {
                    response = ArchivoLugarTuristicoQuerys.DeleteArchivosLugarTuristico(responseArchivosLugarTuristico.Data);
                }
            }
            else if (response.Status.Exito == 2)
            {
                response.Status.Exito = 1;
            }

            return response;
        }

        private Response<object> EliminarFicheros()
        {
            Response<object> response = new Response<object>();

            foreach (var archivo in LugarTuristico.ArchivosLugarTuristico)
            {
                string ruta = Rutas.RutaMultimediaTurismo + LugarTuristico.IdLugarTuristico + "\\" + archivo.Ruta;
                response = ServicioFicheros.ArchivoEliminar(ruta);
                if (response.Status.Exito != 1)
                {
                    break;
                }
            }

            return response;
        }
    }
}
