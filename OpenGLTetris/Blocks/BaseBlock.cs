using OpenGLTetris.Helpers;
using System.Drawing;

namespace OpenGLTetris.Blocks
{
    public abstract class BaseBlock
    {
        public Color Color { get; }
        public double SizeUnit { get; }

        protected double rotationAngle;

        public BaseBlock(double sizeUnit)
        {
            Color = ColorRandomizer.GetRandomColor();
            SizeUnit = sizeUnit;
        }

        public abstract void Draw();
        public abstract void Rotate();
    }
}
