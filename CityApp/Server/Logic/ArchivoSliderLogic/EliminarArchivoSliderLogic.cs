using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoSliderQuerys;
using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ArchivoSliderLogic
{
    public class EliminarArchivoSliderLogic
    {
        private ArchivoSliderQuerys ArchivoSliderQuerys;

        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private int IdArchivoSlider;
        private ArchivoSlider ArchivoSlider;

        public EliminarArchivoSliderLogic(CityAppContext cityAppContext, int idArchivoSlider)
        {
            ArchivoSliderQuerys = new ArchivoSliderQuerys(cityAppContext);

            IdArchivoSlider = idArchivoSlider;
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();

            response = CargarArchivoSlider();
            if (response.Status.Exito == 1)
            {
                response = ArchivoSliderQuerys.DeleteArchivoSlider(ArchivoSlider);
                if (response.Status.Exito == 1)
                {
                    response = EliminarArchivo();
                }
            }

            return response;
        }

        private Response<object> CargarArchivoSlider()
        {
            Response<object> response = new Response<object>();

            Response<ArchivoSlider> responseArchivoSlider = ArchivoSliderQuerys.SelectArchivoSliderIdArchivoSlider(IdArchivoSlider);
            response.Status = responseArchivoSlider.Status;
            if (response.Status.Exito == 1)
            {
                ArchivoSlider = responseArchivoSlider.Data;
            }

            return response;
        }

        private Response<object> EliminarArchivo()
        {
            Response<object> response = new Response<object>();

            string ruta = Rutas.RutaMultimediaNoticias + ArchivoSlider.IdSlider + "\\" + ArchivoSlider.Ruta;
            response = ServicioFicheros.ArchivoEliminar(ruta);

            return response;
        }
    }
}
