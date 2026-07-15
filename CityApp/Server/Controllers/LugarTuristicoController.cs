using CityApp.Server.Logic.LugarTuristicoLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.LugarTuristicoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LugarTuristicoController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public LugarTuristicoController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearLugarTuristico")]
        public IActionResult CrearLugarTuristico([FromBody] Peticion<CrearLugarTuristico> peticion)
        {
            Response<int> response = new Response<int>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearLugarTuristicoLogic crearLugarTuristicoLogic = new CrearLugarTuristicoLogic(CityAppContext, peticion.Data);
                response = crearLugarTuristicoLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarLugaresTuristicosFiltos")]
        public IActionResult ConsultarLugaresTuristicosFiltos([FromBody] Peticion<FiltroLugaresTuristicos> peticion)
        {
            Response<List<LugarTuristico>> response = new Response<List<LugarTuristico>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {

                ConsultarLugaresTuristicosFiltosLogic consultarLugaresTuristicosFiltosLogic = new ConsultarLugaresTuristicosFiltosLogic(CityAppContext, peticion.Data);
                response = consultarLugaresTuristicosFiltosLogic.Consultar();
                
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarLugaresTuristicosApp")]
        public IActionResult ConsultarLugaresTuristicosApp([FromBody] Peticion<FiltroLugaresTuristicos> peticion)
        {
            Response<List<LugarTuristico>> response = new Response<List<LugarTuristico>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarLugaresTuristicosAppLogic consultarLugaresTuristicosAppLogic = new ConsultarLugaresTuristicosAppLogic(CityAppContext, peticion.Data);
                response = consultarLugaresTuristicosAppLogic.Consultar();
                if (response.Status.Exito == 1 && response.Data != null && response.Data.Any())
                {
                    var lugaresTuristicosAleatorios = response.Data.OrderBy(x => Guid.NewGuid()).ToList(); 
                    response.Data = lugaresTuristicosAleatorios;
                }
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarLugarTuristico")]
        public IActionResult ConsultarLugarTuristico([FromBody] Peticion<int> peticion)
        {
            Response<LugarTuristico> response = new Response<LugarTuristico>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarLugarTuristicoLogic consultarLugarTuristicoLogic = new ConsultarLugarTuristicoLogic(CityAppContext, peticion.Data);
                response = consultarLugarTuristicoLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("EditarLugarTuristico")]
        public IActionResult EditarLugarTuristico([FromBody] Peticion<LugarTuristico> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EditarLugarTuristicoLogic editarLugarTuristicoLogic = new EditarLugarTuristicoLogic(CityAppContext, peticion.Data);
                response = editarLugarTuristicoLogic.Editar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("EliminarLugarTuristico")]
        public IActionResult EliminarLugarTuristico([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminaLugarTuristicoLogic eliminarLugarTuristicoLogic = new EliminaLugarTuristicoLogic(CityAppContext, peticion.Data);
                response = eliminarLugarTuristicoLogic.Eliminar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
