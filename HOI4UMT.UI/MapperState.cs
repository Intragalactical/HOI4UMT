using HOI4UMT.Library;
using HOI4UMT.Library.Events;
using HOI4UMT.Library.ModResources;
using LanguageExt;

namespace HOI4UMT.UI;

internal class MapperState : IMapperState {
    public event OnResourceChangedHandler? OnResourceChanged;

    public void SetResource(string name, Option<IModResource> resource) {
        OnResourceChanged?.Invoke(name, resource);
    }
}
