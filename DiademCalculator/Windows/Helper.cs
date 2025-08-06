using Dalamud.Interface.Utility;

namespace DiademCalculator.Windows;

public static class Helper
{
    public const float SeparatorPadding = 1.0f;
    public static float GetSeparatorPaddingHeight => SeparatorPadding * ImGuiHelpers.GlobalScale;

    public static float CalculateChildHeight()
    {
        return ImGui.GetFrameHeightWithSpacing() + ImGui.GetStyle().WindowPadding.Y + GetSeparatorPaddingHeight;
    }

    public static void DrawScaledIcon(uint iconId, Vector2 iconSize)
    {
        iconSize *= ImGuiHelpers.GlobalScale;
        var texture = Plugin.Texture.GetFromGameIcon(iconId).GetWrapOrEmpty();
        ImGui.Image(texture.Handle, iconSize);
    }
}
