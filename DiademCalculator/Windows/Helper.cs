using Dalamud.Interface.Utility;

namespace DiademCalculator.Windows;

public static class Helper
{
    public static void DrawScaledIcon(uint iconId, Vector2 iconSize)
    {
        iconSize *= ImGuiHelpers.GlobalScale;
        var texture = TexturesCache.Instance!.GetTextureFromIconId(iconId);
        ImGui.Image(texture.ImGuiHandle, iconSize);
    }
}
