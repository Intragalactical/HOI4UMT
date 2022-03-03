using HOI4UMT.Library;
using HOI4UMT.Library.Plugins;

namespace HOI4UMT.Plugin.RiverMap;

public class Plugin : IPlugin {
    public string Name => "River Map";

    public string HelpFilePath => "./Help.md";

    public double Position => 1;

    public UserControl CreateControl(IMapperState mapperState, string subfolder)
        => new RiverMap(mapperState, subfolder);
}
