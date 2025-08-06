using Dalamud.Interface.Utility;
using Dalamud.Interface.Windowing;

namespace DiademCalculator.Windows.Main;

public class MainWindow : Window, IDisposable
{
    private readonly Plugin Plugin;

    private const int TerritoryFirmament = 886;
    private const int TerritoryDiadem = 939;

    private const int IconScrip = 65073;
    private const int IconMIN = 62116;
    private const int IconBTN = 62117;
    private const int IconFSH = 62118;
    private int Grade = 5;

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
        Flags = ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.AlwaysAutoResize | ImGuiWindowFlags.NoScrollbar;
        if (Plugin.Configuration.LockWindow)
            Flags |= ImGuiWindowFlags.NoMove;
    }

    private void UpdateGrade()
    {
        if (Grade > 4)
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
            DrawPoints(DiademResources.BtnPoints);

            Helper.DrawScaledIcon(IconMIN, IconSize);
            DrawPoints(DiademResources.MinPoints);

            Helper.DrawScaledIcon(IconFSH, IconSize);
            DrawPoints(DiademResources.FshPoints);

            ImGuiHelpers.ScaledDummy(10.0f);

            Helper.DrawScaledIcon(IconScrip, IconSize);
            DrawPoints(DiademResources.MinScrips + DiademResources.BtnScrips + DiademResources.FshScrips);
        }
        else if (Grade == 5)
        {
            if (ImGui.Button("Points"))
                UpdateGrade();

            Helper.DrawScaledIcon(IconBTN, IconSize);
            DrawPoints((int)(500000 - DiademResources.Btn500K - DiademResources.BtnPoints));

            Helper.DrawScaledIcon(IconMIN, IconSize);
            DrawPoints((int)(500000 - DiademResources.Min500K - DiademResources.MinPoints));

            Helper.DrawScaledIcon(IconFSH, IconSize);
            DrawPoints((int)(500000 - DiademResources.Fsh500K - DiademResources.FshPoints));

            ImGuiHelpers.ScaledDummy(10.0f);

            Helper.DrawScaledIcon(IconScrip, IconSize);
            DrawPoints(DiademResources.MinScrips + DiademResources.BtnScrips + DiademResources.FshScrips);
        }
        else
        {
            if (ImGui.Button(string.Concat("Grade ", Grade.ToString())))
                UpdateGrade();

            switch (Grade)
            {
                case 2:
                    DrawValues(DiademResources.Grade2Btn,
                        DiademResources.Grade2Min,
                        DiademResources.Grade2Fsh,
                        DiademResources.Grade2BtnAch,
                        DiademResources.Grade2MinAch,
                        DiademResources.Grade2FshAch);
                    break;
                case 3:
                    DrawValues(DiademResources.Grade3Btn,
                        DiademResources.Grade3Min,
                        DiademResources.Grade3Fsh,
                        DiademResources.Grade3BtnAch,
                        DiademResources.Grade3MinAch,
                        DiademResources.Grade3FshAch);
                    break;
                case 4:
                    DrawValues(DiademResources.Grade4Btn,
                        DiademResources.Grade4Min,
                        DiademResources.Grade4Fsh,
                        DiademResources.Grade4BtnAch,
                        DiademResources.Grade4MinAch,
                        DiademResources.Grade4FshAch);
                    break;

            }

        }
    }

    private static void DrawValues(int btn, int min, int fsh, uint btnAch, uint minAch, uint fshAch)
    {
        Helper.DrawScaledIcon(IconBTN, IconSize);
        DrawPoints(50000 - (int)btnAch - btn);

        Helper.DrawScaledIcon(IconMIN, IconSize);
        DrawPoints(50000 - (int)minAch - min);

        Helper.DrawScaledIcon(IconFSH, IconSize);
        DrawPoints(300 - (int)fshAch - fsh);
    }

    private static void DrawPoints(int count)
    {
        ImGui.SameLine();
        ImGui.AlignTextToFramePadding();
        ImGui.Text(count.ToString());
    }
}
