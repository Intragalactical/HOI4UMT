using LanguageExt;

namespace HOI4UMT.Library.ModResources;

public readonly record struct FileSaveResult(bool Saved, Option<string> Path, Option<Exception> Exception);
