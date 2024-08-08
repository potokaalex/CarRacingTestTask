using System;

namespace Client.Code.Common.Services.Extensions
{
    public static class MathfExtensions
    {
        public static float Round(float value, int digits = 0) => (float)Math.Round(value, digits);
    }
}