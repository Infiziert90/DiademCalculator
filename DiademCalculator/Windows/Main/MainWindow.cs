using Dalamud.Interface.Utility;
using Dalamud.Interface.Windowing;
using static ImGuiNET.ImGuiWindowFlags;

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
        Flags = NoTitleBar | AlwaysAutoResize | NoScrollbar;
        if (Plugin.Configuration.LockWindow)
            Flags |= NoMouseInputs | NoInputs;
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
            DrawPoints((int)(500000 - DiademResources.btn500K - DiademResources.BtnPoints));

            Helper.DrawScaledIcon(IconMIN, IconSize);
            DrawPoints((int)(500000 - DiademResources.min500K - DiademResources.MinPoints));

            Helper.DrawScaledIcon(IconFSH, IconSize);
            DrawPoints((int)(500000 - DiademResources.fsh500K - DiademResources.FshPoints));

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

            switch (Grade)
            {
                case 2:
                    DrawValues(DiademResources.grade2BTN,
                        DiademResources.grade2MIN,
                        DiademResources.grade2FSH,
                        DiademResources.grade2BTNAch,
                        DiademResources.grade2MINAch,
                        DiademResources.grade2FSHAch);
                    break;
                case 3:
                    DrawValues(DiademResources.grade3BTN,
                        DiademResources.grade3MIN,
                        DiademResources.grade3FSH,
                        DiademResources.grade3BTNAch,
                        DiademResources.grade3MINAch,
                        DiademResources.grade3FSHAch);
                    break;
                case 4:
                    DrawValues(DiademResources.grade4BTN,
                        DiademResources.grade4MIN,
                        DiademResources.grade4FSH,
                        DiademResources.grade4BTNAch,
                        DiademResources.grade4MINAch,
                        DiademResources.grade4FSHAch);
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
