using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CityApp.Shared.Helpers
{
    public class Codificador
    {
        public string Encrypt(string data)
        {
            data = data + "$^w^mailData2343.";
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(data);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        public string Decrypt(string data)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(data);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result.Substring(0, (result.Length - 17));
        }

        public string EncryptKey(string data)
        {
            data = data.Replace('0', 'z').Replace('1', 'b').Replace('2', 'n').Replace('3', 'e')
                .Replace('4', 'f').Replace('5', 'i').Replace('6', 't').Replace('7', 'v')
                .Replace('8', 's').Replace('9', 'h');

            data = data.Replace('a', '2').Replace('b', 'f').Replace('c', 'f').Replace('d', 'C')
                .Replace('e', 'L').Replace('f', '5').Replace('g', '4').Replace('h', 'N')
                .Replace('i', 'E').Replace('j', 'D').Replace('k', 'S').Replace('l', 'n')
                .Replace('m', '9').Replace('n', '9').Replace('o', 'a').Replace('p', 'z')
                .Replace('q', 'f').Replace('r', 'i').Replace('s', '-').Replace('t', '.')
                .Replace('u', 'v').Replace('v', 'b').Replace('x', 'q').Replace('y', 'w')
                .Replace('z', 'T');

            data = data.Replace('A', '2').Replace('B', 'f').Replace('C', '3').Replace('D', 'A')
                .Replace('E', 'f').Replace('F', 'g').Replace('G', 'h').Replace('H', 'd')
                .Replace('I', '4').Replace('J', 'A').Replace('K', '4').Replace('L', '5')
                .Replace('M', 'q').Replace('N', '.').Replace('O', 'y').Replace('P', '0')
                .Replace('Q', 'N').Replace('R', 's').Replace('S', 't').Replace('T', 'r')
                .Replace('U', 'p').Replace('V', 'V').Replace('X', 'y').Replace('Y', 't')
                .Replace('Z', '-');

            data = data + "^w^passData67539.";
            string dataEncrypt = "";

            SHA512 sha512 = SHA512Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha512.ComputeHash(encoding.GetBytes(data));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            dataEncrypt = sb.ToString();

            return dataEncrypt;
        }

        public string EncryptCorreo(string data)
        {
            data = data.Replace('@', '|');
            data = data + "$^w^mailData2343.";

            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(data);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        public string DecryptCorreo(string data)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(data);
            result = System.Text.Encoding.Unicode.GetString(decryted);

            result = result.Replace('|', '@');
            return result.Substring(0, (result.Length - 17));
        }
    }
}
