using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HOI4UMT.Library.Common;

public readonly record struct Point2D(in float X, in float Y) {
    public Vector2 ToVector2()
        => new(X, Y);
}
