using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackAndWhite;
namespace BlackAndWhite
{
    class BlackFace : Face
    {
        public BlackFace(int x, int y, int hp) : base(x, y, (char)2, hp)
        {

        }

        public void RandomPosition(Random rnd, int xMin, int xMax, int yMin, int yMax)
        {
            x = rnd.Next(xMin, xMax + 1);
            y = rnd.Next(yMin, yMax + 1);
        }
    }
}
