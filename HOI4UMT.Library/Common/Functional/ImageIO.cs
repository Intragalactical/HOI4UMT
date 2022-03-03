using HOI4UMT.Library.Common.Functional.Interfaces;
using LanguageExt;
using System.Drawing.Imaging;

namespace HOI4UMT.Library.Common.Functional;
public struct ImageIO : IImageIO {
    public static readonly IImageIO Default = new ImageIO();

    public Image FromFile(string path)
        => Image.FromFile(path);

    public Unit Save(Image image, string filePath, ImageFormat format) {
        image.Save(filePath, format);
        return Unit.Default;
    }
}
