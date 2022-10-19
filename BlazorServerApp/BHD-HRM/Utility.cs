using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

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
        public static string RemoveSign4VietnameseString(string str)
        {
            string stFormD = str.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }

            str = (sb.ToString().Normalize(NormalizationForm.FormC));

            str = Regex.Replace(str, @"đ", "d");
            str = Regex.Replace(str, @"Đ", "D");

            return str;
        }
    }
}
