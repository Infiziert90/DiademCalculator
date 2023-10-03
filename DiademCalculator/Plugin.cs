using System.Reflection;
using Dalamud.Interface.Windowing;
using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;
using DiademCalculator.Attributes;
using DiademCalculator.Windows.Config;
using DiademCalculator.Windows.Main;

namespace DiademCalculator
{
    public class Plugin : IDalamudPlugin
    {
        [PluginService] public static DalamudPluginInterface PluginInterface { get; private set; }  = null!;
        [PluginService] public static ICommandManager Commands { get; private set; }  = null!;
        [PluginService] public static IDataManager Data { get; private set; }  = null!;
        [PluginService] public static IClientState ClientState { get; private set; }  = null!;
        [PluginService] public static IFramework Framework { get; private set; }  = null!;
        [PluginService] public static ITextureProvider Texture { get; private set; }  = null!;

        public Configuration Configuration { get; init; }

        public readonly WindowSystem WindowSystem = new("Diadem Calculator");
        public ConfigWindow ConfigWindow { get; init; }
        public MainWindow MainWindow { get; init; }

        private readonly PluginCommandManager<Plugin> CommandManager;

        private DateTime LastUpdate;
        private int UpdatePresetIndex;

        public const string Authors = "Infi";
        public static readonly string Version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "Unknown";

        public Plugin()
        {
            Configuration = PluginInterface.GetPluginConfig() as Configuration ?? new Configuration();

            MainWindow = new MainWindow(this);
            ConfigWindow = new ConfigWindow(this);

            WindowSystem.AddWindow(MainWindow);
            WindowSystem.AddWindow(ConfigWindow);

            CommandManager = new PluginCommandManager<Plugin>(this, Commands);

            PluginInterface.UiBuilder.Draw += DrawUI;
            PluginInterface.UiBuilder.OpenConfigUi += OpenConfig;

            Framework.Update += CalculatePoints;
        }

        private void CalculatePoints(IFramework framework)
        {
            if ((DateTime.Now - LastUpdate).TotalMilliseconds > 50)
            {
                DiademResources.CalculatePoints(UpdatePresetIndex);

                UpdatePresetIndex++;
                if (UpdatePresetIndex > 2)
                    UpdatePresetIndex = 0;

                LastUpdate = DateTime.Now;
            }
        }

        [Command("/dcalc")]
        [HelpMessage("Opens Diadem Calculator config menu")]
        public void Settings(string command, string args)
        {
            ConfigWindow.IsOpen ^= true;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);

            WindowSystem.RemoveAllWindows();

            ConfigWindow.Dispose();
            MainWindow.Dispose();

            PluginInterface.UiBuilder.Draw -= DrawUI;
            PluginInterface.UiBuilder.OpenConfigUi -= OpenConfig;

            CommandManager.Dispose();
        }

        private void DrawUI() => WindowSystem.Draw();
        public void OpenConfig() => ConfigWindow.IsOpen = true;
    }
}
