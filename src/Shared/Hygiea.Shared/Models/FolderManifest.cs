namespace TheXDS.Hygiea.Models
{
    public class FolderManifest
    {
        public string Name { get; set; }
        public FolderManifest[] Subfolders { get; set; }
        public FileManifest[] Files { get; set; }
    }
}
