namespace TheXDS.Hygiea.Models
{
    public class ProgramShortcut
    {
        public string ShortcutName { get; set; }
        public string ProgramExecutable { get; set; }
        public string ProgramArguments { get; set; }
        public string StartupDirectory { get; set; }
        public string Icon { get; set; }
    }
}
