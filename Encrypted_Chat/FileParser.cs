using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrypted_Chat
{
    public static class FileParser
    {
        public const string prefix = "THIS IS A FILE";
        public static string GetName(string input)
        {
            return getStringBetweenSlashes(
                    RemovePrefix(input));
        }
        public static int GetChunkNumber(string input)
        {
            return int.Parse(
                    getStringBetweenSlashes(
                    RemovePart(
                    RemovePrefix(input))));
        }

        public static int GetChunkCount(string input)
        {
            return int.Parse(
                    getStringBetweenSlashes(
                    RemovePart(
                    RemovePart(
                    RemovePrefix(input)))));
        }

        public static string RemovePrefix(string input)
        {
            return input.Remove(0, prefix.Length);
        }
        
        public static string RemovePart(string input)
        {
            return input.Remove(0, getStringBetweenSlashes(input).Length + 1);
        }

        public static string RemoveMetadata(string input)
        {
            return RemovePart(
                    RemovePart(
                    RemovePart(
                    RemovePrefix(input))))
                    .Remove(0, 1);
        }

        public static bool IsFile(string input)
        {
            return input.StartsWith(prefix);
        }

        public static string AddMetaData(string data, string name, int chunkNumber, int chunkCount)
        {
            return prefix + "/" + name + "/" + chunkNumber + "/" + chunkCount + "/" + data;
        }

        private static string getStringBetweenSlashes(string input)
        {
            int firstSlashIndex = input.IndexOf('/');
            int secondSlashIndex = input.IndexOf('/', firstSlashIndex + 1);
            return input.Substring(firstSlashIndex + 1, secondSlashIndex - 1);
        }



    }
}
