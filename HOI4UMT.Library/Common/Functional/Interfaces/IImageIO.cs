using LanguageExt;
using System.Drawing.Imaging;

namespace HOI4UMT.Library.Common.Functional.Interfaces;

public interface IImageIO {
    Image FromFile(string path);
    Unit Save(Image image, string filePath, ImageFormat format);
}
