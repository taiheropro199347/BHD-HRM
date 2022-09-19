using System.Security.Cryptography;
using System.Text;

namespace BHD_HRM
{
    public class Utility
    {
        public static string GetMd5Hash(string input)
        {

            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x3"));
            }
            return sBuilder.ToString();

        }
    }
}
