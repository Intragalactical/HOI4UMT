using HOI4UMT.Library;
using HOI4UMT.Library.Events;
using HOI4UMT.Library.ModResources;
using LanguageExt;

namespace HOI4UMT.UI;

internal struct MapperState : IMapperState {
    public event OnResourceChangedHandler? OnResourceChanged;

    public IMapperState SetResource(string name, Option<IModResource> resource) {
        _ = OnResourceChanged?.Invoke(name, resource);
        return this;
    }
}
