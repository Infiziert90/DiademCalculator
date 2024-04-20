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
    private int Grade = 2;

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

    private void UpdateGrade()
    {
        if ((Grade + 1) > 5)
        {
            Grade = 2;
        }
        else
        {
            Grade += 1;
        }
    }

    public override void Draw()
    {
        if (!Plugin.Configuration.AchievementMode)
        {
            Helper.DrawScaledIcon(IconBTN, IconSize);
            DrawPoints((int)(DiademResources.BtnPoints));

            Helper.DrawScaledIcon(IconMIN, IconSize);
            DrawPoints((int)(DiademResources.MinPoints));

            Helper.DrawScaledIcon(IconFSH, IconSize);
            DrawPoints((int)(DiademResources.FshPoints));

            ImGuiHelpers.ScaledDummy(10.0f);

            Helper.DrawScaledIcon(IconScrip, IconSize);
            DrawPoints(DiademResources.MinScrips + DiademResources.BtnScrips + DiademResources.FshScrips);
        } 
        else if (Grade == 5)
        {
            if (ImGui.Button("Points"))
            {
                UpdateGrade();
            }
            Helper.DrawScaledIcon(IconBTN, IconSize);
            DrawPoints((int)(500000 - DiademResources.btn50K - DiademResources.BtnPoints));

            Helper.DrawScaledIcon(IconMIN, IconSize);
            DrawPoints((int)(500000 - DiademResources.min50K - DiademResources.MinPoints));

            Helper.DrawScaledIcon(IconFSH, IconSize);
            DrawPoints((int)(500000 - DiademResources.fsh50K - DiademResources.FshPoints));

            ImGuiHelpers.ScaledDummy(10.0f);

            Helper.DrawScaledIcon(IconScrip, IconSize);
            DrawPoints(DiademResources.MinScrips + DiademResources.BtnScrips + DiademResources.FshScrips);
        }
        else
        {
            if (ImGui.Button(String.Concat("Grade ", Grade.ToString())))
            {
                UpdateGrade();
            }
            Helper.DrawScaledIcon(IconBTN, IconSize);
            DrawPoints((int)DiademResources.diademGrades.Where(x => x.Grade == this.Grade && x.Preset == 1).First().Quantity);

            Helper.DrawScaledIcon(IconMIN, IconSize);
            DrawPoints((int)DiademResources.diademGrades.Where(x => x.Grade == this.Grade && x.Preset == 0).First().Quantity);

            Helper.DrawScaledIcon(IconFSH, IconSize);
            DrawPoints((int)DiademResources.diademGrades.Where(x => x.Grade == this.Grade && x.Preset == 2).First().Quantity);
        }
    }

    private static void DrawPoints(int count)
    {
        ImGui.SameLine();
        ImGui.AlignTextToFramePadding();
        ImGui.Text(count.ToString());
    }
}
