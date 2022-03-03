using HOI4UMT.Library.Common.Functional.Interfaces;
using LanguageExt;

namespace HOI4UMT.Library.Common.Functional;

public static class File<RT> where RT : struct, IHasFile<RT> {
    public static Eff<RT, string> ReadAllText(string path)
        => default(RT).FileEff.Map(rt => rt.ReadAllText(path));
}
