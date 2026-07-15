using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Helpers.Validaciones
{
    public class ValidarPassword
    {
        public bool validarPassword(string password)
        {
            string minusculas = "abcdefghijklmnñoupqrstuvwxyz";
            string mayusculas = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";
            string numeros = "0123456789";
            string caracteres = "_-.@&()!<>=+%$#?¿";

            bool validacionMinusculas = false;
            bool validacionMayusculas = false;
            bool validacionNumeros = false;
            bool validacionCaracteres = false;

            foreach (char p in password)
            {
                foreach (char minuscula in minusculas)
                {
                    if (p == minuscula)
                    {
                        validacionMinusculas = true;
                    }
                }
                foreach (char mayuscula in mayusculas)
                {
                    if (p == mayuscula)
                    {
                        validacionMayusculas = true;
                    }
                }
                foreach (char numero in numeros)
                {
                    if (p == numero)
                    {
                        validacionNumeros = true;
                    }
                }
                foreach (char caracter in caracteres)
                {
                    if (p == caracter)
                    {
                        validacionCaracteres = true;
                    }
                }
            }
            if (validacionMinusculas && validacionMayusculas && validacionNumeros && validacionCaracteres)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
