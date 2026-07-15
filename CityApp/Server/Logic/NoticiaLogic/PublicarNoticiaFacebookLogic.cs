using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ArchivoNoticiaQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.NoticiaQuerys;
using CityApp.Server.Servicios.Facebook;
using CityApp.Server.Servicios.Fichero;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Helpers;
using CityApp.Shared.Models.DataValuesModels;
using CityApp.Shared.Models.FacebookModels.LoginResponse;
using CityApp.Shared.Models.FacebookModels.PaginaResponse;
using CityApp.Shared.Models.FacebookModels.Publicacion;

namespace CityApp.Server.Logic.NoticiaLogic
{
    public class PublicarNoticiaFacebookLogic
    {
        private NoticiaQuerys NoticiaQuerys;
        private ArchivoNoticiaQuerys ArchivoNoticiaQuerys;

        private ServicioFicheros ServicioFicheros = new ServicioFicheros();
        private ConsultarPerfilFacebook ConsultarPerfilFacebook = new ConsultarPerfilFacebook();
        private ConsultarPaginaFacebook ConsultarPaginaFacebook = new ConsultarPaginaFacebook();
        private PublicarNormal PublicarNormal = new PublicarNormal();
        private PublicarImagen PublicarImagen = new PublicarImagen();

        private int IdNoticia;
        private string Token;
        private Noticia Noticia;
        private List<ArchivoNoticia> ArchivosNoticia;
        private PerfilFacebook PerfilFacebook;
        private PaginaResponse PaginaResponse;
        private string IdPublicacion;

        public PublicarNoticiaFacebookLogic(CityAppContext cityAppContext, int idNoticia, string token)
        {
            NoticiaQuerys = new NoticiaQuerys(cityAppContext);
            ArchivoNoticiaQuerys = new ArchivoNoticiaQuerys(cityAppContext);

            IdNoticia = idNoticia;
            Token = token.Substring(1, token.Length - 2);
        }

        public async Task<Response<string>> Publicar()
        {
            Response<string> response = new Response<string>();

            Response<object> responseConsultas = ConsultarNoticia();
            response.Status = responseConsultas.Status;
            if (response.Status.Exito == 1)
            {
                responseConsultas = ConsultarInformacionFacebook();
                response.Status = responseConsultas.Status;
                if (response.Status.Exito == 1)
                {
                    responseConsultas = await PublicarFacebook();
                    response.Status = responseConsultas.Status;
                    if (response.Status.Exito == 1)
                    {
                        Noticia.EnlaceFacebook = IdPublicacion;
                        Response<object> responseUpdateNoticia = NoticiaQuerys.UpdateNoticia(Noticia);
                        response.Status = responseUpdateNoticia.Status;
                        if (response.Status.Exito == 1)
                        {
                            response.Data = IdPublicacion;
                        }
                    }
                }
            }

            return response;
        }

        private Response<object> ConsultarNoticia()
        {
            Response<object> response = new Response<object>();

            Response<Noticia> responseNoticia = NoticiaQuerys.SelectNoticiaIdNoticia(IdNoticia);
            response.Status = responseNoticia.Status;
            if (response.Status.Exito == 1)
            {
                Noticia = responseNoticia.Data;
                response = CargarArchivos();
            }

            return response;
        }

        private Response<object> CargarArchivos()
        {
            Response<object> response = new Response<object>();

            Response<IEnumerable<ArchivoNoticia>> responseArchivoNoticia = ArchivoNoticiaQuerys.SelectArchivosNoticiaIdNoticia(IdNoticia);
            response.Status = responseArchivoNoticia.Status;
            if (response.Status.Exito == 1)
            {
                ArchivosNoticia = responseArchivoNoticia.Data.ToList();
            }
            else if (response.Status.Exito == 2)
            {
                response.Status.Exito = 1;
            }

            return response;
        }

        private Response<object> ConsultarInformacionFacebook()
        {
            Response<object> response = new Response<object>();

            Response<PerfilFacebook> responsePerfilFacebook = ConsultarPerfilFacebook.Consultar(Token);
            response.Status = responsePerfilFacebook.Status;
            if (response.Status.Exito == 1)
            {
                Response<PaginaResponse> responsePaginaFacebook = ConsultarPaginaFacebook.Consultar(Token);
                response.Status = responsePaginaFacebook.Status;
                if (response.Status.Exito == 1)
                {
                    PerfilFacebook = responsePerfilFacebook.Data;
                    PaginaResponse = responsePaginaFacebook.Data;
                }
            }

            return response;
        }

        private async Task<Response<object>> PublicarFacebook()
        {
            Response<object> response = new Response<object>();

            Response<PublicacionResponse> responsePublicacion = new Response<PublicacionResponse>();
            if (ArchivosNoticia != null)
            {
                if (ArchivosNoticia.Count > 0)
                {
                    response = await PublicarConImagen();
                }
                else
                {
                    response = await PublicarSoloTexto();
                }
            }
            else
            {
                response = await PublicarSoloTexto();
            }

            return response;
        }

        private async Task<Response<object>> PublicarSoloTexto()
        {
            Response<object> response = new Response<object>();

            Response<PublicacionResponse> responsePublicacion = await PublicarNormal.Publicar(PaginaResponse.data[0].access_token, Noticia.Titulo, PaginaResponse.data[0].id);
            response.Status = responsePublicacion.Status;
            if (response.Status.Exito == 1)
            {
                IdPublicacion = responsePublicacion.Data.id;
            }

            return response;
        }

        private async Task<Response<object>> PublicarConImagen()
        {
            Response<object> response = new Response<object>();

            response = CargarImagenTemporal();
            if (response.Status.Exito == 1)
            {
                Response<PublicacionResponse> responsePublicacion = await PublicarImagen.Publicar(PaginaResponse.data[0].access_token, Noticia.Titulo, ArchivosNoticia[0].Ruta, PaginaResponse.data[0].albums.data[0].id);
                response.Status = responsePublicacion.Status;
                if (response.Status.Exito == 1)
                {
                    IdPublicacion = responsePublicacion.Data.id;
                }
            }

            return response;
        }

        private Response<object> CargarImagenTemporal()
        {
            Response<object> response = new Response<object>();

            var rutaI = Rutas.RutaMultimediaNoticias + IdNoticia + "\\" + ArchivosNoticia[0].Ruta;
            var rutaO = Rutas.RutaTemporalArchivos + ArchivosNoticia[0].Ruta;

            response = ServicioFicheros.Copiar(rutaI, rutaO);

            return response;
        }
    }
}
