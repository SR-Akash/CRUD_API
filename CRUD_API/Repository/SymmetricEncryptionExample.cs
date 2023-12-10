using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_API.Repository
{
    using CRUD_API.Helper;
    using CRUD_API.IRepository;
    using System;
    using System.Security.Cryptography;
    using System.Text;

    class SymmetricEncryptionExample : ISymmetricEncryptionExample
    {
        static byte[] GenerateKey()
        {
            using (var provider = new AesCryptoServiceProvider())
            {
                provider.GenerateKey();
                return provider.Key;
            }
        }

        static byte[] EncryptMessage(string message, byte[] key)
        {
            using (var aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = key;
                aesAlg.Mode = CipherMode.ECB;

                // Generate a random IV (Initialization Vector)
                aesAlg.GenerateIV();

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (var msEncrypt = new System.IO.MemoryStream())
                {
                    // Write IV to the beginning of the stream
                    msEncrypt.Write(aesAlg.IV, 0, aesAlg.IV.Length);

                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(message);
                        }
                    }
                    return msEncrypt.ToArray();
                }
            }
        }

        static string DecryptMessage(byte[] cipherText, byte[] key)
        {
            using (var aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = key;
                aesAlg.Mode = CipherMode.ECB;

                // Read IV from the beginning of the cipherText
                byte[] iv = new byte[aesAlg.IV.Length];
                Array.Copy(cipherText, 0, iv, 0, iv.Length);
                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (var msDecrypt = new System.IO.MemoryStream(cipherText, iv.Length, cipherText.Length - iv.Length))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        public async Task<string> SymmetricExample(string inputMessage)
        {
            byte[] secretKey = GenerateKey();
            byte[] encryptedMessage = EncryptMessage(inputMessage, secretKey);
            string decryptedMessage = DecryptMessage(encryptedMessage, secretKey);
            return ("Encrypted Message: " + Convert.ToBase64String(encryptedMessage)) 
                + " Secret key: " + Convert.ToBase64String(secretKey) 
                + (" Decrypted Message: " + decryptedMessage);
        }

        public async Task<string> SymmetricExampleDecrypt(string inputMessage, string key)
        {
            try
            {
                // Generate a key (should be kept secret and shared securely between communicating parties)
                byte[] secretKey = GenerateKey();

                // Message to be encrypted
                string originalMessage = inputMessage;
                byte[] utf8Bytes = Encoding.UTF8.GetBytes(key);
                byte[] msg = Encoding.UTF8.GetBytes(inputMessage);



                // Decrypt the message
                string decryptedMessage = DecryptMessage(msg, utf8Bytes);


                return ("Encrypted Message: " + Convert.ToBase64String(msg)) + " Secret key: " + Convert.ToBase64String(secretKey) + (" Decrypted Message: " + decryptedMessage);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
