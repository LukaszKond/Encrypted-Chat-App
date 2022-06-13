using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrypted_Chat
{
    internal class FileManager
    {
        string receivedData = null;
        string name;
        int chunksCount;
        Dictionary<int, string> chuncksReceived = new Dictionary<int, string> { };
    }
}
