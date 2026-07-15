using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.Fichero
{
    public class ServicioFicheros
    {
        private CrearCarpeta CrearCarpeta = new CrearCarpeta();
        private EliminarArchivo EliminarArchivo = new EliminarArchivo();
        private EliminarCarpeta EliminarCarpeta = new EliminarCarpeta();
        private GuardarArchivo GuardarArchivo = new GuardarArchivo();
        private LeerArchivo LeerArchivo = new LeerArchivo();
        private RenombrarArchivo RenombrarArchivo = new RenombrarArchivo();
        private RenombrarCarpeta RenombrarCarpeta = new RenombrarCarpeta();
        private CopiarArchivo CopiarArchivo = new CopiarArchivo();

        public Response<object> CarpetaCrear(string ruta)
        {
            return CrearCarpeta.Crear(ruta);
        }
        public Response<object> CarpetaRenombrar(string ruta, string nuevaRuta)
        {
            return RenombrarCarpeta.Renombrar(ruta, nuevaRuta);
        }
        public Response<object> CarpetaEliminar(string ruta)
        {
            return EliminarCarpeta.Eliminar(ruta);
        }

        public async Task<Response<object>> ArchivoGuardar(IFormFile file, string ruta)
        {
            return await GuardarArchivo.Guardar(file, ruta);
        }
        public Response<object> ArchivoRenombrar(string ruta, string nuevaRuta)
        {
            return RenombrarArchivo.Renombrar(ruta, nuevaRuta);
        }
        public Response<byte[]> ArchivoLeer(string ruta)
        {
            return LeerArchivo.Leer(ruta);
        }
        public Response<object> ArchivoEliminar(string ruta)
        {
            return EliminarArchivo.Eliminar(ruta);
        }
        public Response<object> Copiar(string rutaI, string rutaO)
        {
            return CopiarArchivo.Copiar(rutaI, rutaO);
        }

    }
}
