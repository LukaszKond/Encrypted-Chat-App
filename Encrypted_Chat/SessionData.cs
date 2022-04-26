using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encrypted_Chat
{
    internal class SessionData
    {
        public byte[] key { get; set; }
        public byte[] iv { get; set; }

        
        public void GenerateSessionKey()
        {
            using var aes = Aes.Create();
            key = aes.Key;            
            iv = aes.IV;
            
        }

        public void SendSessionKey(TcpClient client)
        {
            var stream = client.GetStream();
            stream.Write(key, 0, 32);
        }
        public void SendIV(TcpClient client)
        {
            var stream = client.GetStream();
            stream.Write(iv, 0, 16);
        }
        public void SendPublicKey(TcpClient client, byte[] key)
        {
            var stream = client.GetStream();
            stream.Write(key,0,key.Length);
        }
        public byte[] GetPublicKey(TcpClient client, int len)
        {         
            var stream = client.GetStream();
            var partnerKey = new Byte[len]; 
            stream.Read(partnerKey,0,partnerKey.Length);
            return partnerKey;
            
        }
        public void GetSessionKey(TcpClient client)
        {
            var stream = client.GetStream();
            key = new Byte[32];
            stream.Read(key, 0, key.Length);
        }
        public void GetIV(TcpClient client)
        {
            var stream = client.GetStream();
            iv = new Byte[16];
            stream.Read(iv, 0, iv.Length);
        }
    }
}
