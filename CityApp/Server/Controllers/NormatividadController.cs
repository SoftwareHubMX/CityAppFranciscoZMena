using CityApp.Server.Logic.ArchivoAgendaLogic;
using CityApp.Server.Logic.NormatividadLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.SeguridadPublicaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NormatividadController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public NormatividadController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearNormatividad")]
        public IActionResult CrearNormatividad([FromBody] Peticion<Normatividad> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearNormatividadLogic crearNormatividadLogic = new CrearNormatividadLogic(CityAppContext, peticion.Data);
                response = crearNormatividadLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarNormatividades")]
        public IActionResult ConsultarNormatividades([FromBody] Peticion<object> peticion)
        {
            Response<List<Normatividad>> response = new Response<List<Normatividad>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarNormatividadesLogic consultarNormatividadsLogic = new ConsultarNormatividadesLogic(CityAppContext);
                response = consultarNormatividadsLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarNormatividad")]
        public IActionResult ConsultarNormatividad([FromBody] Peticion<int> peticion)
        {
            Response<Normatividad> response = new Response<Normatividad>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarNormatividadLogic consultarNormatividadLogic = new ConsultarNormatividadLogic(CityAppContext, peticion.Data);
                response = consultarNormatividadLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ActualizarNormatividad")]
        public IActionResult ActualizarNormatividad([FromBody] Peticion<Normatividad> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ActualizarNormatividadLogic actualizarNormatividadLogic = new ActualizarNormatividadLogic(CityAppContext, peticion.Data);
                response = actualizarNormatividadLogic.Actualizar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("EliminarNormatividad")]
        public IActionResult EliminarNormatividad([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarNormatividadLogic eliminarNormatividadLogic = new EliminarNormatividadLogic(CityAppContext, peticion.Data);
                response = eliminarNormatividadLogic.Eliminar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("AgregarArchivoNormatividad/{token}")]
        public async Task<IActionResult> AgregarArchivoNormatividad(string token, [FromForm] IFormFile file)
        {
            Response<string> response = new Response<string>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                AgregarArchivoNormatividadLogic agregarArchivoNormatividadLogic = new AgregarArchivoNormatividadLogic(CityAppContext, file);
                response = await agregarArchivoNormatividadLogic.Guardar();
            }
            return Ok(response);
        }

        [HttpPost("DescargarArchivoNormatividad")]
        public IActionResult DescargarArchivoNormatividad([FromBody] Peticion<string> peticion)
        {
            Response<byte[]> response = new Response<byte[]>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                DescargarArchivoNormatividadLogic descargarArchivoNormatividadLogic = new DescargarArchivoNormatividadLogic(peticion.Data);
                response = descargarArchivoNormatividadLogic.Descargar();
            }
            return Ok(response);
        }

        [HttpPost("EliminarArchivoNormatividad")]
        public IActionResult EliminarArchivoNormatividad([FromBody] Peticion<string> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarArchivoNormatividadLogic eliminarArchivoNormatividadLogic = new EliminarArchivoNormatividadLogic(CityAppContext, peticion.Data);
                response = eliminarArchivoNormatividadLogic.Eliminar();
            }
            return Ok(response);
        }
    }
}
