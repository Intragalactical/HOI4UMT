using ComputeSharp;

namespace HOI4UMT.Plugin.ProvinceMap;

[AutoConstructor]
public readonly partial struct PostProcessorShader : IComputeShader {
    public readonly IReadWriteNormalizedTexture2D<float4> texture;

    private static bool IsSameColor(float3 color, float3 color2) {
        return color.R == color2.R && color.G == color2.G && color.B == color2.B;
    }

    public void Execute() {
        float3 currentColor = texture[ThreadIds.XY].RGB;

        bool canGoAbove = ThreadIds.Y - 1 >= 0;
        bool canGoLeft = ThreadIds.X - 1 >= 0;
        bool canGoRight = ThreadIds.X + 1 < texture.Width;
        bool canGoBelow = ThreadIds.Y + 1 < texture.Height;

        bool aboveIsDifferent = !canGoAbove || !IsSameColor(texture[ThreadIds.X, ThreadIds.Y - 1].RGB, currentColor);
        bool leftIsDifferent = !canGoLeft || !IsSameColor(texture[ThreadIds.X - 1, ThreadIds.Y].RGB, currentColor);
        bool rightIsDifferent = !canGoRight || !IsSameColor(texture[ThreadIds.X + 1, ThreadIds.Y].RGB, currentColor);
        bool belowIsDifferent = !canGoBelow || !IsSameColor(texture[ThreadIds.X, ThreadIds.Y + 1].RGB, currentColor);

        if (aboveIsDifferent && leftIsDifferent && rightIsDifferent && belowIsDifferent) {
            float3 newColor = canGoAbove ? texture[ThreadIds.X, ThreadIds.Y - 1].RGB :
                canGoLeft ? texture[ThreadIds.X - 1, ThreadIds.Y].RGB :
                canGoRight ? texture[ThreadIds.X + 1, ThreadIds.Y].RGB :
                canGoBelow ? texture[ThreadIds.X, ThreadIds.Y + 1].RGB :
                currentColor;
            texture[ThreadIds.XY].RGB = newColor;
        }
    }
}
