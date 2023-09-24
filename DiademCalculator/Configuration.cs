using Dalamud.Configuration;

namespace DiademCalculator
{
    public class Configuration : IPluginConfiguration
    {
        public int Version { get; set; }

        public float BackgroundAlpha = 1;
        public bool ShowOutsideFirmamentAndDiadem;
        public bool LockWindow;

        public void Save()
        {
            Plugin.PluginInterface.SavePluginConfig(this);
        }
    }
}
