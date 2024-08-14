using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace LegumizeUI.Utilites
{
    public class CryptoUtility
    {
        byte[] key = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
        byte[] iv = { 65, 110, 68, 26, 69, 178, 200, 219 };

       
        public byte[] Encrypt(string plainText)
        {
            UTF8Encoding utf8encoder = new UTF8Encoding();
            byte[] inputInBytes = utf8encoder.GetBytes(plainText);

            TripleDESCryptoServiceProvider tdesProvider = new TripleDESCryptoServiceProvider();
            ICryptoTransform cryptoTransform = tdesProvider.CreateEncryptor(this.key, this.iv);

            MemoryStream encryptedStream = new MemoryStream();
            CryptoStream cryptStream = new CryptoStream(encryptedStream, cryptoTransform, CryptoStreamMode.Write);

            cryptStream.Write(inputInBytes, 0, inputInBytes.Length);
            cryptStream.FlushFinalBlock();
            encryptedStream.Position = 0;

            byte[] result = new byte[encryptedStream.Length];

            encryptedStream.Read(result, 0, (int)encryptedStream.Length);
            cryptStream.Close();
            return result;
        }

        
        public string Decrypt(byte[] inputInBytes)
        {
            UTF8Encoding utf8encoder = new UTF8Encoding();
            TripleDESCryptoServiceProvider tdesProvider = new TripleDESCryptoServiceProvider();

            ICryptoTransform cryptoTransform = tdesProvider.CreateDecryptor(this.key, this.iv);

            MemoryStream decryptedStream = new MemoryStream();
            CryptoStream cryptStream = new CryptoStream(decryptedStream, cryptoTransform, CryptoStreamMode.Write);
            cryptStream.Write(inputInBytes, 0, inputInBytes.Length);
            cryptStream.FlushFinalBlock();
            decryptedStream.Position = 0;

            byte[] result = new byte[decryptedStream.Length];
            decryptedStream.Read(result, 0, (int)decryptedStream.Length);
            cryptStream.Close();
            UTF8Encoding myutf = new UTF8Encoding();

            return myutf.GetString(result);

        }
    }
}



