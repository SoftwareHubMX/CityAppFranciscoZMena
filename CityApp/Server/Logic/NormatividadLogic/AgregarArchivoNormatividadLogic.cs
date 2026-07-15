using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoAgendaQuerys;
using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.NormatividadLogic
{
    public class AgregarArchivoNormatividadLogic
    {
        //private ArchivoAgendaQuerys ArchivoAgendaQuerys;

        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private IFormFile File;
        private string NombreArchivo;

        public AgregarArchivoNormatividadLogic(CityAppContext cityAppContext, IFormFile file)
        {
            //ArchivoAgendaQuerys = new ArchivoAgendaQuerys(cityAppContext);

            File = file;
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
                        response.Data = NombreArchivo;
                        Response<object> responseTemp = await SaveFileTemp();//temp
                        response.Status = responseTemp.Status;//temp
                        if (response.Status.Exito == 1)
                        {
                            Response<object> responsVerificarCarpetaPublic = VerificarCrearCarpetaPublic();
                            response.Status = responsVerificarCarpetaPublic.Status;
                            if(response.Status.Exito == 1)
                            {
                                Response<object> responsePublic = await SaveFilePublic();
                                response.Status = responsePublic.Status;
                            }
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
            string rutaCarpeta = Rutas.RutaMultimediaNormatividades;
            return ServicioFicheros.CarpetaCrear(rutaCarpeta);
        }

        private Response<object> VerificarCrearCarpetaPublic()
        {
            string rutaCarpeta = Rutas.RutaMultimediaNormatividadesPublic;
            return ServicioFicheros.CarpetaCrear(rutaCarpeta);
        }

        private async Task<Response<object>> SaveFile()
        {
            Response<object> response = new Response<object>();

            string[] datosFile = File.FileName.Split('.');
            string nombreFile = "MultimediaNormatividad"
                + "_" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-f-ff")
                + "." + datosFile[datosFile.Length - 1];

            NombreArchivo = nombreFile;

            var filePath = Rutas.RutaMultimediaNormatividades + "\\" + nombreFile;

            response = await ServicioFicheros.ArchivoGuardar(File, filePath);

            return response;
        }

        private async Task<Response<object>> SaveFileTemp()//temporal method
        {
            Response<object> response = new Response<object>();

            string nombreFile = NombreArchivo;

            var filePath = Rutas.RutaTemporal + nombreFile;

            response = await ServicioFicheros.ArchivoGuardar(File, filePath);

            return response;
        }//end temporal method

        private async Task<Response<object>> SaveFilePublic()//temporal method
        {
            Response<object> response = new Response<object>();

            string nombreFile = NombreArchivo;

            var filePath = Rutas.RutaMultimediaNormatividadesPublic + nombreFile;

            response = await ServicioFicheros.ArchivoGuardar(File, filePath);

            return response;
        }//end temporal method
    }
}
