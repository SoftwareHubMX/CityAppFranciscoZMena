using CityApp.Server.Logic.CitaLogic;
using CityApp.Server.Logic.CuentaLogic;
using CityApp.Server.Logic.ReporteCiudadanoLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.CitaEndradaModels;
using CityApp.Shared.Models.ControllersModels.CuentaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public CuentaController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearCuenta")]
        public IActionResult CrearCuenta([FromBody] Peticion<CrearCuenta> peticion)
        {
            Response<object> response = new Response<object>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearCuentaLogic crearCuentaLogic = new CrearCuentaLogic(CityAppContext, peticion.Data);
                response = crearCuentaLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
        [HttpPost("CrearCuentaChofer")]
        public IActionResult CrearCuentaChofer([FromBody] Peticion<CrearCuenta> peticion)
        {
            Response<object> response = new Response<object>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearCuentaChoferLogic crearCuentaChoferLogic = new CrearCuentaChoferLogic(CityAppContext, peticion.Data);
                response = crearCuentaChoferLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("RecuperarPassword")]
        public IActionResult RecuperarPassword([FromBody] Peticion<RecuperacionPassword> peticion)
        {
            Response<object> response = new Response<object>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                RecuperarPasswordLogic recuperarPasswordLogic = new RecuperarPasswordLogic(CityAppContext, peticion.Data);
                response = recuperarPasswordLogic.Recuperar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ActualizarNombreUsuario")]
        public IActionResult ActualizarNombreUsuario([FromBody] Peticion<string> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ActualizarNombreUsuarioLogic actualizarNombreUsuarioLogic = new ActualizarNombreUsuarioLogic(CityAppContext, peticion.Data, responseValidarPeticion.Data);
                response = actualizarNombreUsuarioLogic.Actualizar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ActualizarPassword")]
        public IActionResult ActualizarPassword([FromBody] Peticion<ActualizarPassword> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ActualizarPasswordLogic actualizarPasswordLogic = new ActualizarPasswordLogic(CityAppContext, peticion.Data, responseValidarPeticion.Data);
                response = actualizarPasswordLogic.Actualizar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarCuentas")]
        public IActionResult ConsultarCuentas([FromBody] Peticion<Cuenta> peticion)
        {
            Response<List<Cuenta>> response = new Response<List<Cuenta>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarCuentasLogic consultarCuentasLogic = new ConsultarCuentasLogic(CityAppContext);
                response = consultarCuentasLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
        [HttpPost("ActualizarEstatusActivo")]
        public IActionResult ActualizarEstatusActivo([FromBody] Peticion<bool> peticion)
        {
            Response<object> response = new Response<object>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ActualizarEstatusActivoLogic actualizarEstatusActivoLogic = new ActualizarEstatusActivoLogic(CityAppContext, int.Parse(peticion.Identificador), peticion.Data);
                response = actualizarEstatusActivoLogic.Actualizar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
        [HttpPost("ConsultarCuentasFiltroCuentas")]
        public IActionResult ConsultarCuentasFiltroCuentas([FromBody] Peticion<FiltroCuentas> peticion)
        {
            Response<List<Cuenta>> response = new Response<List<Cuenta>>();
            Response<object> responseValidarPeticion = ServicioValidarPeticionSimple.Validar(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarCuentasFiltroCuentasLogic consultarCuentasFiltroCuentasLogic = new ConsultarCuentasFiltroCuentasLogic(CityAppContext, peticion.Data);
                response = consultarCuentasFiltroCuentasLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
