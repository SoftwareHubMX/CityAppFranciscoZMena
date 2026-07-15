using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Helpers.Correos
{
    public class CorreoVerificarCorreo
    {
        public static string GetCorreo(string token)
        {
            string data = "<div style='width: 100%;'>" +
                            "<div style='width: 100%; padding: 0; padding-bottom: 50px;'>" +
                                "<p style='padding: 15px 90px; font-size: 30px; font-weight: 600; background-color: #cf131e; color: #fff; margin: 40px 0; text-align: center;'>Validación de correo</p>" +
                                "<p style='font-size: 25px; margin: auto; text-align: center;'>Estimado usuario, te informamos que el proceso de registro en CityApp, ligado a este correo electrónico, se ha realizado con éxito. Para desbloquear todas las funciones, usa el siguiente token:</p>" +
                               "<div style='text-align: center; margin: 20px 0; font-size: 22px; font-weight: bold; color: #002E7F;'>" +
                                   token +
                               "</div>" +
                            "</div>" +
                            "<div style='width: 100%; background-color: #fff; padding: 10px; text-align: center;'>" +
                                "<a style='color: #000; font-size: 15px; text-decoration: none;' href='https://chilapadealvarez.gob.mx/'>" +
                                    "<img src='http://51.142.225.193:6067/Imagenes/LogosMunicipios/Chilapa/ico_chilapa.png' style='width: 100%; height: 400px; object-fit: contain;' />" +
                                "</a>" +
                            "</div>" +
                        "</div>";
            return data;
        }


    }
}
