using HOI4UMT.Library.ModResources;
using LanguageExt;

namespace HOI4UMT.Library.Events;

public delegate Unit OnResourceChangedHandler(string name, Option<IModResource> resource);
