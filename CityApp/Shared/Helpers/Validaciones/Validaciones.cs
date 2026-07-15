using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Helpers.Validaciones
{
    public class Validaciones
    {
        private MinimoCaracteres MinimoCaracteres = new MinimoCaracteres();
        private MaximoCaracteres MaximoCaracteres = new MaximoCaracteres();
        private EsCorreo EsCorreo = new EsCorreo();
        private ValidarPassword ValidarPassword = new ValidarPassword();
        private ConfirmarPassword ConfirmarPassword = new ConfirmarPassword();
        private EsNumeroTenefono EsNumeroTenefono = new EsNumeroTenefono();
        private SonCaracteresValidos SonCaracteresValidos = new SonCaracteresValidos();
        public bool ValidarMinimoCarcteres(int minimo, string data)
        {
            return MinimoCaracteres.ValidarMinimoCarcteres(minimo, data);
        }

        public bool ValidarCorreo(string correo)
        {
            if (ValiddarMaximoCaracteres(60, correo))
            {
                return EsCorreo.validarCorreo(correo);
            }
            else
            {
                return false;
            }

        }

        public bool ValiddarMaximoCaracteres(int maximo, string data)
        {
            return MaximoCaracteres.ValidarMaximoCarcteres(maximo, data);
        }

        public bool ValidarContraseña(string Password)
        {
            if (MinimoCaracteres.ValidarMinimoCarcteres(8, Password))
            {
                return ValidarPassword.validarPassword(Password);
            }
            else
            {
                return MinimoCaracteres.ValidarMinimoCarcteres(8, Password);
            }
        }

        public bool ValidarContraseñas(string pass1, string pass2)
        {
            return ConfirmarPassword.ValidarContraseñas(pass1, pass2);
        }

        public bool ValidarTelefono(string Telefono)
        {
            return EsNumeroTenefono.validarTelefono(Telefono);
        }

        public bool ValidarCaracteres(string data)
        {
            return SonCaracteresValidos.ValidarCaracteres(data);
        }
    }
}
