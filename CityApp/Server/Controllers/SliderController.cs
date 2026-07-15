using CityApp.Server.Logic.SliderLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public SliderController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearSlider")]
        public IActionResult CrearSlider([FromBody] Peticion<Slider> peticion)
        {
            Response<int> response = new Response<int>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearSliderLogic crearSliderLogic = new CrearSliderLogic(CityAppContext, peticion.Data);
                response = crearSliderLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarSliders")]
        public IActionResult ConsultarSliders([FromBody] Peticion<object> peticion)
        {
            Response<List<Slider>> response = new Response<List<Slider>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarSlidersLogic consultarSlidersLogic = new ConsultarSlidersLogic(CityAppContext);
                response = consultarSlidersLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarSlider")]
        public IActionResult ConsultarSlider([FromBody] Peticion<int> peticion)
        {
            Response<Slider> response = new Response<Slider>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarSliderLogic consultarSliderLogic = new ConsultarSliderLogic(CityAppContext, peticion.Data);
                response = consultarSliderLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarSliderApp")]
        public IActionResult ConsultarSliderApp([FromBody] Peticion<int> peticion)
        {
            Response<Slider> response = new Response<Slider>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarSliderAppLogic consultarSliderAppLogic = new ConsultarSliderAppLogic(CityAppContext, peticion.Data);
                response = consultarSliderAppLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("EliminarSlider")]
        public IActionResult EliminarSlider([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarSliderLogic eliminarSliderLogic = new EliminarSliderLogic(CityAppContext, peticion.Data);
                response = eliminarSliderLogic.Eliminar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
