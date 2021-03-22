using System.IO;

namespace TheXDS.Hygiea.Models
{
    public class FileManifest
    {
        public string Name { get; set; }
        public FileAttributes Attributes { get; set; }
        public int ContentSize { get; set; }
        public string PayloadStream { get; set; }
        public long PayloadOffset { get; set; }
        public byte[] Hash { get; set; }
    }
}
