using System;

namespace Client.Code
{
    public static class MathfExtensions
    {
        public static float Round(float value, int digits) => (float)Math.Round(value, digits);
    }
}