using HOI4UMT.Library.Common.Functional.Interfaces;
using LanguageExt;

namespace HOI4UMT.Library.Common.Functional;

public struct Runtime : IHasFile<Runtime>, IHasImage<Runtime>, IHasMessageBox<Runtime>, IHasCommonDialog<Runtime> {
    public Eff<Runtime, IFileIO> FileEff => Eff<Runtime, IFileIO>.Success(FileIO.Default);
    public Eff<Runtime, IImageIO> ImageEff => Eff<Runtime, IImageIO>.Success(ImageIO.Default);
    public Eff<Runtime, IMessageBoxIO> MessageBoxEff => Eff<Runtime, IMessageBoxIO>.Success(MessageBoxIO.Default);
    public Eff<Runtime, ICommonDialogIO> CommonDialogEff => Eff<Runtime, ICommonDialogIO>.Success(CommonDialogIO.Default);
}
