using Dalamud.Interface.Utility;

namespace DiademCalculator.Windows;

public static class Helper
{
    public static void DrawScaledIcon(uint iconId, Vector2 iconSize)
    {
        iconSize *= ImGuiHelpers.GlobalScale;
        var texture = Plugin.Texture.GetIcon(iconId);
        if (texture == null)
        {
            ImGui.Text($"Unknown icon {iconId}");
            return;
        }

        ImGui.Image(texture.ImGuiHandle, iconSize);
    }
}
