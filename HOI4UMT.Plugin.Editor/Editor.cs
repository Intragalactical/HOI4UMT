using HOI4UMT.Library;

namespace HOI4UMT.Plugin.Editor;
public partial class Editor : UserControl {
    private IMapperState MapperState { get; }

    public Editor(IMapperState mapperState) {
        InitializeComponent();

        MapperState = mapperState;
    }
}
