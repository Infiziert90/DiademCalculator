using Dalamud.Interface.Utility;
using Dalamud.Interface.Windowing;
using static ImGuiNET.ImGuiWindowFlags;

namespace DiademCalculator.Windows.Info;

public class InfoWindow : Window, IDisposable
{
    private Plugin Plugin;

    public InfoWindow(Plugin plugin) : base("Achievement Mode Info##DiademCalculator")
    {
        this.Plugin = plugin;
    }

    public override void PreDraw()
    {
        Flags = AlwaysAutoResize | NoScrollbar;
    }

    public void Dispose() { }


    public override void Draw()
    {
        ImGui.Text("Achievement Mode pulls data from your achievement menu!");
        ImGuiHelpers.ScaledDummy(5.0f);
        ImGui.Text("Open the achievement menu and open all the Diadem achievements you want to track.");
    }
}
