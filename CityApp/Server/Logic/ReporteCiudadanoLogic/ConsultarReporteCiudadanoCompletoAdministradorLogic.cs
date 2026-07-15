using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.CuentaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EvidenciaReporteCiudadanoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.EvidenciaSolucionReporteCiudadanoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ReporteCiudadanoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoReporteCiudadanoQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.UsuarioQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.VercionReporteCiudadanoQuerys;
using CityApp.Server.Servicios.CollectionsWork;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.ControllersModels.ReporteCiudadanoEntradaModels;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ReporteCiudadanoLogic
{
    public class ConsultarReporteCiudadanoCompletoAdministradorLogic
    {
        private ReporteCiudadanoQuerys ReporteCiudadanoQuerys;
        private EvidenciaReporteCiudadanoQuerys EvidenciaReporteCiudadanoQuerys;
        private CuentaQuerys CuentaQuerys;
        private UsuarioQuerys UsuarioQuerys;
        private ContactoQuerys ContactoQuerys;

        private ReporteCiudadano ReporteCiudadano;
        private Usuario Usuario;
        private int IdReporteCiudadano;

        public ConsultarReporteCiudadanoCompletoAdministradorLogic(CityAppContext cityAppContex, int idReporteCiudadano)
        {
            ReporteCiudadanoQuerys = new ReporteCiudadanoQuerys(cityAppContex);
            EvidenciaReporteCiudadanoQuerys = new EvidenciaReporteCiudadanoQuerys(cityAppContex);
            CuentaQuerys = new CuentaQuerys(cityAppContex);
            UsuarioQuerys = new UsuarioQuerys(cityAppContex);
            ContactoQuerys = new ContactoQuerys(cityAppContex);


            IdReporteCiudadano = idReporteCiudadano;
        }

        public Response<ReporteCiudadano> Consultar()
        {
            Response<ReporteCiudadano> response = new Response<ReporteCiudadano>();

            response = ReporteCiudadanoQuerys.SelectReporteCiudadanoCompletoIdReporteCiudadano(IdReporteCiudadano);
            if (response.Status.Exito == 1)
            {
                ReporteCiudadano = response.Data;
                Response<object> responseCargarData = CargarDataVercionReporteCiudadano();
                response.Status = responseCargarData.Status;
                if (response.Status.Exito == 1)
                {
                    response.Data = ReporteCiudadano;
                }
            }

            return response;
        }

        private Response<object> CargarDataVercionReporteCiudadano()
        {
            Response<object> response = new Response<object>();

            if (ReporteCiudadano.VercionesReporteCiudadano != null)
            {
                if (ReporteCiudadano.VercionesReporteCiudadano.Count > 0)
                {
                    for (int i = 0; i < ReporteCiudadano.VercionesReporteCiudadano.Count; i++)
                    {
                        response = CargarObjetosVercionReporteCiudadano(i);
                        if (response.Status.Exito != 1)
                        {
                            i = ReporteCiudadano.VercionesReporteCiudadano.Count;
                        }
                    }
                }
                else
                {
                    response.Status.Exito = 1;
                }
            }
            else
            {
                response.Status.Exito = 1;
            }

            return response;
        }

        private Response<object> CargarObjetosVercionReporteCiudadano(int i)
        {
            Response<object> response = new Response<object>();

            Response<IEnumerable<EvidenciaReporteCiudadano>> responseEvidenciasReporteCiudadano = EvidenciaReporteCiudadanoQuerys.SelectEvidenciasReporteCiudadanoIdVercionReporteCiudadano(ReporteCiudadano.VercionesReporteCiudadano[i].IdVercionReporteCiudadano);
            response.Status = responseEvidenciasReporteCiudadano.Status;
            if (response.Status.Exito == 1 || response.Status.Exito == 2)
            {
                ReporteCiudadano.VercionesReporteCiudadano[i].EvidenciasReporteCiudadano = responseEvidenciasReporteCiudadano.Data.ToList();
                Response<Usuario> responseUsuario = UsuarioQuerys.SelectUsuarioIdCuenta(ReporteCiudadano.VercionesReporteCiudadano[i].IdCuenta);
                Response<Contacto> responseContacto = ContactoQuerys.SelectContactoIdCenta(ReporteCiudadano.VercionesReporteCiudadano[i].IdCuenta);
                Response<string> responseNombre = CuentaQuerys.SelectNombreUsuarioIdCuenta(ReporteCiudadano.VercionesReporteCiudadano[i].IdCuenta);
                response.Status = responseNombre.Status;
                if (response.Status.Exito == 1)
                {
                    ReporteCiudadano.VercionesReporteCiudadano[i].Cuenta.Usuario = new Usuario()
                    {
                        Telefono = responseUsuario.Data.Telefono,
                        Direccion = responseUsuario.Data.Direccion,
                        Nombre = responseUsuario.Data.Nombre,
                        Apellidos = responseUsuario.Data.Apellidos,
                        //NombreUsuario = responseNombre.Data,
                        //Password = "",
                        
                    };
                    ReporteCiudadano.VercionesReporteCiudadano[i].Cuenta.Contacto = new Contacto()
                    {
                        Correo = responseContacto.Data.Correo,

                    };

                    //Response<Usuario> responseUsuario = UsuarioQuerys.SelectUsuarioIdCuenta(ReporteCiudadano.VercionesReporteCiudadano[i].IdCuenta);
                    //response.Status = responseUsuario.Status;
                    //if (response.Status.Exito == 1)
                    //{
                    //    //responseUsuario.Data = Usuario;
                    //    Usuario = responseUsuario.Data;
                    //}


                }
            }

            return response;
        }
    }
}
