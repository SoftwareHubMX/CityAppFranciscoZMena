using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoMunicipioQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.RedSocialMunicipioQuerys;
using CityApp.Server.Servicios.BDCityApp.QuerysCityApp.TipoRedSocialQuerys;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Logic.ContactoMunicipioLogic
{
    public class ConsultarContactoMunicipioLogic
    {
        private ContactoMunicipioQuerys ContactoMunicipioQuerys;
        private RedSocialMunicipioQuerys RedSocialMunicipioQuerys;
        private TipoRedSocialQuerys TipoRedSocialQuerys;
        private int IdContactoMunicipio = 0;

        public ConsultarContactoMunicipioLogic(CityAppContext cityAppContext, int idContactoMunicipio)
        {
            ContactoMunicipioQuerys = new ContactoMunicipioQuerys(cityAppContext);
            RedSocialMunicipioQuerys = new RedSocialMunicipioQuerys(cityAppContext);
            TipoRedSocialQuerys = new TipoRedSocialQuerys(cityAppContext);

            IdContactoMunicipio = idContactoMunicipio;
        }

        public Response<ContactoMunicipio> Consultar()
        {
            Response<ContactoMunicipio> response = new Response<ContactoMunicipio>();
            response = ContactoMunicipioQuerys.SelectContactoMunicipioIdContactoMunicipio(IdContactoMunicipio);
            if (response.Status.Exito == 1)
            {
                Response<IEnumerable<RedSocialMunicipio>> responseRedesSocialesMunicipio = new Response<IEnumerable<RedSocialMunicipio>>();
                responseRedesSocialesMunicipio = RedSocialMunicipioQuerys.SelectRedesSocialesMunicipio(response.Data.IdContactoMunicipio);
                response.Status = responseRedesSocialesMunicipio.Status;
                if (response.Status.Exito == 1)
                {
                    response.Data.RedesSocialesMunicipio = responseRedesSocialesMunicipio.Data.ToList();
                    List<TipoRedSocial> tiposRedesSociales = new List<TipoRedSocial>();
                    Response<IEnumerable<TipoRedSocial>> responseTiposRedesSociales = new Response<IEnumerable<TipoRedSocial>>();
                    responseTiposRedesSociales = TipoRedSocialQuerys.SelectTiposRedesSociales();
                    if (responseTiposRedesSociales.Status.Exito == 1)
                    {
                        tiposRedesSociales = responseTiposRedesSociales.Data.ToList();
                        for (int i = 0; i < response.Data.RedesSocialesMunicipio.Count; i++)
                        {
                            foreach (var tipo in tiposRedesSociales)
                            {
                                if (response.Data.RedesSocialesMunicipio[i].IdTipoRedSocial == tipo.IdTipoRedSocial)
                                {
                                    response.Data.RedesSocialesMunicipio[i].TipoRedSocial = tipo;
                                }
                            }
                            response.Data.RedesSocialesMunicipio[i].ContactoMunicipio = null;
                        }
                    }
                }

            }
            return response;
        }
    }
}
