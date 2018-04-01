using OpenGLTetris.Shapes;
using OpenTK.Graphics.OpenGL;

namespace OpenGLTetris.Blocks.BlockTypes
{
    public class PodiumShaped : BaseBlock
    {
        public PodiumShaped(double sizeUnit) : base(sizeUnit) { }

        public override void Draw()
        {
            GL.PushMatrix();

            GL.Rotate(rotationAngle, 0, 0, 1);

            GL.Color3(Color);

            Cube.Draw(SizeUnit);

            GL.Translate(-2 * SizeUnit, 0, 0);
            Cube.Draw(SizeUnit);

            GL.Translate(4 * SizeUnit, 0, 0);
            Cube.Draw(SizeUnit);

            GL.Translate(-2 * SizeUnit, 2 * SizeUnit, 0);
            Cube.Draw(SizeUnit);

            GL.PopMatrix();
        }

        public override void Rotate()
        {
            rotationAngle += 90;
        }
    }
}
