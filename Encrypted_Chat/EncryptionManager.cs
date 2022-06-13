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
        public byte[] partner_publicIV;

        private float encryptionProgress;


        public bool GenerateKeys(String user, String pass)
        {
            string currentPath = Directory.GetCurrentDirectory();           
            currentPath += "/Users/"+user;
            SHA256 sha256Hash = SHA256.Create();
            byte[] pass_hash = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(pass));
            Byte[] user_iv;
            if (!Directory.Exists(currentPath)) //creating new user
            {
                Directory.CreateDirectory(Path.Combine(currentPath));
                Directory.CreateDirectory(Path.Combine(currentPath+"/publicKey"));
                Directory.CreateDirectory(Path.Combine(currentPath+"/privateKey"));
                rsa = new RSACryptoServiceProvider(2048);
                _privateKey = rsa.ExportRSAPrivateKey();
                _publicKey = rsa.ExportRSAPublicKey();
                using var aes = Aes.Create();
                user_iv = aes.IV;
                File.WriteAllBytes(currentPath+"/privateKey/privateKey.key", encryptCBC(_privateKey,pass_hash, user_iv));
                File.WriteAllBytes(currentPath + "/publicKey/publicKey.key", encryptCBC(_publicKey, pass_hash, user_iv));
                File.WriteAllBytes(currentPath + "/localKey", pass_hash);
                File.WriteAllBytes(currentPath+ "/localIV", user_iv);
                return true;
            }           
            else //user already exists
            {
                var saved_key = File.ReadAllBytes(currentPath + "/localKey");
                if (pass_hash.SequenceEqual(saved_key))
                {
                    user_iv = File.ReadAllBytes(currentPath + "/localIV");
                    _privateKey = decryptCBC(File.ReadAllBytes(currentPath + "/privateKey/privateKey.key"),pass_hash, user_iv);
                    _publicKey = decryptCBC(File.ReadAllBytes(currentPath + "/publicKey/publicKey.key"), pass_hash, user_iv);
                    return true;
                }
                else
                {
                    MessageBox.Show("You have entered wrong password!");
                    return false;
                }
            }
        }

        public byte[] encryptCBC(Byte[] key, byte[] local_key, byte[] IV)
        {
            using var aes = Aes.Create();
            aes.Key = local_key;
            aes.IV = IV;
            return aes.EncryptCbc(key, IV);
        }
        public Byte[] decryptCBC(byte[] key, byte[] local_key, byte[] IV)
        {
            using var aes = Aes.Create();
            aes.Key = local_key;
            aes.IV = IV;
            return aes.DecryptCbc(key, IV);
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
