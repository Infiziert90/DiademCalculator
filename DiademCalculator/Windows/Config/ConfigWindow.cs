using Dalamud.Interface.Windowing;

namespace DiademCalculator.Windows.Config;

public partial class ConfigWindow : Window, IDisposable
{
    private Plugin Plugin;

    public ConfigWindow(Plugin plugin) : base("Configuration##Diadem Calculator")
    {
        this.SizeConstraints = new WindowSizeConstraints
        {
            MinimumSize = new Vector2(300, 200),
            MaximumSize = new Vector2(float.MaxValue, float.MaxValue)
        };

        Plugin = plugin;
    }

    public void Dispose() { }

    public override void Draw()
    {
        if (ImGui.BeginTabBar("##ConfigTabBar"))
        {
            Settings();

            About();
        }
        ImGui.EndTabBar();
    }
}
