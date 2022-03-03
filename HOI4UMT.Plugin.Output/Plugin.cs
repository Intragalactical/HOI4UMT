using HOI4UMT.Library;
using HOI4UMT.Library.Plugins;

namespace HOI4UMT.Plugin.Output;

public class Plugin : IPlugin {
    public string Name => "Output";

    public string HelpFilePath => "./Help.md";

    public double Position => 4;

    public UserControl CreateControl(IMapperState mapperState, string _)
        => new Output(mapperState);
}
