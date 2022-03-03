using HOI4UMT.Library;
using HOI4UMT.Library.Plugins;

namespace HOI4UMT.Plugin.Editor;
public class Plugin : IPlugin {
    public string Name => "Editor";
    public string HelpFilePath => "./Help.md";
    public double Position => 3;

    public UserControl CreateControl(IMapperState mapperState, string _)
        => new Editor(mapperState);
}
