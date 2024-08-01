using System;

namespace Client.Code.Utilities
{
    public static class MathfExtensions
    {
        public static float Round(float value, int digits = 0) => (float)Math.Round(value, digits);
    }
}