using CityApp.Server.Logic.NoticiaLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.NoticiaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using CityApp.Shared.Models.FacebookModels.Publicacion;
using Microsoft.AspNetCore.Mvc;

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiaController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public NoticiaController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearNoticia")]
        public IActionResult CrearNoticia([FromBody] Peticion<Noticia> peticion)
        {
            Response<int> response = new Response<int>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearNoticiaLogic crearNoticiaLogic = new CrearNoticiaLogic(CityAppContext, peticion.Data);
                response = crearNoticiaLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarNoticias")]
        public IActionResult ConsultarNoticias([FromBody] Peticion<FiltroNoticias> peticion)
        {
            Response<List<Noticia>> response = new Response<List<Noticia>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarNoticiasLogic consultarNoticiasLogic = new ConsultarNoticiasLogic(CityAppContext, peticion.Data);
                response = consultarNoticiasLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarNoticia")]
        public IActionResult ConsultarNoticia([FromBody] Peticion<int> peticion)
        {
            Response<Noticia> response = new Response<Noticia>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarNoticiaLogic consultarNoticiaLogic = new ConsultarNoticiaLogic(CityAppContext, peticion.Data);
                response = consultarNoticiaLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("EditarNoticia")]
        public IActionResult EditarNoticia([FromBody] Peticion<Noticia> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EditarNoticiaLogic editarNoticiaLogic = new EditarNoticiaLogic(CityAppContext, peticion.Data);
                response = editarNoticiaLogic.Editar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("EliminarNoticia")]
        public IActionResult EliminarNoticia([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarNoticiaLogic eliminarNoticiaLogic = new EliminarNoticiaLogic(CityAppContext, peticion.Data);
                response = eliminarNoticiaLogic.Eliminar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("PublicarNoticiaFacebook")]
        public async Task<IActionResult> PublicarNoticiaFacebook([FromBody] Peticion<int> peticion)
        {
            Response<string> response = new Response<string>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                PublicarNoticiaFacebookLogic publicarNoticiaFacebookLogic = new PublicarNoticiaFacebookLogic(CityAppContext, peticion.Data, peticion.Identificador);
                response = await publicarNoticiaFacebookLogic.Publicar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
