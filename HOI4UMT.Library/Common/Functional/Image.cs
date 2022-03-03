using HOI4UMT.Library.Common.Functional.Interfaces;
using LanguageExt;
using System.Drawing.Imaging;

namespace HOI4UMT.Library.Common.Functional;

public static class Image<RT> where RT : struct, IHasImage<RT> {
    public static Eff<RT, Image> FromFile(string path)
        => default(RT).ImageEff.Map(rt => rt.FromFile(path));

    public static Eff<RT, Unit> Save(Image image, string filePath, ImageFormat format)
        => default(RT).ImageEff.Map(rt => rt.Save(image, filePath, format));
}
