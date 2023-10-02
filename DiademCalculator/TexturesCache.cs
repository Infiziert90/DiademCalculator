using Dalamud.Interface.Internal;
using Dalamud.Utility;
using ImGuiScene;
using Lumina.Data.Files;

namespace DiademCalculator;

//From: https://github.com/Tischel/ActionTimeline
public class TexturesCache : IDisposable
{
    private readonly Dictionary<uint, IDalamudTextureWrap> Cache = new();

    public IDalamudTextureWrap GetTextureFromIconId(uint iconId)
    {
        if (Cache.TryGetValue(iconId, out var texture))
        {
            return texture;
        }

        var iconFile = Plugin.Data.GetFile<TexFile>($"ui/icon/{iconId / 1000 * 1000:000000}/{iconId:000000}_hr1.tex")!;
        var newTexture = Plugin.PluginInterface.UiBuilder.LoadImageRaw(iconFile.GetRgbaImageData(), iconFile.Header.Width, iconFile.Header.Height, 4);
        Cache.Add(iconId, newTexture);

        return newTexture;
    }

    #region singleton
    public static void Initialize() { Instance = new TexturesCache(); }
    public static TexturesCache Instance { get; private set; } = null!;

    ~TexturesCache()
    {
        Dispose(false);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected void Dispose(bool disposing)
    {
        if (!disposing)
        {
            return;
        }

        foreach (TextureWrap tex in Cache.Keys.Select(key => Cache[key]))
        {
            tex?.Dispose();
        }

        Cache.Clear();
    }
    #endregion
}
