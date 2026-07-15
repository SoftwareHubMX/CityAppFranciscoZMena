using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EvidenciaSolucionReporteCiudadanoQuerys;
using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.EvidenciaSolucionReporteCiudadanoLogic
{
    public class AgregarEvidenciaSolucionReporteCiudadanoLogic
    {
        private EvidenciaSolucionReporteCiudadanoQuerys EvidenciaSolucionReporteCiudadanoQuerys;

        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private EvidenciaSolucionReporteCiudadano EvidenciaSolucionReporteCiudadano;
        private IFormFile File;

        public AgregarEvidenciaSolucionReporteCiudadanoLogic(CityAppContext cityAppContext, IFormFile file, int idReporteCiudadano, int idCuenta)
        {
            EvidenciaSolucionReporteCiudadanoQuerys = new EvidenciaSolucionReporteCiudadanoQuerys(cityAppContext);

            File = file;
            EvidenciaSolucionReporteCiudadano = new EvidenciaSolucionReporteCiudadano()
            {
                IdReporteCiudadano = idReporteCiudadano,
                IdCuenta = idCuenta,
                //Observaciones = observaciones,
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
                        Response<object> responseInsert = EvidenciaSolucionReporteCiudadanoQuerys.InsertEvidenciaReporteCiudadano(EvidenciaSolucionReporteCiudadano);
                        response.Status = responseInsert.Status;
                        if (response.Status.Exito == 1)
                        {
                            response.Data = EvidenciaSolucionReporteCiudadano.Ruta;
                            Response<object> responseTemporal = await SaveFileTemp();//temp
                            response.Status = responseTemporal.Status;//temp
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
            string rutaCarpeta = Rutas.RutaEvidenciaSolucionReporteCiudadano + EvidenciaSolucionReporteCiudadano.IdReporteCiudadano;
            return ServicioFicheros.CarpetaCrear(rutaCarpeta);
        }

        private async Task<Response<object>> SaveFile()
        {
            Response<object> response = new Response<object>();

            string[] datosFile = File.FileName.Split('.');
            string nombreFile = "EvidenciaSolucion_"
                + EvidenciaSolucionReporteCiudadano.IdCuenta
                + "_"
                + EvidenciaSolucionReporteCiudadano.IdReporteCiudadano
                + "_" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-f-ff")
                + "." + datosFile[datosFile.Length - 1];

            EvidenciaSolucionReporteCiudadano.Ruta = nombreFile;
            EvidenciaSolucionReporteCiudadano.Formato = datosFile[datosFile.Length - 1];

            var filePath = Rutas.RutaEvidenciaSolucionReporteCiudadano + EvidenciaSolucionReporteCiudadano.IdReporteCiudadano + "\\" + nombreFile;

            response = await ServicioFicheros.ArchivoGuardar(File, filePath);

            return response;
        }

        private async Task<Response<object>> SaveFileTemp()//temp
        {
            Response<object> response = new Response<object>();

            string nombreFile = EvidenciaSolucionReporteCiudadano.Ruta;

            var filePath = Rutas.RutaTemporal + nombreFile;

            response = await ServicioFicheros.ArchivoGuardar(File, filePath);

            return response;
        }//temp
    }
}
