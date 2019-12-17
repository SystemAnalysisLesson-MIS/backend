using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace IkematgahDegisim.Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void HashingPassword(string sifre,out byte[] sifreSalt,out byte[] sifreHash)
        {
            using(var hmac=new HMACSHA512())
            {
                sifreSalt = hmac.Key;
                sifreHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(sifre));
            }
        }

        public static bool VerifyPassword(string sifre,byte[] sifreSalt,byte[] sifreHash)
        {
            using(var hmac=new HMACSHA512())
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(sifre));

                for(int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != sifreHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
