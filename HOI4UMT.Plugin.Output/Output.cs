using HOI4UMT.Library;

namespace HOI4UMT.Plugin.Output;

public partial class Output : UserControl {
    private IMapperState MapperState { get; }

    public Output(IMapperState mapperState) {
        InitializeComponent();

        MapperState = mapperState;
    }
}
