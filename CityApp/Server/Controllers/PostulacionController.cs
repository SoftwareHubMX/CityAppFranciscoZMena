using CityApp.Server.Logic.PostulacionLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PostulacionEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostulacionController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public PostulacionController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearPostulacion")]
        public IActionResult CrearPostulacion([FromBody] Peticion<Postulacion> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearPostulacionLogic crearPostulacionLogic = new CrearPostulacionLogic(CityAppContext, peticion.Data);
                response = crearPostulacionLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarFiltroPostulacion")]
        public IActionResult ConsultarFiltroPostulacion([FromBody] Peticion<FiltroPostulacion> peticion)
        {
            Response<List<Postulacion>> response = new Response<List<Postulacion>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarFiltroPostulacionLogic consultarFiltroPostulacionLogic = new ConsultarFiltroPostulacionLogic(CityAppContext, peticion.Data);
                response = consultarFiltroPostulacionLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
