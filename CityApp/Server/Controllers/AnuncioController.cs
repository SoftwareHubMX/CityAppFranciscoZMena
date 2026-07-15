using CityApp.Server.Logic.AnuncioLogic;
using CityApp.Server.Logic.DirectorioLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.AnunciaoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnuncioController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public AnuncioController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearAnuncio")]
        public IActionResult CrearAnuncio([FromBody] Peticion<Anuncio> peticion)
        {
            Response<int> response = new Response<int>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearAnuncioLogic crearAnuncioLogic = new CrearAnuncioLogic(CityAppContext, peticion.Data);
                response = crearAnuncioLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("EditarAnuncio")]
        public IActionResult EditarAnuncio([FromBody] Peticion<Anuncio> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EditarAnuncioLogic editarAnuncioLogic = new EditarAnuncioLogic(CityAppContext, peticion.Data);
                response = editarAnuncioLogic.Editar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarAnunciosFiltro")]
        public IActionResult ConsultarAnunciosFiltro([FromBody] Peticion<FiltroAnuncio> peticion)
        {
            Response<List<Anuncio>> response = new Response<List<Anuncio>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarAnunciosFiltroLogic consultarAnunciosFiltroLogic = new ConsultarAnunciosFiltroLogic(CityAppContext, peticion.Data);
                response = consultarAnunciosFiltroLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarAnuncio")]
        public IActionResult ConsultarAnuncio([FromBody] Peticion<int> peticion)
        {
            Response<Anuncio> response = new Response<Anuncio>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarAnuncioLogic consultarAnuncioLogic = new ConsultarAnuncioLogic(CityAppContext, peticion.Data);
                response = consultarAnuncioLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarAnuncioApp")]
        public IActionResult ConsultarAnuncioApp([FromBody] Peticion<object> peticion)
        {
            Response<List<Anuncio>> response = new Response<List<Anuncio>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarAnuncioAppLogic consultarAnuncioAppLogic = new ConsultarAnuncioAppLogic(CityAppContext);
                response = consultarAnuncioAppLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("EliminarAnuncio")]
        public IActionResult EliminarAnuncio([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarAnuncioLogic eliminarAnuncioLogic = new EliminarAnuncioLogic(CityAppContext, peticion.Data);
                response = eliminarAnuncioLogic.Eliminar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
