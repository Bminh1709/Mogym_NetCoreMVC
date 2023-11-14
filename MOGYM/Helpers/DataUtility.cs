using System.Runtime.CompilerServices;
using System.Text;

namespace MOGYM.Helpers
{
    public static class DataUtility
    {
        private static readonly string Key = "minhdeptrai203@.";

        public static string EncryptPassword(string password)
        {
            if (String.IsNullOrEmpty(password)) return "";
            password += Key;
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);
        }

        public static string DecryptPassword(string base64EncodeData)
        {
            if (String.IsNullOrEmpty(base64EncodeData)) return "";
            var base64EncodeBytes = Convert.FromBase64String(base64EncodeData);
            var result = Encoding.UTF8.GetString(base64EncodeBytes);
            result = result.Substring(0, result.Length - Key.Length);
            return result;
        }
    }
}
