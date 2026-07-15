using CityApp.Server.Logic.PagoLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.PagoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using CityApp.Shared.Models.PayModel;
using Microsoft.AspNetCore.Mvc;

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public PagoController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("CrearPago")]
        public IActionResult CrearPago([FromBody] Peticion<CrearPago> peticion)
        {
            Response<PagoTarjeta> response = new Response<PagoTarjeta>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                CrearPagoLogic crearPagoLogic = new CrearPagoLogic(CityAppContext, peticion.Data, responseValidarPeticion.Data);
                response = crearPagoLogic.Crear();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarPagosAdministrador")]
        public IActionResult ConsultarPagosAdministrador([FromBody] Peticion<FiltroPagos> peticion)
        {
            Response<List<Pago>> response = new Response<List<Pago>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarPagosAdministradorLogic consultarPagosAdministradorLogic = new ConsultarPagosAdministradorLogic(CityAppContext, peticion.Data);
                response = consultarPagosAdministradorLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarPagosUsuario")]
        public IActionResult ConsultarPagosUsuario([FromBody] Peticion<FiltroPagos> peticion)
        {
            Response<List<Pago>> response = new Response<List<Pago>>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarPagosUsuarioLogic consultarPagosUsuarioLogic = new ConsultarPagosUsuarioLogic(CityAppContext, peticion.Data, responseValidarPeticion.Data);
                response = consultarPagosUsuarioLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ActualizarPago")]
        public IActionResult ActualizarPago([FromBody] Peticion<Pago> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ActualizarPagoLogic actualizarPagoLogic = new ActualizarPagoLogic(CityAppContext, peticion.Data);
                response = actualizarPagoLogic.Actualizar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("ConsultarPago")]
        public IActionResult ConsultarPago([FromBody] Peticion<int> peticion)
        {
            Response<Pago> response = new Response<Pago>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuth(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                ConsultarPagoLogic consultarPagoLogic = new ConsultarPagoLogic(CityAppContext, peticion.Data);
                response = consultarPagoLogic.Consultar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("EliminarPago")]
        public IActionResult EliminarPago([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarPagoLogic actualizarPagoLogic = new EliminarPagoLogic(CityAppContext, peticion.Data);
                response = actualizarPagoLogic.Eliminar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
