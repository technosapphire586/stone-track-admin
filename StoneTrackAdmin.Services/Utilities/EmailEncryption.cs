
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace StoneTrackAdmin.Services
{
    public static class EmailEncryption
    {
        public static string CleanUpEncription(string encriptedstring)
        {
            string[] dirtyCharacters = { ";", "/", "?", ":", "@", "&", "=", "+", "$", "," };
            string[] cleanCharacters = { "p2n3t4G5l6m", "s1l2a3s4h", "q1e2st3i4o5n", "T22p14nt2s", "a9t", "a2n3nd", "e1q2ua88l", "p22l33u1ws", "d0l1ar5", "c0m8a1a" };

            foreach (string dirtyCharacter in dirtyCharacters)
            {
                encriptedstring = encriptedstring.Replace(dirtyCharacter, cleanCharacters[Array.IndexOf(dirtyCharacters, dirtyCharacter)]);
            }
            return encriptedstring;
        }

        public static string MakeItDirtyAgain(string encriptedString)
        {
            string[] dirtyCharacters = { ";", "/", "?", ":", "@", "&", "=", "+", "$", "," };
            string[] cleanCharacters = { "p2n3t4G5l6m", "s1l2a3s4h", "q1e2st3i4o5n", "T22p14nt2s", "a9t", "a2n3nd", "e1q2ua88l", "p22l33u1ws", "d0l1ar5", "c0m8a1a" };
            foreach (string symbol in cleanCharacters)
            {
                encriptedString = encriptedString.Replace(symbol, dirtyCharacters[Array.IndexOf(cleanCharacters, symbol)]);
            }
            return encriptedString;
        }

        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Flush();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }


        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText + "Date" + DateTime.Now.AddMinutes(10));
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Flush();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
    }
}
