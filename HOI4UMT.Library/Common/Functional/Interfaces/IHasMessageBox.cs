using LanguageExt;

namespace HOI4UMT.Library.Common.Functional.Interfaces;

public interface IHasMessageBox<RT> where RT : struct, IHasMessageBox<RT> {
    Eff<RT, IMessageBoxIO> MessageBoxEff { get; }
}
