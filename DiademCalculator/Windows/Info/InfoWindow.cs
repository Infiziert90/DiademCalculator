using Dalamud.Interface.Utility;
using Dalamud.Interface.Windowing;

namespace DiademCalculator.Windows.Info;

public class InfoWindow : Window, IDisposable
{
    public InfoWindow() : base("Achievement Mode Info##DiademCalculator")
    {

    }

    public override void PreDraw()
    {
        Flags = ImGuiWindowFlags.AlwaysAutoResize | ImGuiWindowFlags.NoScrollbar;
    }

    public void Dispose() { }


    public override void Draw()
    {
        ImGui.Text("Achievement Mode pulls data from your achievement menu!");
        ImGuiHelpers.ScaledDummy(5.0f);
        ImGui.Text("Open the achievement menu and open all the Diadem achievements you want to track.");
    }
}
