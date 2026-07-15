using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoLugarTuristicoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoNoticiaQuerys;
using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ArchivoLugarTuristicoLogic
{
    public class AgregarArchivoLugarTuristicoLogic
    {
        private ArchivoLugarTuristicoQuerys ArchivoLugarTuristicoQuerys;

        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private IFormFile File;
        private int IdCuenta;
        private ArchivoLugarTuristico ArchivoLugarTuristico;

        public AgregarArchivoLugarTuristicoLogic(CityAppContext cityAppContext, IFormFile file, int idLugarTuristico, int idCuenta)
        {
            ArchivoLugarTuristicoQuerys = new ArchivoLugarTuristicoQuerys(cityAppContext);

            File = file;
            IdCuenta = idCuenta;
            ArchivoLugarTuristico = new ArchivoLugarTuristico()
            {
                IdLugarTuristico = idLugarTuristico,
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
                        Response<object> responseInsert = ArchivoLugarTuristicoQuerys.InsertArchivoLugarTuristico(ArchivoLugarTuristico);
                        response.Status = responseInsert.Status;
                        if (response.Status.Exito == 1)
                        {
                            response.Data = ArchivoLugarTuristico.Ruta;
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
            string rutaCarpeta = Rutas.RutaMultimediaTurismo + ArchivoLugarTuristico.IdLugarTuristico;
            return ServicioFicheros.CarpetaCrear(rutaCarpeta);
        }

        private async Task<Response<object>> SaveFile()
        {
            Response<object> response = new Response<object>();

            string[] datosFile = File.FileName.Split('.');
            string nombreFile = "MultimediaTurismo"
                + "_"
                + IdCuenta
                + "_" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-f-ff")
                + "." + datosFile[datosFile.Length - 1];

            ArchivoLugarTuristico.Ruta = nombreFile;
            ArchivoLugarTuristico.Formato = datosFile[datosFile.Length - 1];

            var filePath = Rutas.RutaMultimediaTurismo + ArchivoLugarTuristico.IdLugarTuristico + "\\" + nombreFile;

            response = await ServicioFicheros.ArchivoGuardar(File, filePath);

            return response;
        }

        private async Task<Response<object>> SaveFileTemp()//temporal method
        {
            Response<object> response = new Response<object>();

            string nombreFile = ArchivoLugarTuristico.Ruta;

            var filePath = Rutas.RutaTemporal + nombreFile;

            response = await ServicioFicheros.ArchivoGuardar(File, filePath);

            return response;
        }//end temporal method
    }
}
