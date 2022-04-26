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

    }
}
