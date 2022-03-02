using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOI4UMT.Library.Common;

public static class ThreadSafeRandom {
    private static readonly object SyncLock = new();
    private static readonly Random Rand = new();

    public static int Next() {
        return Rand.Next();
    }

    public static int Next(in int min, in int max) {
        lock (SyncLock) {
            return Rand.Next(min, max);
        }
    }
}
