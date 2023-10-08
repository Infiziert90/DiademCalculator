using Dalamud.Interface.Utility;
using Dalamud.Interface.Windowing;
using static ImGuiNET.ImGuiWindowFlags;

namespace DiademCalculator.Windows.Main;

public class MainWindow : Window, IDisposable
{
    private Plugin Plugin;

    private const int TerritoryFirmament = 886;
    private const int TerritoryDiadem = 939;

    private const int IconScrip = 65073;
    private const int IconMIN = 62116;
    private const int IconBTN = 62117;
    private const int IconFSH = 62118;

    private static readonly Vector2 IconSize = new(28, 28);

    public MainWindow(Plugin plugin) : base("Inspector##DiademCalculator")
    {
        Plugin = plugin;
    }

    public void Dispose() { }

    public override void PreOpenCheck()
    {
        if (Plugin.Configuration.ShowOutsideFirmamentAndDiadem || Plugin.ClientState.TerritoryType == TerritoryFirmament || Plugin.ClientState.TerritoryType == TerritoryDiadem)
        {
            IsOpen = true;
            ImGui.SetNextWindowBgAlpha(Plugin.Configuration.BackgroundAlpha);
        }
        else
        {
            IsOpen = false;
        }
    }

    public override void PreDraw()
    {
        Flags = NoTitleBar | AlwaysAutoResize | NoScrollbar;
        if (Plugin.Configuration.LockWindow)
            Flags |= NoMouseInputs | NoInputs;
    }

    public override void Draw()
    {
        Helper.DrawScaledIcon(IconBTN, IconSize);
        DrawPoints(DiademResources.BtnPoints);

        Helper.DrawScaledIcon(IconMIN, IconSize);
        DrawPoints(DiademResources.MinPoints);

        Helper.DrawScaledIcon(IconFSH, IconSize);
        DrawPoints(DiademResources.FshPoints);

        ImGuiHelpers.ScaledDummy(10.0f);

        Helper.DrawScaledIcon(IconScrip, IconSize);
        DrawPoints( DiademResources.MinScrips + DiademResources.BtnScrips + DiademResources.FshScrips);
    }

    private static void DrawPoints(int count)
    {
        ImGui.SameLine();
        ImGui.AlignTextToFramePadding();
        ImGui.Text(count.ToString());
    }
}
