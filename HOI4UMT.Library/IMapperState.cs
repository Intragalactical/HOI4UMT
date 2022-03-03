using HOI4UMT.Library.Common.Functional;
using HOI4UMT.Library.Events;
using HOI4UMT.Library.ModResources;
using LanguageExt;

namespace HOI4UMT.Library;

public interface IMapperState {
    event OnResourceChangedHandler? OnResourceChanged;

    IMapperState SetResource(string name, Option<IModResource> resource);
}
