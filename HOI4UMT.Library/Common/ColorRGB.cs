using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HOI4UMT.Library.Common;

public readonly record struct ColorRGB : IEquatable<ColorRGB> {
    private const int ConversionFactor = byte.MaxValue + 1;

    public readonly byte R;
    public readonly byte G;
    public readonly byte B;
    public readonly int Value;

    public ColorRGB(byte r, byte g, byte b) {
        R = r;
        G = g;
        B = b;
        Value = Color.FromArgb(r, g, b).ToArgb();
    }

    public ColorRGB(int colorValue) {
        Value = colorValue;
        B = (byte)(colorValue % ConversionFactor);
        G = (byte)((colorValue - B) / ConversionFactor % ConversionFactor);
        R = (byte)(((colorValue - B) / (ConversionFactor * ConversionFactor)) - (G / ConversionFactor));
    }

    public void Deconstruct(out byte r, out byte g, out byte b) {
        r = R;
        g = G;
        b = B;
    }

    public override string ToString() {
        return string.Format("R{0}, G{1}, B{2}", R, G, B);
    }

    public float3 ToFloat3()
        => new(R / 255f, G / 255f, B / 255f);
}
