using Dalamud.Interface.Utility.Raii;

namespace DiademCalculator.Windows.Config;

public partial class ConfigWindow
{
    private void Settings()
    {
        using var tabItem = ImRaii.TabItem("Settings");
        if (!tabItem.Success)
            return;

        var changed = false;

        var width = ImGui.GetWindowWidth();
        ImGui.SetNextItemWidth(width / 2f);
        changed |= ImGui.SliderFloat("Background Alpha", ref Plugin.Configuration.BackgroundAlpha, 0, 1);
        changed |= ImGui.Checkbox("Lock Window", ref Plugin.Configuration.LockWindow);
        changed |= ImGui.Checkbox("Show outside Firmament and Diadem", ref Plugin.Configuration.ShowOutsideFirmamentAndDiadem);
        changed |= ImGui.Checkbox("Achievement Mode", ref Plugin.Configuration.AchievementMode);

        if (ImGui.Button("Achievement Mode Info"))
            Plugin.InfoWindow.Toggle();

        if (changed)
            Plugin.Configuration.Save();
    }
}
