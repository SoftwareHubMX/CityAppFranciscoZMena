using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoAnuncioQuerys;
using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ArchivoAnuncioLogic
{
    public class AgregarArchivoAnuncioLogic
    {
        private ArchivoAnuncioQuerys ArchivoAnuncioQuerys;

        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private IFormFile File;
        private int IdCuenta;
        private ArchivoAnuncio ArchivoAnuncio;

        public AgregarArchivoAnuncioLogic(CityAppContext cityAppContext, IFormFile file, int idAnuncio, int idCuenta)
        {
            ArchivoAnuncioQuerys = new ArchivoAnuncioQuerys(cityAppContext);

            File = file;
            IdCuenta = idCuenta;
            ArchivoAnuncio = new ArchivoAnuncio()
            {
                IdAnuncio = idAnuncio
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
                        Response<object> responseInsert = ArchivoAnuncioQuerys.InsertArchivoAnuncio(ArchivoAnuncio);
                        response.Status = responseInsert.Status;
                        if (response.Status.Exito == 1)
                        {
                            response.Data = ArchivoAnuncio.Ruta;
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
            string rutaCarpeta = Rutas.RutaMultimediaArchivoAnuncio + ArchivoAnuncio.IdAnuncio;
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

            ArchivoAnuncio.Ruta = nombreFile;
            ArchivoAnuncio.Formato = datosFile[datosFile.Length - 1];

            var filePath = Rutas.RutaMultimediaArchivoAnuncio + ArchivoAnuncio.IdAnuncio + "\\" + nombreFile;

            response = await ServicioFicheros.ArchivoGuardar(File, filePath);

            return response;
        }

        private async Task<Response<object>> SaveFileTemp()//temporal method
        {
            Response<object> response = new Response<object>();

            string nombreFile = ArchivoAnuncio.Ruta;

            var filePath = Rutas.RutaTemporal + nombreFile;

            response = await ServicioFicheros.ArchivoGuardar(File, filePath);

            return response;
        }//end temporal method
    }
}
