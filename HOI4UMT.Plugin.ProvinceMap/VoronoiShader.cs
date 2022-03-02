using ComputeSharp;
using System.Numerics;

namespace HOI4UMT.Plugin.ProvinceMap;

[AutoConstructor]
public readonly partial struct VoronoiShader : IComputeShader {
    public readonly IReadWriteNormalizedTexture2D<float4> texture;
    public readonly ReadWriteBuffer<Vector2> points;
    public readonly ReadWriteBuffer<float3> colors;
    public readonly float3 colorToDrawOn;
    public readonly bool euclidean;

    private float3 GetColorForPixelEuclidean(int x, int y) {
        Vector2 currentPoint = new Vector2(x, y);
        Vector2 closestPoint = new Vector2(float.MaxValue, float.MaxValue);
        float3 closestColor = texture[x, y].RGB;

        for (int i = 0; i < points.Length; i++) {
            if (GetDistanceEuclidean(closestPoint, currentPoint) > GetDistanceEuclidean(points[i], currentPoint)) {
                closestPoint = points[i];
                closestColor = colors[i];
            }
        }

        return closestColor;
    }

    private float3 GetColorForPixelManhattan(int x, int y) {
        Vector2 currentPoint = new Vector2(x, y);
        Vector2 closestPoint = new Vector2(float.MaxValue, float.MaxValue);
        float3 closestColor = texture[x, y].RGB;

        for (int i = 0; i < points.Length; i++) {
            if (GetDistanceManhattan(closestPoint, currentPoint) > GetDistanceManhattan(points[i], currentPoint)) {
                closestPoint = points[i];
                closestColor = colors[i];
            }
        }

        return closestColor;
    }

    private static float GetDistanceEuclidean(Vector2 from, Vector2 to)
    => Hlsl.Sqrt(
        ((from.X - to.X) * (from.X - to.X)) +
        ((from.Y - to.Y) * (from.Y - to.Y))
    );

    private static float GetDistanceManhattan(Vector2 from, Vector2 to)
        => Hlsl.Abs(from.X - to.X) + Hlsl.Abs(from.Y - to.Y);

    public void Execute() {
        float3 currentColor = texture[ThreadIds.XY].RGB;

        texture[ThreadIds.XY].RGB =
            currentColor.R == colorToDrawOn.R && currentColor.G == colorToDrawOn.G && currentColor.B == colorToDrawOn.B ?
                euclidean ?
                    GetColorForPixelEuclidean(ThreadIds.X, ThreadIds.Y) :
                    GetColorForPixelManhattan(ThreadIds.X, ThreadIds.Y) :
                currentColor;
    }
}
