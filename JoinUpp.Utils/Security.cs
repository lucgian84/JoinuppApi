using System;
using System.Security.Cryptography;

namespace JoinUpp.Utils
{
    internal static class SecurityConstants
    {
        internal static readonly int RFC2898ITERATIONS = 10000;
        internal static readonly int SALTLENGTH = 16;
        internal static readonly int KEYLENGTH = 20;
        internal static int HASHLENGHT => SALTLENGTH + KEYLENGTH;
    }
    public static class SecurityStringExtensions
    {
        public static string StrongHash(this string value)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SecurityConstants.SALTLENGTH]);
            var pbkdf2 = new Rfc2898DeriveBytes(value, salt, SecurityConstants.RFC2898ITERATIONS);
            byte[] hash = pbkdf2.GetBytes(SecurityConstants.KEYLENGTH);
            byte[] hashBytes = new byte[SecurityConstants.HASHLENGHT];
            Array.Copy(salt, 0, hashBytes, 0, SecurityConstants.SALTLENGTH);
            Array.Copy(hash, 0, hashBytes, SecurityConstants.SALTLENGTH, SecurityConstants.KEYLENGTH);
            return Convert.ToBase64String(hashBytes);
        }

        public static bool CompareStrongHash(this string value, string strongHash)
        {
            if (strongHash == null)
                return false;
            byte[] hashBytes = Convert.FromBase64String(strongHash);
            byte[] salt = new byte[SecurityConstants.SALTLENGTH];
            Array.Copy(hashBytes, 0, salt, 0, SecurityConstants.SALTLENGTH);
            var pbkdf2 = new Rfc2898DeriveBytes(value, salt, SecurityConstants.RFC2898ITERATIONS);
            byte[] hash = pbkdf2.GetBytes(SecurityConstants.KEYLENGTH);
            for (int i = 0; i < SecurityConstants.KEYLENGTH; i++)
                if (hashBytes[i + SecurityConstants.SALTLENGTH] != hash[i])
                    return false;
            return true;
        }
    }
}
