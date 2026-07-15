using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoHistoricoPredioQuerys;
using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ArchivoHistoricoPredioLogic
{
    public class AgregarArchivoHistoricoPredioLogic
    {
        private ArchivoHistoricoPredioQuerys ArchivoHistoricoPredioQuerys;

        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private IFormFile File;
        private int IdCuenta;
        private ArchivoHistoricoPredio ArchivoHistoricoPredio;

        public AgregarArchivoHistoricoPredioLogic(CityAppContext cityAppContext, IFormFile file, int idHistoricoPredio, int idCuenta)
        {
            ArchivoHistoricoPredioQuerys = new ArchivoHistoricoPredioQuerys(cityAppContext);

            File = file;
            IdCuenta = idCuenta;
            ArchivoHistoricoPredio = new ArchivoHistoricoPredio()
            {
                IdHistoricoPredio = idHistoricoPredio
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
                        Response<object> responseInsert = ArchivoHistoricoPredioQuerys.InsertArchivoHistoricoPredio(ArchivoHistoricoPredio);
                        response.Status = responseInsert.Status;
                        if (response.Status.Exito == 1)
                        {
                            response.Data = ArchivoHistoricoPredio.Ruta;
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
            string rutaCarpeta = Rutas.RutaHistoricosPredios;
            return ServicioFicheros.CarpetaCrear(rutaCarpeta);
        }

        private async Task<Response<object>> SaveFile()
        {
            Response<object> response = new Response<object>();

            string[] datosFile = File.FileName.Split('.');
            string nombreFile = "MultimediaHistoricoPredio"
                + "_"
                + IdCuenta
                + "_" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-f-ff")
                + "." + datosFile[datosFile.Length - 1];

            ArchivoHistoricoPredio.Ruta = nombreFile;
            ArchivoHistoricoPredio.Formato = datosFile[datosFile.Length - 1];

            var filePath = Rutas.RutaHistoricosPredios + nombreFile;

            response = await ServicioFicheros.ArchivoGuardar(File, filePath);

            return response;
        }

        private async Task<Response<object>> SaveFileTemp()//temporal method
        {
            Response<object> response = new Response<object>();

            string nombreFile = ArchivoHistoricoPredio.Ruta;

            var filePath = Rutas.RutaTemporal + nombreFile;

            response = await ServicioFicheros.ArchivoGuardar(File, filePath);

            return response;
        }//end temporal method
    }
}
