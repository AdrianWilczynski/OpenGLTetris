using OpenGLTetris.Blocks.BlockTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenGLTetris.Blocks
{
    public static class RandomBlockFactory
    {
        private static Random random;

        public static BaseBlock GetBlock(double sizeUnit)
        {
            if (random == null)
            {
                random = new Random();
            }

            var blockNumer = random.Next(1, 6);

            if (blockNumer == 1)
            {
                return new LShaped(sizeUnit);
            }
            else if (blockNumer == 2)
            {
                return new Square(sizeUnit);
            }
            else if (blockNumer == 3)
            {
                return new Line(sizeUnit);
            }
            else if (blockNumer == 4)
            {
                return new PodiumShaped(sizeUnit);
            }
            else
            {
                return new LightningShaped(sizeUnit);
            }
        }
    }
}
