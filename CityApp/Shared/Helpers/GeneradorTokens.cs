using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Helpers
{
    public class GeneradorTokens
    {
        const string alfabeto = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!_-";
        private Random rnd;
        private static GeneradorTokens instancia;

        private GeneradorTokens()
        {
            rnd = new Random(DateTime.Now.Millisecond);
        }

        public static GeneradorTokens Instancia()
        {
            if (instancia == null)
            {
                instancia = new GeneradorTokens();
            }
            return instancia;
        }

        public string GetToken(int longitud)
        {
            StringBuilder token = new StringBuilder();

            for (int i = 0; i < longitud; i++)
            {
                int indice = rnd.Next(alfabeto.Length);
                token.Append(alfabeto[indice]);
            }

            return token.ToString();
        }
    }
}
