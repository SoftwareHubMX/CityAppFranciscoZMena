using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoSolicitudPodaQuerys;
using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ArchivoSolicitudPodaLogic
{
    public class AgregarArchivoSolicitudPodaLogic
    {
        private ArchivoSolicitudPodaQuerys ArchivoSolicitudPodaQuerys;

        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private IFormFile File;
        private int IdCuenta;
        private ArchivoSolicitidPoda ArchivoSolicitidPoda;

        public AgregarArchivoSolicitudPodaLogic(CityAppContext cityAppContext, IFormFile file, int idSolictudPoda, int idCuenta)
        {
            ArchivoSolicitudPodaQuerys = new ArchivoSolicitudPodaQuerys(cityAppContext);

            File = file;
            IdCuenta = idCuenta;
            ArchivoSolicitidPoda = new ArchivoSolicitidPoda()
            {
                IdSolicitudPoda = idSolictudPoda
            };
        }

        public async Task<Response<string>> Guardar()
        {
            Response<string> response = new Response<string>();

            if (File != null)
            {
                Response<object> responseVerificarCarpeta = VerificarCrearCarpeta();
                response.Status = responseVerificarCarpeta.Status;
                if (response.Status.Exito == 1)
                {
                    Response<object> responseSaveFile = await SaveFile();
                    response.Status = responseSaveFile.Status;
                    if (response.Status.Exito == 1)
                    {
                        Response<object> responseInsert = ArchivoSolicitudPodaQuerys.InsertArchivoSolicitudPoda(ArchivoSolicitidPoda);
                        response.Status = responseInsert.Status;
                        if (response.Status.Exito == 1)
                        {
                            response.Data = ArchivoSolicitidPoda.Ruta;
                            Response<object> responseTemp = await SaveFileTemp();//temp
                            response.Status = responseTemp.Status;//temp
                        }
                    }
                }
            }
            else
            {
                response.Status.Mensaje = "No se encuentra el archivo";
                response.Status.Exito = 2;
            }

            return response;
        }

        private Response<object> VerificarCrearCarpeta()
        {
            string rutaCarpeta = Rutas.RutaMultimediaSolicitudes + ArchivoSolicitidPoda.IdSolicitudPoda;
            return ServicioFicheros.CarpetaCrear(rutaCarpeta);
        }

        private async Task<Response<object>> SaveFile()
        {
            Response<object> response = new Response<object>();

            string[] datosFile = File.FileName.Split('.');
            string nombreFile = "MultimediaDirectorio"
                + "_"
                + IdCuenta
                + "_" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-f-ff")
                + "." + datosFile[datosFile.Length - 1];

            ArchivoSolicitidPoda.Ruta = nombreFile;
            ArchivoSolicitidPoda.Formato = datosFile[datosFile.Length - 1];

            var filePath = Rutas.RutaMultimediaSolicitudes + ArchivoSolicitidPoda.IdSolicitudPoda + "\\" + nombreFile;

            response = await ServicioFicheros.ArchivoGuardar(File, filePath);

            return response;
        }

        private async Task<Response<object>> SaveFileTemp()//temporal method
        {
            Response<object> response = new Response<object>();

            string nombreFile = ArchivoSolicitidPoda.Ruta;

            var filePath = Rutas.RutaTemporal + nombreFile;

            response = await ServicioFicheros.ArchivoGuardar(File, filePath);

            return response;
        }//end temporal method
    }
}
