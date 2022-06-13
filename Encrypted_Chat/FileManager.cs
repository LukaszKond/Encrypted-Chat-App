using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrypted_Chat
{
    public class FileManager
    {
        string fileName;
        int chunksCount;
        SortedDictionary<int, string> chuncksReceived = new SortedDictionary<int, string> { };
        public bool done = false;

        public FileManager(string input)
        {
            fileName = FileParser.GetName(input);
            chunksCount = FileParser.GetChunkCount(input);
            addChunk(input);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (!(obj is FileManager)) return false;
            return fileName.Equals(((FileManager)obj).fileName);
        }

        public void addChunk(string input)
        {
            chuncksReceived.Add(FileParser.GetChunkNumber(input), FileParser.RemoveMetadata(input));
            if (chuncksReceived.Count == chunksCount)
                buildFile();
        }

        public void buildFile()
        {
            using FileStream fs = File.Create(fileName);

            foreach (string data in chuncksReceived.Values)
                fs.Write(Convert.FromBase64String(data));

            done = true;
        }
    }
}
