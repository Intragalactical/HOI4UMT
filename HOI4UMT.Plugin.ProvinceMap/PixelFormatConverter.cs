using System.Drawing.Imaging;

namespace HOI4UMT.Plugin.ProvinceMap;

public static class PixelFormatConverter {
    /// <summary>
    /// Converts an image to a RGB PixelFormat, any bit depth. Alpha is not supported!
    /// </summary>
    /// <param name="image">The image to convert</param>
    /// <param name="to">The PixelFormat to convert to. Should only be RGB!</param>
    /// <param name="autoDispose">If true, old bitmap will be disposed.</param>
    /// <returns>New bitmap with the set PixelFormat</returns>
    public static Bitmap ConvertRGB(Bitmap image, PixelFormat to, bool autoDispose = true) {
        Bitmap newBitmap = new(image.Width, image.Height, to);

        BitmapData locked = image.LockBits(
            new(0, 0, image.Width, image.Height),
            ImageLockMode.ReadOnly,
            image.PixelFormat
        );
        BitmapData lockedNew = newBitmap.LockBits(
            new(0, 0, newBitmap.Width, newBitmap.Height),
            ImageLockMode.WriteOnly,
            newBitmap.PixelFormat
        );

        int bytesPerPixelImage = Image.GetPixelFormatSize(locked.PixelFormat) / 8;
        int bytesPerPixelNew = Image.GetPixelFormatSize(lockedNew.PixelFormat) / 8;
        int widthImage = locked.Width;
        int heightInPixelsImage = locked.Height;

        _ = Parallel.For(0, heightInPixelsImage, y => {
            for (int x = 0; x < widthImage; x++) {
                int xInBytesImage = x * bytesPerPixelImage;
                int xInBytesNew = x * bytesPerPixelNew;

                unsafe {
                    byte* currentLineImage = (byte*)locked.Scan0 + (y * locked.Stride);
                    byte* currentLineNew = (byte*)lockedNew.Scan0 + (y * lockedNew.Stride);

                    byte currentBImage = currentLineImage[xInBytesImage];
                    byte currentGImage = currentLineImage[xInBytesImage + 1];
                    byte currentRImage = currentLineImage[xInBytesImage + 2];

                    currentLineNew[xInBytesNew] = currentBImage;
                    currentLineNew[xInBytesNew + 1] = currentGImage;
                    currentLineNew[xInBytesNew + 2] = currentRImage;
                }
            }
        });

        image.UnlockBits(locked);
        newBitmap.UnlockBits(lockedNew);

        if (autoDispose)
            image.Dispose();

        return newBitmap;
    }
}
