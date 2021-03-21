using System;
using System.IO;

namespace TheXDS.Hygiea.Models
{
    public class SetupManifest
    {
        public string ProductName { get; set; }
        public string Version { get; set; }
        public string Company { get; set; }
        public long PayloadSize { get; set; }
        public string DefaultInstallPath { get; set; }
        public string DefaultMenuPath { get; set; }
        public OptionPayload[] Options { get; set; }
    }

    public class OptionPayload
    {
        public Guid OptionId { get; set; }
        public string OptionName { get; set; }
        public Guid[] Requires { get; set; }
        public Guid[] BlockedBy { get; set; }
        public bool Required { get; set; }
        public long PayloadSize { get; set; }
        public string PathSuffix { get; set; }
        public ProgramShortcut[] Shortcuts { get; set; }
    }

    public class ProgramShortcut
    {
        public string ProgramExecutable { get; set; }
        public string ProgramArguments { get; set; }
        public string StartupDirectory { get; set; }
    }

    public abstract class PayloadItem
    {
        public string Name { get; set; }
    }

    public class FolderPayload : PayloadItem
    {
        public FolderPayload[] Subfolders { get; set; }
        public FilePayload[] Files { get; set; }
    }

    public class FilePayload : PayloadItem
    {
        public FileAttributes Attributes { get; set; }
        public int ContentSize { get; set; }
    }

    public class SetupState
    {
        public SetupManifest SetupManifest { get; set; }
        public bool LicenseAccepted { get; set; }
        public string UserName { get; set; }
        public string Organization { get; set; }
        public string ProductKey { get; set; }
        public bool InstallForAllUsers { get; set; }
    }



    public class PageManifest
    {
        public string PageName { get; set; }
        public string PageView { get; set; }
        public string? StreamName { get; set; }
    }
}
