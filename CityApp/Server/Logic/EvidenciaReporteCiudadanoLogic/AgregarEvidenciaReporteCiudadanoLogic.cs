using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EvidenciaReporteCiudadanoQuerys;
using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.EvidenciaReporteCiudadanoLogic
{
    public class AgregarEvidenciaReporteCiudadanoLogic
    {
        private EvidenciaReporteCiudadanoQuerys EvidenciaReporteCiudadanoQuerys;

        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private EvidenciaReporteCiudadano EvidenciaReporteCiudadano;
        private IFormFile File;

        public AgregarEvidenciaReporteCiudadanoLogic(CityAppContext cityAppContext, IFormFile file, int idVercionReporteCiudadano)
        {
            EvidenciaReporteCiudadanoQuerys = new EvidenciaReporteCiudadanoQuerys(cityAppContext);

            File = file;
            EvidenciaReporteCiudadano = new EvidenciaReporteCiudadano()
            {
                IdVercionReporteCiudadano = idVercionReporteCiudadano,
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
                        Response<object> responseInsert = EvidenciaReporteCiudadanoQuerys.InsertEvidenciaReporteCiudadano(EvidenciaReporteCiudadano);
                        response.Status = responseInsert.Status;
                        if (response.Status.Exito == 1)
                        {
                            response.Data = EvidenciaReporteCiudadano.Ruta;
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
            string rutaCarpeta = Rutas.RutaEvidenciaReporteCiudadano + EvidenciaReporteCiudadano.IdVercionReporteCiudadano;
            return ServicioFicheros.CarpetaCrear(rutaCarpeta);
        }

        private async Task<Response<object>> SaveFile()
        {
            Response<object> response = new Response<object>();

            string[] datosFile = File.FileName.Split('.');
            string nombreFile = "EvidenciaProblema_"
                + EvidenciaReporteCiudadano.IdVercionReporteCiudadano
                + "_" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-f-ff")
                + "." + datosFile[datosFile.Length - 1];

            EvidenciaReporteCiudadano.Ruta = nombreFile;
            EvidenciaReporteCiudadano.Formato = datosFile[datosFile.Length - 1];

            var filePath = Rutas.RutaEvidenciaReporteCiudadano + EvidenciaReporteCiudadano.IdVercionReporteCiudadano + "\\" + nombreFile;

            response = await ServicioFicheros.ArchivoGuardar(File, filePath);

            return response;
        }

        private async Task<Response<object>> SaveFileTemp()//temporal method
        {
            Response<object> response = new Response<object>();

            string nombreFile = EvidenciaReporteCiudadano.Ruta;

            var filePath = Rutas.RutaTemporal + nombreFile;

            response = await ServicioFicheros.ArchivoGuardar(File, filePath);

            return response;
        }//end temporal method
    }
}
