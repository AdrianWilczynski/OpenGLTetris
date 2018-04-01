using System;
using System.Drawing;

namespace OpenGLTetris.Helpers
{
    public static class ColorRandomizer
    {
        private static Random random;

        public static Color GetRandomColor()
        {
            if (random == null)
            {
                random = new Random();
            }
           
            var r = random.Next(0, 255);
            var g = random.Next(0, 255);
            var b = random.Next(0, 255);

            return Color.FromArgb(r, g, b);
        }
    }
}
