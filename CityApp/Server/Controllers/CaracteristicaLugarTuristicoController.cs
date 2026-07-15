using CityApp.Server.Logic.CaracteristicaLugarTuristicoLogic;
using CityApp.Server.Logic.CuentaLogic;
using CityApp.Server.Servicios.Validaciones;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.CaracteristicaLugarTuristicoEntredaModels;
using CityApp.Shared.Models.ControllersModels.CuentaEntradaModels;
using CityApp.Shared.Models.DataValuesModels;
using Microsoft.AspNetCore.Mvc;

namespace CityApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaracteristicaLugarTuristicoController : ControllerBase
    {
        private ServicioValidarPeticionSimple ServicioValidarPeticionSimple = new ServicioValidarPeticionSimple();
        private ServicioValidarPeticion ServicioValidarPeticion;
        private CityAppContext CityAppContext;

        public CaracteristicaLugarTuristicoController(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
            ServicioValidarPeticion = new ServicioValidarPeticion(cityAppContext);
        }

        [HttpPost("AgregarCaracteristicaLugarTuristico")]
        public IActionResult AgregarCaracteristicaLugarTuristico([FromBody] Peticion<AgregarCaracteristicaLugarTuristico> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                AgregarCaracteristicaLugarTuristicoLogic agregarCaracteristicaLugarTuristicoLogic = new AgregarCaracteristicaLugarTuristicoLogic(CityAppContext, peticion.Data);
                response = agregarCaracteristicaLugarTuristicoLogic.Agregar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }

        [HttpPost("EliminarCaracteristicaLugarTuristico")]
        public IActionResult EliminarCaracteristicaLugarTuristico([FromBody] Peticion<int> peticion)
        {
            Response<object> response = new Response<object>();
            Response<int> responseValidarPeticion = ServicioValidarPeticion.ValidarAuthAdmin(peticion.Token);
            response.Status = responseValidarPeticion.Status;
            if (response.Status.Exito == 1)
            {
                EliminarCaracteristicaLugarTuristicoLogic eliminarCaracteristicaLugarTuristicoLogic = new EliminarCaracteristicaLugarTuristicoLogic(CityAppContext, peticion.Data);
                response = eliminarCaracteristicaLugarTuristicoLogic.Eliminar();
            }
            CityAppContext.Dispose();
            return Ok(response);
        }
    }
}
