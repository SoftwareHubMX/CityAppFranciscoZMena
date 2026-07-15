using CityApp.Server.Logic.ArchivoHistoricoPredioLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchivoHistoricoPredioController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public ArchivoHistoricoPredioController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("AgregarArchivoHistoricoPredio/{idHistoricoPredio}/{token}")]
        public async Task<IActionResult> AgregarArchivoHistoricoPredio(int idHistoricoPredio, string token, [FromForm] IFormFile file)
        {
            Response<string> response = new Response<string>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                AgregarArchivoHistoricoPredioLogic agregarArchivoHistoricoPredioLogic = new AgregarArchivoHistoricoPredioLogic(CityAppContext, file, idHistoricoPredio, responseValidarPeticion.Data);
                response = await agregarArchivoHistoricoPredioLogic.Guardar();
            }
            return Ok(response);
        }

        [HttpPost("DescargarArchivoHistoricoPredio")]
        public IActionResult DescargarArchivoHistoricoPredio([FromBody] Peticion<string> peticion)
        {
            Response<byte[]> response = new Response<byte[]>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                DescargarArchivoHistoricoPredioLogic descargarArchivoHistoricoPredioLogic = new DescargarArchivoHistoricoPredioLogic(peticion.Data, int.Parse(peticion.Identificador));
                response = descargarArchivoHistoricoPredioLogic.Descargar();
            }
            return Ok(response);
        }

        [HttpPost("EliminarArchivoHistoricoPredio")]
        public IActionResult EliminarArchivoHistoricoPredio([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarArchivoHistoricoPredioLogic eliminarArchivoHistoricoPredioLogic = new EliminarArchivoHistoricoPredioLogic(CityAppContext, peticion.Data);
                response = eliminarArchivoHistoricoPredioLogic.Eliminar();
            }
            return Ok(response);
        }

        [HttpPost("EliminraArchivoHistoricoPredioIdHistoricoPredio")]
        public IActionResult EliminraArchivoHistoricoPredioIdHistorico([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminraArchivoHistoricoPredioIdHistoricoPredioLogic eliminraArchivoHistoricoPredioIdHistoricoPredioLogic = new EliminraArchivoHistoricoPredioIdHistoricoPredioLogic(CityAppContext, peticion.Data);
                response = eliminraArchivoHistoricoPredioIdHistoricoPredioLogic.Eliminar();
            }
            return Ok(response);
        }

        [HttpPost("EliminarArchivoHistoricoPredioTercero")]
        public IActionResult EliminarArchivoHistoricoPredioTercero([FromBody] Peticion<object> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarArchivoHistoricoPredioTerceroLogic eliminarArchivoHistoricoPredioTerceroLogic = new EliminarArchivoHistoricoPredioTerceroLogic(CityAppContext);
                response = eliminarArchivoHistoricoPredioTerceroLogic.Eliminar();
            }
            return Ok(response);
        }
    }
}
