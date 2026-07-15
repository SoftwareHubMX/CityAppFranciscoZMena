using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoSliderQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.SliderQuerys;
using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.SliderLogic
{
    public class EliminarSliderLogic
    {
        private SliderQuerys SliderQuerys;
        private ArchivoSliderQuerys ArchivoSliderQuerys;

        private ServicioFicheros ServicioFicheros = new ServicioFicheros();

        private Slider Slider;

        public EliminarSliderLogic(CityAppContext cityAppContext, int idSlider)
        {
            SliderQuerys = new SliderQuerys(cityAppContext);
            ArchivoSliderQuerys = new ArchivoSliderQuerys(cityAppContext);

            Slider = new Slider()
            {
                IdSlider = idSlider,
            };
        }

        public Response<object> Eliminar()
        {
            Response<object> response = new Response<object>();

            Response<Slider> responseNotica = SliderQuerys.SelectSliderIdSlider(Slider.IdSlider);
            response.Status = responseNotica.Status;
            if (response.Status.Exito == 1)
            {
                Slider = responseNotica.Data;
                response = EliminarListaArchivos();
                if (response.Status.Exito == 1)
                {
                    response = SliderQuerys.DeleteSlider(responseNotica.Data);
                }
            }

            return response;
        }

        private Response<object> EliminarListaArchivos()
        {
            Response<object> response = new Response<object>();

            Response<IEnumerable<ArchivoSlider>> responseArchivosSlider = ArchivoSliderQuerys.SelectArchivosSliderIdSlider(Slider.IdSlider);
            response.Status = responseArchivosSlider.Status;
            if (response.Status.Exito == 1)
            {
                Slider.ArchivosSlider = responseArchivosSlider.Data.ToList();
                response = EliminarFicheros();
                if (response.Status.Exito == 1)
                {
                    response = ArchivoSliderQuerys.DeleteArchivosSlider(responseArchivosSlider.Data);
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

            foreach (var archivo in Slider.ArchivosSlider)
            {
                string ruta = Rutas.RutaMultimediaSliders + Slider.IdSlider + "\\" + archivo.Ruta;
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
