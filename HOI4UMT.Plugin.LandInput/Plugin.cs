using HOI4UMT.Library;
using HOI4UMT.Library.Plugins;

namespace HOI4UMT.Plugin.LandInput;

public class Plugin : IPlugin {
    public string Name => "Land Input";
    public string HelpFilePath => "./Help.md";
    public double Position => 0;

    public UserControl CreateControl(IMapperState mapperState, string _)
        => new LandInput(mapperState);
}
