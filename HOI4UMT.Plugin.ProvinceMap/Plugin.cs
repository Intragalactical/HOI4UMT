using HOI4UMT.Library;
using HOI4UMT.Library.Plugins;

namespace HOI4UMT.Plugin.ProvinceMap;

public class Plugin : IPlugin {
    public string Name => "Province Map";

    public string HelpFilePath => "./Help.md";

    public double Position => 2;

    public UserControl CreateControl(IMapperState mapperState, string _)
        => new ProvinceMap(mapperState);
}
