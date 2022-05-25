using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net.Sockets;

namespace Encrypted_Chat
{
    internal class EncryptionManager
    {
        public RSA rsa;

        public byte[] _publicKey;
        public byte[] _privateKey;

        public byte[] session_key;
        public byte[] session_iv;
 
        public byte[] partner_publicKey;

        private float encryptionProgress;
        public void GenerateKeys()
        {
             rsa = RSA.Create();
            _privateKey = rsa.ExportRSAPrivateKey();
            _publicKey = rsa.ExportRSAPublicKey();
        }
        public byte[] encryptCBC(string message)
        {
            using var aes = Aes.Create();
            aes.Key = session_key;
            aes.IV = session_iv;
            aes.Padding = PaddingMode.PKCS7;
            return aes.EncryptCbc(Encoding.UTF8.GetBytes(message), session_iv);           
        }
        public byte[] encryptECB(string message)
        {
            using var aes = Aes.Create();
            aes.Key = session_key;
            aes.IV = session_iv;
            return aes.EncryptEcb(Encoding.UTF8.GetBytes(message), PaddingMode.PKCS7);
        }
        public string decryptCBC(byte[] message)
        {
            using var aes = Aes.Create();
            aes.Key = session_key;
            aes.IV = session_iv;
            aes.Padding = PaddingMode.PKCS7;
            return Encoding.UTF8.GetString(aes.DecryptCbc(message, session_iv));
        }
        public string decryptECB(byte[] message)
        {
            using var aes = Aes.Create();
            aes.Key = session_key;
            aes.IV = session_iv;
 
            return Encoding.UTF8.GetString(aes.DecryptEcb(message, PaddingMode.PKCS7));
        }

        public string encryptFile(string filePath, CipherMode cipherMode)
        {
            using var aes = Aes.Create();
            aes.Key = session_key;
            aes.IV = session_iv;
            aes.Padding = PaddingMode.Zeros;
            aes.Mode = cipherMode;

            string cryptFile = Path.GetFileName(filePath);
            using FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);
            using CryptoStream cs = new CryptoStream(fsCrypt, aes.CreateEncryptor(), CryptoStreamMode.Write);
            using FileStream fsIn = new FileStream(filePath, FileMode.Open);

            byte[] readBytes = new byte[4096];
            while (fsIn.Read(readBytes) != 0)
            {
                cs.Write(readBytes);
                encryptionProgress = (float)fsIn.Position / fsIn.Length;
            }

            return fsCrypt.Name;
        }

        public void decryptFile(string filePath, CipherMode cipherMode)
        {
            using var aes = Aes.Create();
            aes.Key = session_key;
            aes.IV = session_iv;
            aes.Padding = PaddingMode.Zeros;
            aes.Mode = cipherMode;

            using FileStream fsOpen = new FileStream(filePath, FileMode.Open);
            using CryptoStream cs = new CryptoStream(fsOpen, aes.CreateDecryptor(), CryptoStreamMode.Read);
            string decryptedFileName = "Decrypted " + Path.GetFileName(filePath);
            using FileStream fsCreate = new FileStream(decryptedFileName, FileMode.Create);

            int data;
            while ((data = cs.ReadByte()) != -1)
                fsCreate.WriteByte((byte)data);

        }

        public float getEncryptionProgress()
        {
            return encryptionProgress;
        }
    }
}
