using CityApp.Server.Servicios.BDCityApp.ConexionCityApp;
using CityApp.Shared.Entities.BDSqlServerCityApp;
using CityApp.Shared.Models.DataValuesModels;

namespace CityApp.Server.Servicios.BDCityApp.QuerysCityApp.ContactoMunicipioQuerys.Select
{
    public class ContactoMunicipioSelect
    {
        private CityAppContext CityAppContext;
        private SelectCityApp<ContactoMunicipio> SelectCityApp = new SelectCityApp<ContactoMunicipio>();

        public ContactoMunicipioSelect(CityAppContext cityAppContext)
        {
            CityAppContext = cityAppContext;
        }

        public Response<ContactoMunicipio> SelectLastContactoMunicipio()
        {
            Response<ContactoMunicipio> response = new Response<ContactoMunicipio>();

            try
            {
                response.Data = CityAppContext.ContactosMunicipio.FirstOrDefault();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }

        public Response<ContactoMunicipio> SelectContactoMunicipioIdContactoMunicipio(int IdContactoMunicipio)
        {
            Response<ContactoMunicipio> response = new Response<ContactoMunicipio>();

            try
            {
                response.Data = CityAppContext.ContactosMunicipio.Where(d =>
                d.IdContactoMunicipio == IdContactoMunicipio).FirstOrDefault();

                response.Status = SelectCityApp.ValidarObjeto(response.Data);
            }
            catch (Exception ex)
            {
                response.Status = SelectCityApp.Error(ex);
            }

            return response;
        }
    }
}
