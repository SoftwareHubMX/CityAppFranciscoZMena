using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Helpers.Correos
{
    public class CorreoCuentaVerificada
    {
        public static string GetCorreo()
        {
            string data = "<div style='width: 100%;'>" +
                                        "<div style='width: 100%; padding: 0; padding-bottom: 50px;'>" +
                                            "<p style='padding: 15px 90px; font-size: 30px; font-weight: 600; background-color: #cf131e; color: #fff; margin: 40px 0; margin-left: auto;'>Correo validado</p>" +
                                            "<p style='font-size: 25px; margin: auto; text-align: center;'>Su correo se ha verificado con éxito, ya puede continuar utilizando CityApp</p>" +
                                        "</div>" +
                                        "<div style='width: 100%; background-color: #fff; padding: 10px;'>" +
                                            "<a style='color: #fff; font-size: 15px; width: 100%; height: 120px; margin: 0; text-decoration: none;' href='https://chilapadealvarez.gob.mx/'>" +
                                                "<img src='http://51.142.225.193:9098/Imagenes/LogosMunicipios/Chilapa/ico_chilapa.png' style='width: 100%; height: 400px; object-fit: content;' />" +
                                            "</a>" +
                                        "</div>" +
                                    "</div>";
            return data;
        }
    }
}
